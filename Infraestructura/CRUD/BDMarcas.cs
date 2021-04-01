using System;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructura.CRUD
{
    public class BDMarcas
    {
        public DataSet Sp_ConsultarMarcasPorCodigo(int RowId)
        {
            SqlConnection sqlConexion = new SqlConnection(Configuraciones.ConexionNacional);
            SqlCommand sqlComando = new SqlCommand();
            SqlDataAdapter sqlAdaptador = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                sqlComando.Connection = sqlConexion;
                sqlComando.CommandType = CommandType.StoredProcedure;
                sqlComando.CommandText = "Sp_ConsultarMarcasPorCodigo";

                sqlComando.Parameters.AddWithValue("RowId", RowId);

                sqlAdaptador.SelectCommand = sqlComando;
                sqlAdaptador.Fill(ds);

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

            return ds;
        }

        public void Sp_AlmacenarMarcas(string CodigoSiesa, string CodigoVTEX)
        {
            SqlConnection SqlConnection = new SqlConnection(Configuraciones.ConexionNacional);
            SqlCommand sqlComando = new SqlCommand();
            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_AlmacenarMarcas";
            sqlComando.Parameters.AddWithValue("CodigoSiesa", CodigoSiesa);
            sqlComando.Parameters.AddWithValue("CodigoVTEX", CodigoVTEX);

            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
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

        public void Sp_ActualizarMarcas(int RowId, string CodigoSiesa, string CodigoVTEX)
        {
            SqlConnection SqlConnection = new SqlConnection(Configuraciones.ConexionNacional);
            SqlCommand sqlComando = new SqlCommand();
            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_ActualizarMarcas";
            sqlComando.Parameters.AddWithValue("RowId", RowId);
            sqlComando.Parameters.AddWithValue("CodigoSiesa", CodigoSiesa);
            sqlComando.Parameters.AddWithValue("CodigoVTEX", CodigoVTEX);

            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
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


        public void Sp_EliminarMarcas(int RowId)
        {
            SqlConnection SqlConnection = new SqlConnection(Configuraciones.ConexionNacional);
            SqlCommand sqlComando = new SqlCommand();
            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_EliminarMarcas";
            sqlComando.Parameters.AddWithValue("RowId", RowId);


            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
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
