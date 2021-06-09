using Dominio.Modelos;
using Infraestructura.CRUD;
using System.Data;

namespace Dominio.FormulariosAdministracion
{
    public class Compania
    {
        private readonly BDConsultar _BDConsultar = new BDConsultar();
        private readonly BDCompania _BDCompania = new BDCompania();
        public DataSet Consultar()
        {
            return _BDConsultar.Query("Sp_Admin_Compania");
        }

        public void Actualizar(ModeloCompania Modelo)
        {
            _BDCompania.Sp_Admin_Compania_Actualizar(Modelo.RowId,Modelo.DC_Nit, Modelo.DC_RazonSocial, Modelo.DC_NombreUsuario,
                Modelo.DC_Direccion, Modelo.DC_Telefono, Modelo.DC_Correo, Modelo.DC_FechaCreacion, Modelo.EL_FondoPantallaLogin,
                Modelo.EL_FondoLogin, Modelo.EL_TextoLogin, Modelo.EL_ColorTextoLogin, Modelo.EL_ColorIconoLogin, Modelo.EL_ColorBotonLogin,
                Modelo.EL_ColorBotonTextoLogin, Modelo.EL_UrlFondo == null? string.Empty: Modelo.EL_UrlFondo, Modelo.EP_TextoEmpresa, Modelo.EP_ColorFondoEmpresa, Modelo.EP_ColorTextoEmpresa,
                Modelo.EP_ColorFondoNavbar, Modelo.EP_ColorFondoSiebar, Modelo.EP_ColorFondoCentral, Modelo.EP_ColorFondoAdministracion,
                Modelo.EP_ColorTextoBotones, Modelo.EP_ColorBotonConsultar, Modelo.EP_ColorBotonInsertar, Modelo.EP_ColorBotonActualizar,
                Modelo.EP_ColorBotonEliminar, Modelo.EP_ColorBotonRegresar, Modelo.EP_UrlFondo == null? string.Empty : Modelo.EP_UrlFondo);
        }

        public ModeloCompania EnviarModelo(int RowId)
        {
            //informacion del administrador
            DataSet DsGenerico = _BDCompania.Sp_Admin_Compania_Buscar(RowId);

            ModeloCompania Modelo = new ModeloCompania();

            Modelo.RowId = (int)DsGenerico.Tables[0].Rows[0]["RowId"];
            Modelo.DC_Nit = DsGenerico.Tables[0].Rows[0]["DC_Nit"].ToString();
            Modelo.DC_RazonSocial = DsGenerico.Tables[0].Rows[0]["DC_RazonSocial"].ToString();
            Modelo.DC_NombreUsuario = DsGenerico.Tables[0].Rows[0]["DC_NombreUsuario"].ToString();
            Modelo.DC_Direccion = DsGenerico.Tables[0].Rows[0]["DC_Direccion"].ToString();
            Modelo.DC_Telefono = DsGenerico.Tables[0].Rows[0]["DC_Telefono"].ToString();
            Modelo.DC_Correo = DsGenerico.Tables[0].Rows[0]["DC_Correo"].ToString();
            Modelo.DC_FechaCreacion = DsGenerico.Tables[0].Rows[0]["DC_FechaCreacion"].ToString();
            Modelo.EL_FondoPantallaLogin = DsGenerico.Tables[0].Rows[0]["EL_FondoPantallaLogin"].ToString();
            Modelo.EL_FondoLogin = DsGenerico.Tables[0].Rows[0]["EL_FondoLogin"].ToString();
            Modelo.EL_TextoLogin = DsGenerico.Tables[0].Rows[0]["EL_TextoLogin"].ToString();
            Modelo.EL_ColorTextoLogin = DsGenerico.Tables[0].Rows[0]["EL_ColorTextoLogin"].ToString();
            Modelo.EL_ColorIconoLogin = DsGenerico.Tables[0].Rows[0]["EL_ColorIconoLogin"].ToString();
            Modelo.EL_ColorBotonLogin = DsGenerico.Tables[0].Rows[0]["EL_ColorBotonLogin"].ToString();
            Modelo.EL_ColorBotonTextoLogin = DsGenerico.Tables[0].Rows[0]["EL_ColorBotonTextoLogin"].ToString();
            Modelo.EL_UrlFondo = DsGenerico.Tables[0].Rows[0]["EL_UrlFondo"].ToString();
            Modelo.EP_TextoEmpresa = DsGenerico.Tables[0].Rows[0]["EP_TextoEmpresa"].ToString();
            Modelo.EP_ColorFondoEmpresa = DsGenerico.Tables[0].Rows[0]["EP_ColorFondoEmpresa"].ToString();
            Modelo.EP_ColorTextoEmpresa = DsGenerico.Tables[0].Rows[0]["EP_ColorTextoEmpresa"].ToString();
            Modelo.EP_ColorFondoNavbar = DsGenerico.Tables[0].Rows[0]["EP_ColorFondoNavbar"].ToString();
            Modelo.EP_ColorFondoSiebar = DsGenerico.Tables[0].Rows[0]["EP_ColorFondoSiebar"].ToString();
            Modelo.EP_ColorFondoCentral = DsGenerico.Tables[0].Rows[0]["EP_ColorFondoCentral"].ToString();
            Modelo.EP_ColorFondoAdministracion = DsGenerico.Tables[0].Rows[0]["EP_ColorFondoAdministracion"].ToString();
            Modelo.EP_ColorTextoBotones = DsGenerico.Tables[0].Rows[0]["EP_ColorTextoBotones"].ToString();
            Modelo.EP_ColorBotonConsultar = DsGenerico.Tables[0].Rows[0]["EP_ColorBotonConsultar"].ToString();
            Modelo.EP_ColorBotonInsertar = DsGenerico.Tables[0].Rows[0]["EP_ColorBotonInsertar"].ToString();
            Modelo.EP_ColorBotonActualizar = DsGenerico.Tables[0].Rows[0]["EP_ColorBotonActualizar"].ToString();
            Modelo.EP_ColorBotonEliminar = DsGenerico.Tables[0].Rows[0]["EP_ColorBotonEliminar"].ToString();
            Modelo.EP_ColorBotonRegresar = DsGenerico.Tables[0].Rows[0]["EP_ColorBotonRegresar"].ToString();
            Modelo.EP_UrlFondo = DsGenerico.Tables[0].Rows[0]["EP_UrlFondo"].ToString();

            return Modelo;
        }
    }
}
