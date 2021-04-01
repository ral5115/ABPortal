using System;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructura.CRUD
{
    public class BDUsuario
    {
        public void Sp_Admin_Usuarios_Insertar(string Documento, string Usuario, string Clave,
            string NombreCompleto, int IdPerfil, string Correo)
        {
            SqlConnection sqlConexion = new SqlConnection(Configuraciones.ConexionPortal);
            SqlCommand sqlComando = new SqlCommand();

            sqlComando.Connection = sqlConexion;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_Admin_Usuarios_Insertar";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("Documento", Documento);
            sqlComando.Parameters.AddWithValue("Usuario", Usuario);
            sqlComando.Parameters.AddWithValue("Clave", Clave);
            sqlComando.Parameters.AddWithValue("NombreCompleto", NombreCompleto);
            sqlComando.Parameters.AddWithValue("IdPerfil", IdPerfil);
            sqlComando.Parameters.AddWithValue("Correo", Correo);

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

        public void Sp_Admin_Usuarios_Actualizar(int RowId, string Documento, string Usuario, string Clave,
            string NombreCompleto, int IdPerfil, string Correo)
        {
            SqlConnection sqlConexion = new SqlConnection(Configuraciones.ConexionPortal);
            SqlCommand sqlComando = new SqlCommand();

            sqlComando.Connection = sqlConexion;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_Admin_Usuarios_Actualizar";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("RowId", RowId);
            sqlComando.Parameters.AddWithValue("Documento", Documento);
            sqlComando.Parameters.AddWithValue("Usuario", Usuario);
            sqlComando.Parameters.AddWithValue("Clave", Clave);
            sqlComando.Parameters.AddWithValue("NombreCompleto", NombreCompleto);
            sqlComando.Parameters.AddWithValue("IdPerfil", IdPerfil);
            sqlComando.Parameters.AddWithValue("Correo", Correo);

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

        public void Sp_Admin_Usuarios_Eliminar(int RowId)
        {
            SqlConnection sqlConexion = new SqlConnection(Configuraciones.ConexionPortal);
            SqlCommand sqlComando = new SqlCommand();

            sqlComando.Connection = sqlConexion;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_Admin_Usuarios_Eliminar";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("RowId", RowId);

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

        public DataSet Sp_Admin_Usuarios_Buscar(int RowId, string Documento, string Usuario)
        {
            SqlConnection sqlConexion = new SqlConnection(Configuraciones.ConexionPortal);
            SqlCommand sqlComando = new SqlCommand();
            SqlDataAdapter sqlAdaptador = new SqlDataAdapter();
            DataSet ds = new DataSet();

            sqlComando.Connection = sqlConexion;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_Admin_Usuarios_Buscar";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("RowId", RowId);
            sqlComando.Parameters.AddWithValue("Documento", Documento);
            sqlComando.Parameters.AddWithValue("Usuario", Usuario);

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
