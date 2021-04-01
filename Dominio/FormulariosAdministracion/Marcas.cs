using Dominio.Modelos;
using Infraestructura.CRUD;
using System.Data;

namespace Dominio.FormulariosAdministracion
{
    public class Marcas
    {
        private readonly BDConsultar _BDConsultar = new BDConsultar();
        private readonly BDMarcas _BDMarcas = new BDMarcas();
        public DataSet Consultar()
        {
            return _BDConsultar.QueryNacional("Sp_ConsultarMarcas");
        }

        public void Insertar(ModeloMarca Modelo)
        {
            _BDMarcas.Sp_AlmacenarMarcas(Modelo.CodigoSiesa, Modelo.CodigoVTEX);
        }

        public void Actualizar(ModeloMarca Modelo)
        {
            _BDMarcas.Sp_ActualizarMarcas(Modelo.RowId, Modelo.CodigoSiesa, Modelo.CodigoVTEX);
        }

        public void Eliminar(int RowId)
        {
            _BDMarcas.Sp_EliminarMarcas(RowId);
        }

        public ModeloMarca EnviarModelo(int RowId)
        {
            DataSet DsGenerico = _BDMarcas.Sp_ConsultarMarcasPorCodigo(RowId);

            ModeloMarca Modelo = new ModeloMarca();

            Modelo.RowId = (int)DsGenerico.Tables[0].Rows[0]["RowId"];
            Modelo.CodigoSiesa = DsGenerico.Tables[0].Rows[0]["CodigoSiesa"].ToString();
            Modelo.CodigoVTEX = DsGenerico.Tables[0].Rows[0]["CodigoVTEX"].ToString();

            return Modelo;
        }
    }
}
