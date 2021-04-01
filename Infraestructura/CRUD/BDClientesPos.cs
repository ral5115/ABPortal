using System;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructura.CRUD
{
    public class BDClientesPos
    {
        public DataSet Sp_Clientes_Pos(int RowIdUsuario)
        {
            SqlConnection sqlConexion = new SqlConnection(Configuraciones.ConexionPortal);
            SqlCommand sqlComando = new SqlCommand();
            SqlDataAdapter sqlAdaptador = new SqlDataAdapter();
            DataSet ds = new DataSet();

            sqlComando.Connection = sqlConexion;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_Clientes_Pos";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("RowIdUsuario", RowIdUsuario);

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

        public DataSet Sp_Clientes_Pos_Filtros(int RowIdUsuario, string FechaInicio, string FechaFin
                        ,string RowIdDepartamento, string RowIdCiudad, int RowIdSexo, int RowIdEstado)
        {
            SqlConnection sqlConexion = new SqlConnection(Configuraciones.ConexionPortal);
            SqlCommand sqlComando = new SqlCommand();
            SqlDataAdapter sqlAdaptador = new SqlDataAdapter();
            DataSet ds = new DataSet();

            sqlComando.Connection = sqlConexion;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_Clientes_Pos_Filtros";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("RowIdUsuario", RowIdUsuario);
            sqlComando.Parameters.AddWithValue("FechaInicio", FechaInicio);
            sqlComando.Parameters.AddWithValue("FechaFin", FechaFin);
            sqlComando.Parameters.AddWithValue("RowIdDepartamento", RowIdDepartamento);
            sqlComando.Parameters.AddWithValue("RowIdCiudad", RowIdCiudad);
            sqlComando.Parameters.AddWithValue("RowIdSexo", RowIdSexo);
            sqlComando.Parameters.AddWithValue("RowIdEstado", RowIdEstado);

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

        public DataSet Sp_Clientes_Pos_Filtros_Completo(int RowIdUsuario, string FechaInicio, string FechaFin
                       , string RowIdDepartamento, string RowIdCiudad, int RowIdSexo, int RowIdEstado)
        {
            SqlConnection sqlConexion = new SqlConnection(Configuraciones.ConexionPortal);
            SqlCommand sqlComando = new SqlCommand();
            SqlDataAdapter sqlAdaptador = new SqlDataAdapter();
            DataSet ds = new DataSet();

            sqlComando.Connection = sqlConexion;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_Clientes_Pos_Filtros_Completo";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("RowIdUsuario", RowIdUsuario);
            sqlComando.Parameters.AddWithValue("FechaInicio", FechaInicio);
            sqlComando.Parameters.AddWithValue("FechaFin", FechaFin);
            sqlComando.Parameters.AddWithValue("RowIdDepartamento", RowIdDepartamento);
            sqlComando.Parameters.AddWithValue("RowIdCiudad", RowIdCiudad);
            sqlComando.Parameters.AddWithValue("RowIdSexo", RowIdSexo);
            sqlComando.Parameters.AddWithValue("RowIdEstado", RowIdEstado);

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

        public string Sp_Clientes_Pos_Insertar_Actualizar(int RowId, string Documento, string RowIdTipoDocumento,
            string Nombre1, string Nombre2, string Apellido1, string Apellido2, string FechaNacimiento, string RH,
            string Direccion, string RowIdDepartamento, string RowIdCiudad, string Telefono, string Correo, string Celular,
            string RowIdSexo, int RowIdUsuario)
        {
            SqlConnection sqlConexion = new SqlConnection(Configuraciones.ConexionPortal);
            SqlCommand sqlComando = new SqlCommand();
            SqlDataAdapter sqlAdaptador = new SqlDataAdapter();
            DataSet ds = new DataSet();

            sqlComando.Connection = sqlConexion;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_Clientes_Pos_Insertar_Actualizar";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("RowId", RowId);
            sqlComando.Parameters.AddWithValue("Documento", Documento);
            sqlComando.Parameters.AddWithValue("RowIdTipoDocumento", RowIdTipoDocumento);
            sqlComando.Parameters.AddWithValue("Nombre1", Nombre1);
            sqlComando.Parameters.AddWithValue("Nombre2", Nombre2);
            sqlComando.Parameters.AddWithValue("Apellido1", Apellido1);
            sqlComando.Parameters.AddWithValue("Apellido2", Apellido2);
            sqlComando.Parameters.AddWithValue("FechaNacimiento", FechaNacimiento);
            sqlComando.Parameters.AddWithValue("RH", RH);
            sqlComando.Parameters.AddWithValue("Direccion", Direccion);
            sqlComando.Parameters.AddWithValue("RowIdDepartamento", RowIdDepartamento);
            sqlComando.Parameters.AddWithValue("RowIdCiudad", RowIdCiudad);
            sqlComando.Parameters.AddWithValue("Telefono", Telefono);
            sqlComando.Parameters.AddWithValue("Correo", Correo);
            sqlComando.Parameters.AddWithValue("Celular", Celular);
            sqlComando.Parameters.AddWithValue("RowIdSexo", RowIdSexo);
            sqlComando.Parameters.AddWithValue("RowIdUsuario", RowIdUsuario);

            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
                return "Importacion exitosa";
            }
            catch (Exception Ex)
            {
                return Ex.Message.ToString();
            }
            finally
            {
                sqlComando.Connection.Close();
            }
        }

        public DataSet Sp_Clientes_Pos_Eliminar(int RowId)
        {
            SqlConnection sqlConexion = new SqlConnection(Configuraciones.ConexionPortal);
            SqlCommand sqlComando = new SqlCommand();
            SqlDataAdapter sqlAdaptador = new SqlDataAdapter();
            DataSet ds = new DataSet();

            sqlComando.Connection = sqlConexion;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_Clientes_Pos_Eliminar";
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

        public DataSet Sp_Consultar_Clientes_Local(string Documento)
        {
            SqlConnection sqlConexion = new SqlConnection(Configuraciones.ConexionPortal);
            SqlCommand sqlComando = new SqlCommand();
            SqlDataAdapter sqlAdaptador = new SqlDataAdapter();
            DataSet ds = new DataSet();

            sqlComando.Connection = sqlConexion;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_Consultar_Clientes_Local";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("Documento", Documento);

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

        public DataSet Sp_Consultar_Clientes_Siesa(string Documento)
        {
            SqlConnection sqlConexion = new SqlConnection(Configuraciones.ConexionPortal);
            SqlCommand sqlComando = new SqlCommand();
            SqlDataAdapter sqlAdaptador = new SqlDataAdapter();
            DataSet ds = new DataSet();

            sqlComando.Connection = sqlConexion;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_Consultar_Clientes_Siesa";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("Documento", Documento);

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

        public DataSet Sp_Ciudades(string RowIdDepartamento)
        {
            SqlConnection sqlConexion = new SqlConnection(Configuraciones.ConexionPortal);
            SqlCommand sqlComando = new SqlCommand();
            SqlDataAdapter sqlAdaptador = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                sqlComando.Connection = sqlConexion;
                sqlComando.CommandType = CommandType.StoredProcedure;
                sqlComando.CommandText = "Sp_Ciudades";
                sqlComando.Parameters.AddWithValue("RowIdDepartamento", RowIdDepartamento);

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

        public DataSet Sp_ClientePosPorDocumento(string Documento)
        {
            SqlConnection sqlConexion = new SqlConnection(Configuraciones.ConexionPortal);
            SqlCommand sqlComando = new SqlCommand();
            SqlDataAdapter sqlAdaptador = new SqlDataAdapter();
            DataSet ds = new DataSet();

            sqlComando.Connection = sqlConexion;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_ClientePosPorDocumento";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("Documento", Documento);

            try
            {
                sqlAdaptador.SelectCommand = sqlComando;
                sqlAdaptador.Fill(ds);
                ds.Tables[0].TableName = "ClientesPos";
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

        public DataSet Sp_Consultar_Campo(string Campo, string Documento)
        {
            SqlConnection sqlConexion = new SqlConnection(Configuraciones.ConexionPortal);
            SqlCommand sqlComando = new SqlCommand();
            SqlDataAdapter sqlAdaptador = new SqlDataAdapter();
            DataSet ds = new DataSet();

            var Query = "SELECT " + Campo + " FROM ClientesPos WHERE Documento = '" + Documento + "'";

            sqlComando.Connection = sqlConexion;
            sqlComando.CommandType = CommandType.Text;
            sqlComando.CommandText = Query;
            sqlComando.CommandTimeout = 999999999;

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
                sqlComando.Connection.Close();
            }
        }

        public void Sp_Actualizar_Campo(string Campo, string Documento)
        {
            SqlConnection sqlConexion = new SqlConnection(Configuraciones.ConexionPortal);
            SqlCommand sqlComando = new SqlCommand();

            var Query = "UPDATE ClientesPos SET " + Campo + " = 1 WHERE Documento = " + "'" + Documento + "'";

            sqlComando.Connection = sqlConexion;
            sqlComando.CommandType = CommandType.Text;
            sqlComando.CommandText = Query;
            sqlComando.CommandTimeout = 999999999;

            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                sqlComando.Connection.Close();
            }
        }
    }
}
