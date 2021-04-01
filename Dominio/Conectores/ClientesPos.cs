using Dominio.Recursos;
using Infraestructura;
using Infraestructura.CRUD;
using System;
using System.Data;

namespace Dominio.Conectores
{
    public class ClientesPos
    {
        BDConsultar _BDConsultar = new BDConsultar();
        BDClientesPos _BDClientesPos = new BDClientesPos();
        Deserealizar _Deserealizar = new Deserealizar();

        public string Importar(string Documento)
        {
            try
            {
                var RutaPlano = Configuraciones.RutaPlanoReal;
                var Respuesta = Configuraciones.ObjGeneric.ImportarDatosDS(96165,
                           "CLIENTES_POS_ICOMM", 2, "1", "gt", "gt",
                           _BDClientesPos.Sp_ClientePosPorDocumento(Documento), ref RutaPlano);

                return _Deserealizar.XML(Respuesta);
            }
            catch (Exception Ex)
            {
                return Ex.Message.ToString();
            }
        }

        public void Importar()
        {
            try
            {
                DataSet DsClientes = _BDConsultar.Query("Sp_ListadoClientesHabeasData");

                if (DsClientes.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow Registro in DsClientes.Tables[0].Rows)
                    {
                        var Respuesta = Importar(Registro["Documento"].ToString());

                        if (Respuesta == "Importacion exitosa")
                        {
                            _BDClientesPos.Sp_Actualizar_Campo("HabeasData", Registro["Documento"].ToString());
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
