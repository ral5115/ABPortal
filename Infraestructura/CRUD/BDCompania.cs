using System;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructura.CRUD
{
    public class BDCompania
    {

        public void Sp_Admin_Compania_Actualizar(int RowId, string DC_Nit, string DC_RazonSocial, string DC_NombreUsuario,
             string DC_Direccion, string DC_Telefono, string DC_Correo, string DC_FechaCreacion, string EL_FondoPantallaLogin,
             string EL_FondoLogin, string EL_TextoLogin, string EL_ColorTextoLogin, string EL_ColorIconoLogin, string EL_ColorBotonLogin,
             string EL_ColorBotonTextoLogin, string EL_UrlFondo, string EP_TextoEmpresa, string EP_ColorFondoEmpresa, string EP_ColorTextoEmpresa,
             string EP_ColorFondoNavbar, string EP_ColorFondoSiebar, string EP_ColorFondoCentral, string EP_ColorFondoAdministracion,
             string EP_ColorTextoBotones, string EP_ColorBotonConsultar, string EP_ColorBotonInsertar, string EP_ColorBotonActualizar
             , string EP_ColorBotonEliminar, string EP_ColorBotonRegresar, string EP_UrlFondo)
        {
            SqlConnection sqlConexion = new SqlConnection(Configuraciones.ConexionPortal);
            SqlCommand sqlComando = new SqlCommand();

            sqlComando.Connection = sqlConexion;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_Admin_Compania_Actualizar";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("RowId", RowId);
            sqlComando.Parameters.AddWithValue("DC_Nit", DC_Nit);
            sqlComando.Parameters.AddWithValue("DC_RazonSocial", DC_RazonSocial);
            sqlComando.Parameters.AddWithValue("DC_NombreUsuario", DC_NombreUsuario);
            sqlComando.Parameters.AddWithValue("DC_Direccion", DC_Direccion);
            sqlComando.Parameters.AddWithValue("DC_Telefono", DC_Telefono);
            sqlComando.Parameters.AddWithValue("DC_Correo", DC_Correo);
            sqlComando.Parameters.AddWithValue("DC_FechaCreacion", DC_FechaCreacion);
            sqlComando.Parameters.AddWithValue("EL_FondoPantallaLogin", EL_FondoPantallaLogin);
            sqlComando.Parameters.AddWithValue("EL_FondoLogin", EL_FondoLogin);
            sqlComando.Parameters.AddWithValue("EL_TextoLogin", EL_TextoLogin);
            sqlComando.Parameters.AddWithValue("EL_ColorTextoLogin", EL_ColorTextoLogin);
            sqlComando.Parameters.AddWithValue("EL_ColorIconoLogin", EL_ColorIconoLogin);
            sqlComando.Parameters.AddWithValue("EL_ColorBotonLogin", EL_ColorBotonLogin);
            sqlComando.Parameters.AddWithValue("EL_ColorBotonTextoLogin", EL_ColorBotonTextoLogin);
            sqlComando.Parameters.AddWithValue("EL_UrlFondo", EL_UrlFondo);
            sqlComando.Parameters.AddWithValue("EP_TextoEmpresa", EP_TextoEmpresa);
            sqlComando.Parameters.AddWithValue("EP_ColorFondoEmpresa", EP_ColorFondoEmpresa);
            sqlComando.Parameters.AddWithValue("EP_ColorTextoEmpresa", EP_ColorTextoEmpresa);
            sqlComando.Parameters.AddWithValue("EP_ColorFondoNavbar", EP_ColorFondoNavbar);
            sqlComando.Parameters.AddWithValue("EP_ColorFondoSiebar", EP_ColorFondoSiebar);
            sqlComando.Parameters.AddWithValue("EP_ColorFondoCentral", EP_ColorFondoCentral);
            sqlComando.Parameters.AddWithValue("EP_ColorFondoAdministracion", EP_ColorFondoAdministracion);
            sqlComando.Parameters.AddWithValue("EP_ColorTextoBotones", EP_ColorTextoBotones);
            sqlComando.Parameters.AddWithValue("EP_ColorBotonConsultar", EP_ColorBotonConsultar);
            sqlComando.Parameters.AddWithValue("EP_ColorBotonInsertar", EP_ColorBotonInsertar);
            sqlComando.Parameters.AddWithValue("EP_ColorBotonActualizar", EP_ColorBotonActualizar);
            sqlComando.Parameters.AddWithValue("EP_ColorBotonEliminar", EP_ColorBotonEliminar);
            sqlComando.Parameters.AddWithValue("EP_ColorBotonRegresar", EP_ColorBotonRegresar);
            sqlComando.Parameters.AddWithValue("EP_UrlFondo", EP_UrlFondo);

            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public DataSet Sp_Admin_Compania_Buscar(int RowId)
        {
            SqlConnection sqlConexion = new SqlConnection(Configuraciones.ConexionPortal);
            SqlCommand sqlComando = new SqlCommand();
            SqlDataAdapter sqlAdaptador = new SqlDataAdapter();
            DataSet ds = new DataSet();

            sqlComando.Connection = sqlConexion;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_Admin_Compania_Buscar";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("RowId", RowId);

            try
            {
                sqlAdaptador.SelectCommand = sqlComando;
                sqlAdaptador.Fill(ds);
                return ds;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                sqlComando.Parameters.Clear();
                sqlComando.Connection.Close();
            }
        }
    }
}
