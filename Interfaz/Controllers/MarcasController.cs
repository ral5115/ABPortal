using Dominio.FormulariosAdministracion;
using Dominio.Modelos;
using System;
using System.Web.Mvc;

namespace Interfaz.Controllers
{
    public class MarcasController : Controller
    {
        private readonly Marcas _Marcas = new Marcas();
        public ActionResult Index()
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(_Marcas.Consultar());
        }

        public ActionResult Create()
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(ModeloMarca Modelo)
        {
            _Marcas.Insertar(Modelo);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int RowId)
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(_Marcas.EnviarModelo(RowId));
        }

        [HttpPost]
        public ActionResult Edit(ModeloMarca Modelo)
        {
            _Marcas.Actualizar(Modelo);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(string RowId)
        {
            _Marcas.Eliminar(Convert.ToInt32(RowId));
            return Json("La marca ha sido eliminada.", JsonRequestBehavior.AllowGet);
        }
    }
}