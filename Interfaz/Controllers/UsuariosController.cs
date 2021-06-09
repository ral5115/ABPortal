using Dominio.FormulariosAdministracion;
using Dominio.Modelos;
using Dominio.Recursos;
using System;
using System.Web.Mvc;

namespace Interfaz.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly Usuarios _Usuarios = new Usuarios();
        private readonly Combos _Combos = new Combos();
        public ActionResult Index()
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if ((int)Session["Perfil"] == 2)
            {
                //consulta usuarios para devolverlos a la vista
                return View(_Usuarios.Consultar());
            }

            return RedirectToAction("Index", "Login");
        }

        public ActionResult Create()
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if ((int)Session["Perfil"] == 2)
            {
                ViewBag.ListadoPerfiles = _Combos.Obtener("Sp_Admin_Perfiles");
                return View("Create");
            }

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult Create(ModeloUsuario Modelo)
        {
            if (_Usuarios.ValidarUsuario(Modelo.Documento, Modelo.Usuario) == "EXISTE")
            {
                ViewData["Error"] = "EL USUARIO O EL DOCUMENTO YA EXISTE...";
                ViewBag.ListadoPerfiles = _Combos.Obtener("Sp_Admin_Perfiles", Modelo.RowId.ToString());
                return View(Modelo);
            }

            _Usuarios.Insertar(Modelo);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int RowId)
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if ((int)Session["Perfil"] == 2)
            {
                RecuperarCombo(RowId);
                return View(_Usuarios.EnviarModelo(RowId));
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult Edit(ModeloUsuario Modelo)
        {
            _Usuarios.Actualizar(Modelo);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(string RowId)
        {
            _Usuarios.Eliminar(Convert.ToInt32(RowId));
            return Json("El usuario ha sido eliminado.", JsonRequestBehavior.AllowGet);
        }

        private void RecuperarCombo(int RowId)
        {
            //llena el combobox con informacion
            ViewBag.ListadoPerfiles = _Combos.Obtener("Sp_Admin_Perfiles", _Usuarios.EnviarModelo(RowId).IdPerfil.ToString());
        }
    }
}