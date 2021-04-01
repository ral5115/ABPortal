using System;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructura.CRUD
{
    public class BDConsultar
    {
        public DataSet Query(string NombreProcedimiento)
        {

            SqlConnection SqlConnection = new SqlConnection(Configuraciones.ConexionPortal);
            DataSet Ds = new DataSet();
            SqlDataAdapter objDA = new SqlDataAdapter();
            SqlCommand sqlComando = new SqlCommand();

            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = NombreProcedimiento;
            sqlComando.CommandTimeout = 999999999;
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

        public DataSet QueryNacional(string NombreProcedimiento)
        {

            SqlConnection SqlConnection = new SqlConnection(Configuraciones.ConexionNacional);
            DataSet Ds = new DataSet();
            SqlDataAdapter objDA = new SqlDataAdapter();
            SqlCommand sqlComando = new SqlCommand();

            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = NombreProcedimiento;
            sqlComando.CommandTimeout = 999999999;
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

        public DataSet QueryInternacional(string NombreProcedimiento)
        {

            SqlConnection SqlConnection = new SqlConnection(Configuraciones.ConexionInternacional);
            DataSet Ds = new DataSet();
            SqlDataAdapter objDA = new SqlDataAdapter();
            SqlCommand sqlComando = new SqlCommand();

            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = NombreProcedimiento;
            sqlComando.CommandTimeout = 999999999;
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
