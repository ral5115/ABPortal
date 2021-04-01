using Dominio.Login;
using Newtonsoft.Json;
using System.Data;
using System.Web.Mvc;

namespace Interfaz.Controllers
{
    public class LoginController : Controller
    {
        private Login _Login = new Login();

        [HttpGet]
        public ActionResult Index()
        {
            Session["Estilos"] = JsonConvert.SerializeObject(_Login.Estilos());
            Session["DatosImportantes"] = null;
            Session["Perfil"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Usuario, string Clave)
        {
            var ArregloAutenticacion = _Login.Autenticar(Usuario, Clave);

            if (ArregloAutenticacion.Length == 2)
            {
                if (ArregloAutenticacion[1] == "Error")
                {
                    ViewData["Error"] = "El Usuario No Tiene Permisos";
                    return View();
                }
                DataSet DsDatosImportantes = _Login.DatosImportantes(Usuario, Clave);

                Session["Menu"] = ArregloAutenticacion[1];
                Session["DatosImportantes"] = JsonConvert.SerializeObject(DsDatosImportantes);
                Session["Perfil"] = DsDatosImportantes.Tables[0].Rows[0]["RowId_Perfil"];
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