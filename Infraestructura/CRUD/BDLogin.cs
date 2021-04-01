using System;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructura.CRUD
{
    public class BDLogin
    {
        public DataSet Sp_Admin_Autenticacion(string Usuario, string Clave)
        {
            SqlConnection SqlConnection = new SqlConnection(Configuraciones.ConexionPortal);
            DataSet Ds = new DataSet();
            SqlDataAdapter objDA = new SqlDataAdapter();
            SqlCommand sqlComando = new SqlCommand();
            sqlComando.Connection = SqlConnection;
            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_Admin_Autenticacion";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("Usuario", Usuario);
            sqlComando.Parameters.AddWithValue("Clave", Clave);
            objDA.SelectCommand = sqlComando;

            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
                objDA.Fill(Ds);
                return Ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlComando.Connection.Close();
            }
        }

        public DataSet Sp_Admin_Menu(int RowId_Perfil)
        {
            SqlConnection SqlConnection = new SqlConnection(Configuraciones.ConexionPortal);
            DataSet Ds = new DataSet();
            SqlDataAdapter objDA = new SqlDataAdapter();
            SqlCommand sqlComando = new SqlCommand();
            sqlComando.Connection = SqlConnection;
            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_Admin_Menu";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("RowId_Perfil", RowId_Perfil);
            objDA.SelectCommand = sqlComando;

            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
                objDA.Fill(Ds);
                return Ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlComando.Connection.Close();
            }
        }

        public DataSet Sp_Admin_SubMenu(int RowId_Perfil, int RowId_Munu)
        {
            SqlConnection SqlConnection = new SqlConnection(Configuraciones.ConexionPortal);
            DataSet Ds = new DataSet();
            SqlDataAdapter objDA = new SqlDataAdapter();
            SqlCommand sqlComando = new SqlCommand();
            sqlComando.Connection = SqlConnection;
            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_Admin_SubMenu";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("RowId_Perfil", RowId_Perfil);
            sqlComando.Parameters.AddWithValue("RowId_Munu", RowId_Munu);
            objDA.SelectCommand = sqlComando;

            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
                objDA.Fill(Ds);
                return Ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlComando.Connection.Close();
            }
        }
    }
}
