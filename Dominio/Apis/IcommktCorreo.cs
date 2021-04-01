using Dominio.Modelos;
using Infraestructura;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Data;
using System.Globalization;
using System.IO;

namespace Dominio.Apis
{
    public class IcommktCorreo
    {
        Infraestructura.CRUD.BDConsultar _BDConsultar = new Infraestructura.CRUD.BDConsultar();
        Infraestructura.CRUD.BDClientesPos _BDClientesPos = new Infraestructura.CRUD.BDClientesPos();

        public string EnviarCorreo(ModeloClientesPos Modelo)
        {
            if (Modelo.Correo != "NOTIENE@GMAIL.COM")
            {
                RestClient Client = new RestClient("https://api.trx.icommarketing.com");
                RestRequest Request = new RestRequest("/email", Method.POST);

                var Html = File.ReadAllText(Configuraciones.RutaHTMLServidor);
                Html = Html.Replace("nombre", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Modelo.Nombre1.ToString().ToLower()));

                string json = "{";
                json += "\"From\": \"Agua Bendita datospersonales@aguabendita.com.co\",";
                json += "\"To\": \"" + Modelo.Correo + "\",";
                json += "\"Cc\": \"\",";
                json += "\"Bcc\": \"\",";
                json += "\"Subject\": \"Únete a la comunidad Agua Bendita\",";
                json += "\"Tag\": \"" + Modelo.Correo + "\",";
                json += "\"HtmlBody\": \"" + Html + "\",";
                json += "\"TextBody\": \"string\",";
                json += "\"ReplyTo\": \"datospersonales@aguabendita.com.co\",";
                json += "\"TrackOpens\": true,";
                json += "\"TrackLinks\": \"HtmlAndText\",";
                json += "\"Attachments\": []";
                json += "}";

                Request.AddHeader("Content-Type", "application/json");
                Request.AddHeader("X-Trx-Api-Key", "5ea3ca1f-5839-460a-996f-a5d7d22e27fe");
                Request.AddHeader("Accept", "application/json");
                Request.AddParameter("application/json", json.ToString(), ParameterType.RequestBody);

                try
                {
                    var Response = Client.Execute(Request);

                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        _BDClientesPos.Sp_Actualizar_Campo("EnvioCorreo", Modelo.Documento);
                        return "Importacion exitosa";
                    }
                    else
                    {
                        return "Error al enviar el correo, favor verificarlo.";
                    }
                }
                catch (Exception Ex)
                {
                    return Ex.Message.ToString();
                }
            }
            return "No se envia correo.";
        }

        public void ValidarConfirmacionCorreo()
        {
            try
            {
                DataSet DsClientes = _BDConsultar.Query("Sp_ValidarConfirmacionCorreo");

                if (DsClientes.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow Registro in DsClientes.Tables[0].Rows)
                    {
                        var Documento = Registro["Documento"].ToString();
                        var Correo = Registro["Correo"].ToString();

                        RestClient Client = new RestClient("https://api.trx.icommarketing.com");
                        RestRequest Request = new RestRequest("messages/outbound/clicks?count=10&offset=0&recipient=" + Correo + "", Method.GET);
                        
                        Request.AddHeader("Content-Type", "application/json");
                        Request.AddHeader("X-Trx-Api-Key", "5ea3ca1f-5839-460a-996f-a5d7d22e27fe");
                        Request.AddHeader("Accept", "application/json");

                        var response = Client.Execute(Request);

                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            dynamic json = JsonConvert.DeserializeObject<dynamic>(response.Content);
                            int Click = json.TotalCount;

                            if (Click > 0)
                            {
                                for (int i = 0; i < Click; i++)
                                {
                                    if (json.Clicks[i].OriginalLink.ToString() == "https://www.aguabendita.com.co/")
                                    {
                                        _BDClientesPos.Sp_Actualizar_Campo("ConfirmacionCorreo", Documento);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                var Mensaje = Ex.Message.ToString();
            }
        }

        public void InsertarClienteEnIcommkt()
        {
            try
            {
                DataSet DsClientes = _BDConsultar.Query("Sp_ClienteIcommktCorreo");

                foreach (DataRow Registro in DsClientes.Tables[0].Rows)
                {

                    RestClient client = new RestClient("https://api.icommarketing.com");
                    RestRequest request = new RestRequest("/Contacts/SaveContact.Json/", Method.POST);

                    string json = "{\"ProfileKey\":\"NDcyMDYw0\", \"Contact\":";
                    json += "{";
                    json += "\"Email\":\"" + Registro["email"].ToString() + "\",";
                    json += "\"CustomFields\":[";
                    json += "{\"Key\":\"Tipo_Docuento\",\"Value\":\"" + Registro["Tipo_Docuento"].ToString() + "\"},";
                    json += "{\"Key\":\"Documento\",\"Value\":\"" + Registro["Documento"].ToString() + "\"},";
                    json += "{\"Key\":\"Primer_Apellido\",\"Value\":\"" + Registro["Primer_Apellido"].ToString() + "\"},";
                    json += "{\"Key\":\"Segundo_Apellido\",\"Value\":\"" + Registro["Segundo_Apellido"].ToString() + "\"},";
                    json += "{\"Key\":\"Primer_Nombre\",\"Value\":\"" + Registro["Primer_Nombre"].ToString() + "\"},";
                    json += "{\"Key\":\"Segundo_Nombre\",\"Value\":\"" + Registro["Segundo_Nombre"].ToString() + "\"},";
                    json += "{\"Key\":\"Sexo\",\"Value\":\"" + Registro["Sexo"].ToString() + "\"},";
                    json += "{\"Key\":\"Fecha_Nacimiento\",\"Value\":\"" + Registro["Fecha_Nacimiento"].ToString() + "\"},";
                    json += "{\"Key\":\"RH\",\"Value\":\"" + Registro["RH"].ToString() + "\"},";
                    json += "{\"Key\":\"Celular\",\"Value\":\"" + Registro["Celular"].ToString() + "\"},";
                    json += "{\"Key\":\"Telefono\",\"Value\":\"" + Registro["Telefono"].ToString() + "\"},";
                    json += "{\"Key\":\"Departamento\",\"Value\":\"" + Registro["Departamento"].ToString() + "\"},";
                    json += "{\"Key\":\"Ciudad\",\"Value\":\"" + Registro["Ciudad"].ToString() + "\"},";
                    json += "{\"Key\":\"Direccion\",\"Value\":\"" + Registro["Direccion"].ToString() + "\"}";
                    json += "]";
                    json += "}";
                    json += "}";

                    request.AddHeader("Content-Type", "application/json");
                    request.AddHeader("Authorization", "MTcyNS00OTM2LWFndWFiZW5kaWNvX3Vzcg2");
                    request.AddHeader("Accept", "application/json");
                    request.AddParameter("application/json", json.ToString(), ParameterType.RequestBody);

                    var response = client.Execute(request);

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        dynamic content = JsonConvert.DeserializeObject<dynamic>(response.Content);
                        var status = content.SaveContactJsonResult.Data.Status;

                        if (status == "A")
                        {
                            _BDClientesPos.Sp_Actualizar_Campo("ClienteCorreoIcommkt", Registro["Documento"].ToString());
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                var Mensaje = Ex.Message.ToString();
            }
        }
    }
}
