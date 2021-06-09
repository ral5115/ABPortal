using Infraestructura.CRUD;
using System.Data;

namespace Dominio.Login
{
    public class Login
    {
        private readonly BDConsultar _BDConsultar = new BDConsultar();
        private readonly BDLogin _BDLogin = new BDLogin();
        private Menu _Menu = new Menu();

        public DataSet Estilos()
        {
            return _BDConsultar.Query("Sp_Admin_Estilos");
        }

        public string[] Autenticar(string Usuario, string Clave)
        {
            DataSet DsAutenticacion = _BDLogin.Sp_Admin_Autenticacion(Usuario, Clave);

            //Define informacion dependiendo del cliente
            if (DsAutenticacion.Tables[0].Rows.Count > 0)
            {
                //arma el html para crear el menu
                var Menu = _Menu.Obtener((int)DsAutenticacion.Tables[0].Rows[0]["RowId_Perfil"],
               (string)DsAutenticacion.Tables[0].Rows[0]["EP_ColorFondoAdministracion"],
               (string)DsAutenticacion.Tables[0].Rows[0]["EP_ColorFondoAdministracion"]);

                //Controlador donde se dirigira
                var Accion = (string)DsAutenticacion.Tables[0].Rows[0]["Pagina_Inicial"];

                string[] ArregloAutenticacion = new string[]
                {
                    Accion,
                    Menu
                };
                return ArregloAutenticacion;
            }
            else
            {
                string[] ArregloAutenticacion = new string[] { "Usuario o Contraseña Incorrecta" };
                return ArregloAutenticacion;
            }
        }

        public DataSet DatosImportantes(string Usuario, string Clave)
        {
            return _BDLogin.Sp_Admin_Autenticacion(Usuario, Clave);
        }
    }
}
