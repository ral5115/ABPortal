using Dominio.Modelos;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Data;
using System.Net;

namespace Dominio.Apis
{
    public class IcommktSMS
    {
        Infraestructura.CRUD.BDConsultar _BDConsultar = new Infraestructura.CRUD.BDConsultar();
        Infraestructura.CRUD.BDClientesPos _BDClientesPos = new Infraestructura.CRUD.BDClientesPos();

        public string EnviarSMS(ModeloClientesPos Modelo)
        {
            if (Modelo.Celular != "9999999999")
            {
                RestClient Client = new RestClient("https://api.messaging-service.com");
                RestRequest Request = new RestRequest("/sms/1/text/advanced", Method.POST);

                string json = "{\"bulkId\":\"57" + Modelo.Celular +
                "\",\"messages\":[{\"from\":\"EDMSMS\",\"destinations\":[{\"to\":\"57" + Modelo.Celular +
                "\", \"messageId\":\"57" + Modelo.Celular +
                "\" } ],\"text\":\"Hola " + Modelo.Nombre1 +
                " Bienvenido a AGUA BENDITA, Acepta nuestra política de privacidad de habeas data clic aquí :" +
                "https://aguabenditaco.surveyicommkt.com/formulario-confirmacion-ab-pos?email=" + Modelo.Correo +
                "&nombre=" + Modelo.Nombre1 +
                "&telefono=" + Modelo.Celular +
                "&identificacion=57" + Modelo.Documento + "" +
                "\"}],\"tracking\":{ \"track\":\"URL\",\"type\":\"Consentimiento\"} }";

                Request.AddHeader("Content-Type", "application/json");
                Request.AddHeader("Authorization", "Basic YWd1YWJlbmRpdGE6c21zMjAyMEFndWE=");
                Request.AddHeader("Accept", "application/json");
                Request.AddParameter("application/json", json.ToString(), ParameterType.RequestBody);

                try
                {
                    var Response = Client.Execute(Request);

                    if (Response.StatusCode == HttpStatusCode.OK)
                    {
                        _BDClientesPos.Sp_Actualizar_Campo("EnvioSMS", Modelo.Documento);
                        return "Importacion exitosa";
                    }
                    else
                    {
                        return "Error al enviar el SMS, favor verificarlo.";
                    }
                }
                catch (Exception Ex)
                {
                    return Ex.Message.ToString();
                }
            }
            return "No se envia SMS.";
        }

        public void ValidarConfirmacionSMS()
        {
            try
            {
                DataSet DsClientes = _BDConsultar.Query("Sp_ValidarConfirmacionSMS");

                if (DsClientes.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow Registro in DsClientes.Tables[0].Rows)
                    {
                        var Documento = Registro["Documento"].ToString();
                        var Correo = Registro["Correo"].ToString();

                        RestClient Client = new RestClient("https://api.icommarketing.com");
                        RestRequest Request = new RestRequest("/Contacts/ListFull.Json/", Method.POST);

                        string json = "{";
                        json += "\"ProfileKey\":\"NDc0Mjk20\",";
                        json += "\"Filters\":{";
                        json += "\"Email\":\"" + Correo + "\"";
                        json += "}";
                        json += "}";

                        Request.AddHeader("Authorization", "MTcyNS00OTM2LWFndWFiZW5kaWNvX3Vzcg2");
                        Request.AddHeader("Content-Type", "application/json");
                        Request.AddParameter("application/json", json.ToString(), ParameterType.RequestBody);

                        var response = Client.Execute(Request);

                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            var Content = JsonConvert.DeserializeObject<dynamic>(response.Content);
                            string JsonContent = Content["ListContactsFullJsonResult"].ToString();

                            if (JsonContent != "[]")
                            {
                                _BDClientesPos.Sp_Actualizar_Campo("ConfirmacionSMS", Documento);
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
                DataSet DsClientes = _BDConsultar.Query("Sp_ClienteIcommktSMS");

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

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        dynamic content = JsonConvert.DeserializeObject<dynamic>(response.Content);
                        var status = content.SaveContactJsonResult.Data.Status;
                        _BDClientesPos.Sp_Actualizar_Campo("ClienteSMSIcommkt", Registro["Documento"].ToString());
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

