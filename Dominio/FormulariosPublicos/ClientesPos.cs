using Dominio.Modelos;
using System;
using System.Data;

namespace Dominio.FormulariosPublicos
{
    public class ClientesPos
    {
        Conectores.ClientesPos _ClientesPosConector = new Conectores.ClientesPos();
        Infraestructura.CRUD.BDClientesPos _BDClientesPos = new Infraestructura.CRUD.BDClientesPos();
        Apis.IcommktCorreo _IcommktCorreo = new Apis.IcommktCorreo();
        Apis.IcommktSMS _IcommktSMS = new Apis.IcommktSMS();

        public DataSet Consultar(int RowIdUsuario)
        {
            return _BDClientesPos.Sp_Clientes_Pos(RowIdUsuario);
        }

        public DataSet Consultar(int RowIdUsuario, string FechaInicio, string FechaFin, string RowIdCiudad, int RowIdSexo, int RowIdEstado)
        {
            return _BDClientesPos.Sp_Clientes_Pos_Filtros(RowIdUsuario, FechaInicio, FechaFin, RowIdCiudad == "-1" ? "-1" : RowIdCiudad.Split('-')[0],
                                                          RowIdCiudad == "-1" ? "-1" : RowIdCiudad.Split('-')[1], RowIdSexo, RowIdEstado);
        }

        public DataSet ConsultarReporte(int RowIdUsuario, string FechaInicio, string FechaFin, string RowIdCiudad, int RowIdSexo, int RowIdEstado)
        {
            return _BDClientesPos.Sp_Clientes_Pos_Filtros_Completo(RowIdUsuario, FechaInicio, FechaFin, RowIdCiudad == "-1" ? "-1" : RowIdCiudad.Split('-')[0],
                                                          RowIdCiudad == "-1" ? "-1" : RowIdCiudad.Split('-')[1], RowIdSexo, RowIdEstado);
        }

        public string InsertarActualizar(ModeloClientesPos Modelo, int RowIdUsuario)
        {
            try
            {
                var Respuesta = "Respuestas - Local: ";

                Respuesta += _BDClientesPos.Sp_Clientes_Pos_Insertar_Actualizar(
                    Modelo.RowId,
                    Modelo.Documento,
                    Modelo.RowIdTipoDocumento,
                    Modelo.Nombre1,
                    Modelo.Nombre2 == null ? string.Empty : Modelo.Nombre2,
                    Modelo.Apellido1,
                    Modelo.Apellido2 == null ? string.Empty : Modelo.Apellido2,
                    Modelo.FechaNacimiento,
                    Modelo.RH == null ? string.Empty : Modelo.RH,
                    Modelo.Direccion == null ? string.Empty : Modelo.Direccion,
                    Modelo.RowIdDepartamento,
                    Modelo.RowIdCiudad,
                    Modelo.Telefono == null ? string.Empty : Modelo.Telefono,
                    Modelo.Correo,
                    Modelo.Celular,
                    Modelo.RowIdSexo,
                    RowIdUsuario);

                Respuesta += " - ERP: ";
                Respuesta += _ClientesPosConector.Importar(Modelo.Documento);

                if (Respuesta.Contains("ERP: Importacion exitosa"))
                {
                    _BDClientesPos.Sp_Actualizar_Campo("ClienteERP", Modelo.Documento);

                    if (Convert.ToString(_BDClientesPos.Sp_Consultar_Campo("EnvioCorreo", Modelo.Documento).Tables[0].Rows[0]["EnvioCorreo"]) == string.Empty)
                    {
                        if (Modelo.Correo != string.Empty)
                        {
                            Respuesta += " - Envio Correo: ";
                            Respuesta += _IcommktCorreo.EnviarCorreo(Modelo);
                        }
                    }

                    if (Convert.ToString(_BDClientesPos.Sp_Consultar_Campo("EnvioSMS", Modelo.Documento).Tables[0].Rows[0]["EnvioSMS"]) == string.Empty)
                    {
                        if (Modelo.Celular != string.Empty)
                        {
                            Respuesta += " - Envio SMS: ";
                            Respuesta += _IcommktSMS.EnviarSMS(Modelo);
                        }
                    }
                }
                return Respuesta;
            }
            catch (Exception Ex)
            {
                return Ex.Message.ToString();
            }

        }

        public void Eliminar(int RowId)
        {
            _BDClientesPos.Sp_Clientes_Pos_Eliminar(RowId);
        }

