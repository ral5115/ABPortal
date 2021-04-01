using System.Web;
using System.Web.Optimization;

namespace Interfaz
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/ContenidoLogin/css").Include(
                      "~/Content/images/icons/favicon.ico",
                      "~/Content/vendor/bootstrap/css/bootstrap.min.css",
                      "~/Content/fonts/font-awesome-4.7.0/css/font-awesome.min.css",
                      "~/Content/fonts/iconic/css/material-design-iconic-font.min.css",
                      "~/Content/vendor/animate/animate.css",
                      "~/Content/vendor/css-hamburgers/hamburgers.min.css",
                      "~/Content/vendor/animsition/css/animsition.min.css",
                      "~/Content/vendor/select2/select2.min.css",
                      "~/Content/vendor/daterangepicker/daterangepicker.css",
                      "~/Content/css/util.css",
                      "~/Content/css/main.css"));

            bundles.Add(new ScriptBundle("~/ContenidoLogin/js").Include(
                      "~/Content/vendor/jquery/jquery-3.2.1.min.js",
                      "~/Content/vendor/animsition/js/animsition.min.js",
                      "~/Content/vendor/bootstrap/js/popper.js",
                      "~/Content/vendor/bootstrap/js/bootstrap.min.js",
                      "~/Content/vendor/select2/select2.min.js",
                      "~/Content/vendor/daterangepicker/moment.min.js",
                      "~/Content/vendor/daterangepicker/daterangepicker.js",
                      "~/Content/vendor/countdowntime/countdowntime.js",
                      "~/Content/js/main.js"));

            bundles.Add(new StyleBundle("~/ContenidoGeneral/css").Include(
                     "~/Content/css/Bloqueo.css",
                     "~/Content/assets/css/bootstrap.min.css",
                     "~/Content/assets/css/atlantis.min.css",
                     "~/Content/assets/css/demo.css"));

            bundles.Add(new ScriptBundle("~/ContenidoGeneral/js").Include(
                     "~/Content/assets/js/core/popper.min.js",
                      "~/Content/assets/js/core/bootstrap.min.js",
                      "~/Content/assets/js/plugin/jquery-ui-1.12.1.custom/jquery-ui.min.js",
                      "~/Content/assets/js/plugin/jquery-ui-touch-punch/jquery.ui.touch-punch.min.js",
                      "~/Content/assets/js/plugin/jquery-scrollbar/jquery.scrollbar.min.js",
                      "~/Content/assets/js/plugin/chart.js/chart.min.js",
                      "~/Content/assets/js/plugin/jquery.sparkline/jquery.sparkline.min.js",
                      "~/Content/assets/js/plugin/chart-circle/circles.min.js",
                      "~/Content/assets/js/plugin/datatables/datatables.min.js",
                      "~/Content/assets/js/plugin/jqvmap/jquery.vmap.min.js",
                      "~/Content/assets/js/plugin/jqvmap/maps/jquery.vmap.world.js",
                      "~/Content/assets/js/atlantis.min.js",
                      "~/Content/assets/js/setting-demo.js",
                      "~/Content/assets/js/demo.js"));
        }
    }
}
