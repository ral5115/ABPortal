using Dominio.FormulariosAdministracion;
using Dominio.Modelos;
using System.Web.Mvc;

namespace Interfaz.Controllers
{
    public class CompaniaController : Controller
    {
        private readonly Compania _Compania = new Compania();

        public ActionResult Index()
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if ((int)Session["Perfil"] == 2)
            {
                return View(_Compania.Consultar());
            }

            return RedirectToAction("Index", "Login");
        }

        public ActionResult Edit(int RowId)
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if ((int)Session["Perfil"] == 2)
            {
                return View(_Compania.EnviarModelo(RowId));
            }

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult Edit(ModeloCompania Modelo)
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if ((int)Session["Perfil"] == 2)
            {
                _Compania.Actualizar(Modelo);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", "Login");
        }
    }
}