        public ModeloClientesPos EnviarModelo(string Campos)
        {
            var CamposSplit = Campos.Split('|');

            DataSet DsGenericoLocal = _BDClientesPos.Sp_Consultar_Clientes_Local(CamposSplit[0]);

            if (DsGenericoLocal.Tables[0].Rows.Count > 0)
            {
                ModeloClientesPos Modelo = new ModeloClientesPos();

                Modelo.RowId = (int)DsGenericoLocal.Tables[0].Rows[0]["RowId"];
                Modelo.Documento = DsGenericoLocal.Tables[0].Rows[0]["Documento"].ToString();
                Modelo.RowIdTipoDocumento = DsGenericoLocal.Tables[0].Rows[0]["RowIdTipoDocumento"].ToString();
                Modelo.Nombre1 = CamposSplit[3] == string.Empty ? DsGenericoLocal.Tables[0].Rows[0]["Nombre1"].ToString() : CamposSplit[3];
                Modelo.Nombre2 = CamposSplit[4] == string.Empty ? DsGenericoLocal.Tables[0].Rows[0]["Nombre2"].ToString() : CamposSplit[4];
                Modelo.Apellido1 = CamposSplit[1] == string.Empty ? DsGenericoLocal.Tables[0].Rows[0]["Apellido1"].ToString() : CamposSplit[1];
                Modelo.Apellido2 = CamposSplit[2] == string.Empty ? DsGenericoLocal.Tables[0].Rows[0]["Apellido2"].ToString() : CamposSplit[2];
                Modelo.FechaNacimiento = CamposSplit[6] == string.Empty ? DsGenericoLocal.Tables[0].Rows[0]["FechaNacimiento"].ToString() : CamposSplit[6];
                Modelo.RH = CamposSplit[7] == string.Empty ? DsGenericoLocal.Tables[0].Rows[0]["RH"].ToString() : CamposSplit[7];
                Modelo.Direccion = DsGenericoLocal.Tables[0].Rows[0]["Direccion"].ToString();
                Modelo.RowIdDepartamento = DsGenericoLocal.Tables[0].Rows[0]["RowIdDepartamento"].ToString();
                Modelo.RowIdCiudad = DsGenericoLocal.Tables[0].Rows[0]["RowIdCiudad"].ToString();
                Modelo.Telefono = DsGenericoLocal.Tables[0].Rows[0]["Telefono"].ToString();
                Modelo.Correo = DsGenericoLocal.Tables[0].Rows[0]["Correo"].ToString();
                Modelo.Celular = DsGenericoLocal.Tables[0].Rows[0]["Celular"].ToString();
                Modelo.RowIdSexo = CamposSplit[5] == string.Empty ? DsGenericoLocal.Tables[0].Rows[0]["RowIdSexo"].ToString() : CamposSplit[5];
                Modelo.HabeasData = DsGenericoLocal.Tables[0].Rows[0]["HabeasData"].ToString();

                return Modelo;
            }

            else
            {
                DataSet DsGenericoSiesa = _BDClientesPos.Sp_Consultar_Clientes_Siesa(CamposSplit[0]);

                if (DsGenericoSiesa.Tables[0].Rows.Count > 0)
                {
                    ModeloClientesPos Modelo = new ModeloClientesPos();

                    Modelo.RowId = 0;
                    Modelo.Documento = DsGenericoSiesa.Tables[0].Rows[0]["Documento"].ToString();
                    Modelo.RowIdTipoDocumento = DsGenericoSiesa.Tables[0].Rows[0]["RowIdTipoDocumento"].ToString();
                    Modelo.Nombre1 = CamposSplit[3] == string.Empty ? DsGenericoSiesa.Tables[0].Rows[0]["Nombre1"].ToString() : CamposSplit[3];
                    Modelo.Nombre2 = CamposSplit[4] == string.Empty ? DsGenericoSiesa.Tables[0].Rows[0]["Nombre2"].ToString() : CamposSplit[4];
                    Modelo.Apellido1 = CamposSplit[1] == string.Empty ? DsGenericoSiesa.Tables[0].Rows[0]["Apellido1"].ToString() : CamposSplit[1];
                    Modelo.Apellido2 = CamposSplit[2] == string.Empty ? DsGenericoSiesa.Tables[0].Rows[0]["Apellido2"].ToString() : CamposSplit[2];
                    Modelo.FechaNacimiento = CamposSplit[6] == string.Empty ? DsGenericoSiesa.Tables[0].Rows[0]["FechaNacimiento"].ToString() : CamposSplit[6];
                    Modelo.RH = CamposSplit[7] == string.Empty ? DsGenericoSiesa.Tables[0].Rows[0]["RH"].ToString() : CamposSplit[7];
                    Modelo.Direccion = DsGenericoSiesa.Tables[0].Rows[0]["Direccion"].ToString();
                    Modelo.RowIdDepartamento = DsGenericoSiesa.Tables[0].Rows[0]["RowIdDepartamento"].ToString();
                    Modelo.RowIdCiudad = DsGenericoSiesa.Tables[0].Rows[0]["RowIdCiudad"].ToString();
                    Modelo.Telefono = DsGenericoSiesa.Tables[0].Rows[0]["Telefono"].ToString();
                    Modelo.Correo = DsGenericoSiesa.Tables[0].Rows[0]["Correo"].ToString();
                    Modelo.Celular = DsGenericoSiesa.Tables[0].Rows[0]["Celular"].ToString();
                    Modelo.RowIdSexo = CamposSplit[5] == string.Empty ? DsGenericoSiesa.Tables[0].Rows[0]["RowIdSexo"].ToString() : CamposSplit[5];
                    Modelo.HabeasData = DsGenericoLocal.Tables[0].Rows[0]["HabeasData"].ToString();

                    return Modelo;
                }
                else
                {
                    return EnviarModeloVacio(CamposSplit);
                }
            }
        }

        public ModeloClientesPos EnviarModeloVacio(string[] CamposSplit)
        {
            ModeloClientesPos Modelo = new ModeloClientesPos();

            Modelo.RowId = 0;
            Modelo.Documento = CamposSplit[0];
            Modelo.RowIdTipoDocumento = "C";
            Modelo.Nombre1 = CamposSplit[3];
            Modelo.Nombre2 = CamposSplit[4];
            Modelo.Apellido1 = CamposSplit[1];
            Modelo.Apellido2 = CamposSplit[2];
            Modelo.FechaNacimiento = CamposSplit[6];
            Modelo.RH = CamposSplit[7];
            Modelo.Direccion = string.Empty;
            Modelo.RowIdDepartamento = "05";
            Modelo.RowIdCiudad = "001";
            Modelo.Telefono = string.Empty;
            Modelo.Correo = string.Empty;
            Modelo.Celular = string.Empty;
            Modelo.RowIdSexo = CamposSplit[5] == string.Empty ? "0" : CamposSplit[5];

            return Modelo;
        }
    }
}
