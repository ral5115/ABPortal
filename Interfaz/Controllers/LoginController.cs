using Dominio.Login;
using Newtonsoft.Json;
using System.Data;
using System.Web.Mvc;

namespace Interfaz.Controllers
{
    public class LoginController : Controller
    {
        private Login _Login = new Login();

        //Login
        [HttpGet]
        public ActionResult Index()
        {
            //asigna los datos a las variables temporales
            Session["Estilos"] = JsonConvert.SerializeObject(_Login.Estilos());
            Session["DatosImportantes"] = null;
            Session["Perfil"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Usuario, string Clave)
        {
            //valida usuario, arma menu dependiedo de los permisos del usuario
            var ArregloAutenticacion = _Login.Autenticar(Usuario, Clave);

            if (ArregloAutenticacion.Length == 2)
            {
                if (ArregloAutenticacion[1] == "Error")
                {
                    ViewData["Error"] = "El Usuario No Tiene Permisos";
                    return View();
                }

                //informacion adicinal para armar el front
                DataSet DsDatosImportantes = _Login.DatosImportantes(Usuario, Clave);

                Session["Menu"] = ArregloAutenticacion[1];
                Session["DatosImportantes"] = JsonConvert.SerializeObject(DsDatosImportantes);
                Session["Perfil"] = DsDatosImportantes.Tables[0].Rows[0]["RowId_Perfil"];
                //Redirige a Compañia/Index
                return RedirectToAction("Index", ArregloAutenticacion[0]);
            }
            else
            {
                ViewData["Error"] = ArregloAutenticacion[0];
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session["DatosImportantes"] = null;
            return RedirectToAction("Index");
        }
    }
}