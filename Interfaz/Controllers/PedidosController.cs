using Dominio.FormulariosPublicos;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Interfaz.Controllers
{
    public class PedidosController : Controller
    {
        private readonly Pedidos _Pedidos = new Pedidos();

        public async Task<ActionResult> Nacional()
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return await Task.Run(() =>
            {
                return View(_Pedidos.Nacional());
            });
        }

        public async Task<ActionResult> Internacional()
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return await Task.Run(() =>
            {
                return View(_Pedidos.Internacional());
            });
        }
    }
}