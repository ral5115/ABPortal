using Dominio.Modelos;
using Infraestructura.CRUD;
using System.Data;

namespace Dominio.FormulariosAdministracion
{
    public class Usuarios
    {
        private readonly BDConsultar _BDConsultar = new BDConsultar();
        private readonly BDUsuario _BDUsuarios = new BDUsuario();
        public DataSet Consultar()
        {
            return _BDConsultar.Query("Sp_Admin_Usuarios");
        }

        public void Insertar(ModeloUsuario Modelo)
        {
            _BDUsuarios.Sp_Admin_Usuarios_Insertar(Modelo.Documento, Modelo.Usuario, Modelo.Clave,
                Modelo.NombreCompleto, Modelo.IdPerfil, Modelo.Correo);
        }

        public void Actualizar(ModeloUsuario Modelo)
        {
            _BDUsuarios.Sp_Admin_Usuarios_Actualizar(Modelo.RowId, Modelo.Documento, Modelo.Usuario, Modelo.Clave,
                Modelo.NombreCompleto, Modelo.IdPerfil, Modelo.Correo);
        }

        public void Eliminar(int RowId)
        {
            _BDUsuarios.Sp_Admin_Usuarios_Eliminar(RowId);
        }

        public string ValidarUsuario(string Documento, string Usuario)
        {
            DataSet DsGenerico = _BDUsuarios.Sp_Admin_Usuarios_Buscar(0, Documento, Usuario);

            if (DsGenerico.Tables[0].Rows.Count > 0)
            {
                return "EXISTE";
            }
            return "";
        }

        public ModeloUsuario EnviarModelo(int RowId)
        {
            DataSet DsGenerico = _BDUsuarios.Sp_Admin_Usuarios_Buscar(RowId, "", "");

            ModeloUsuario Modelo = new ModeloUsuario();

            Modelo.RowId = (int)DsGenerico.Tables[0].Rows[0]["RowId"];
            Modelo.IdPerfil = (int)DsGenerico.Tables[0].Rows[0]["RowId_Perfil"];
            Modelo.Documento = DsGenerico.Tables[0].Rows[0]["Documento"].ToString();
            Modelo.Usuario = DsGenerico.Tables[0].Rows[0]["Usuario"].ToString();
            Modelo.Clave = DsGenerico.Tables[0].Rows[0]["Clave"].ToString();
            Modelo.NombreCompleto = DsGenerico.Tables[0].Rows[0]["NombreCompleto"].ToString();
            Modelo.Correo = DsGenerico.Tables[0].Rows[0]["Correo"].ToString();

            return Modelo;
        }
    }
}
