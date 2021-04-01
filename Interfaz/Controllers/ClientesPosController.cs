using Dominio.Modelos;
using Interfaz.Properties;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Interfaz.Controllers
{
    public class ClientesPosController : Controller
    {
        Dominio.FormulariosPublicos.ClientesPos _ClientesPos = new Dominio.FormulariosPublicos.ClientesPos();
        Dominio.Recursos.Combos _Combos = new Dominio.Recursos.Combos();
        Dominio.Recursos.Generar _Generar = new Dominio.Recursos.Generar();
        Infraestructura.CRUD.BDClientesPos _BDClientesPos = new Infraestructura.CRUD.BDClientesPos();

        public async Task<ActionResult> Index()
        {
            Session["Respuesta"] = string.Empty;

            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else if ((int)Session["Perfil"] == 2)
            {
                return await Task.Run(() =>
                {
                    LlenarCombosFiltros();
                    return View(_ClientesPos.Consultar(-1));
                });
            }

            return await Task.Run(() =>
            {
                DataSet DatosImportantes = JsonConvert.DeserializeObject<DataSet>(Session["DatosImportantes"].ToString());
                return View(_ClientesPos.Consultar(Convert.ToInt32(DatosImportantes.Tables[0].Rows[0]["RowId_Usuario"])));
            });
        }

        public async Task<ActionResult> Reportes()
        {
            Session["Respuesta"] = string.Empty;

            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else if ((int)Session["Perfil"] == 2)
            {
                return await Task.Run(() =>
                {
                    LlenarCombosFiltros();
                    return View(_ClientesPos.Consultar(-1));
                });
            }

            return await Task.Run(() =>
            {
                DataSet DatosImportantes = JsonConvert.DeserializeObject<DataSet>(Session["DatosImportantes"].ToString());
                return View(_ClientesPos.Consultar(Convert.ToInt32(DatosImportantes.Tables[0].Rows[0]["RowId_Usuario"])));
            });
        }

        [HttpPost]
        public ActionResult Reportes(string FechaInicio, string FechaFin, int? RowIdTienda, string RowIdCiudad, int? RowIdSexo, int? RowIdEstado, string Control)
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                RecuperarCombosFiltros(RowIdTienda, RowIdCiudad, RowIdSexo, RowIdEstado);
                DataSet DsClientesPos = _ClientesPos.Consultar(RowIdTienda == null ? -1 : RowIdTienda.Value,
                                                   FechaInicio.Replace("-", ""),
                                                   FechaFin.Replace("-", ""),
                                                   RowIdCiudad == "" ? "-1" : RowIdCiudad,
                                                   RowIdSexo == null ? -1 : RowIdSexo.Value,
                                                   RowIdEstado == null ? -1 : RowIdEstado.Value);

                if (Control == null)
                {
                    DataSet DsClientesPosReporte = _ClientesPos.ConsultarReporte(RowIdTienda == null ? -1 : RowIdTienda.Value,
                                                 FechaInicio.Replace("-", ""),
                                                 FechaFin.Replace("-", ""),
                                                 RowIdCiudad == "" ? "-1" : RowIdCiudad,
                                                 RowIdSexo == null ? -1 : RowIdSexo.Value,
                                                 RowIdEstado == null ? -1 : RowIdEstado.Value);

                    _Generar.Excel(DsClientesPosReporte, Settings.Default.RutaExcel);
                    return File(Settings.Default.RutaExcel, "xlsx", "ClientesPos.xlsx");
                }
                else
                {
                    return View(DsClientesPos);
                }
            }
        }

        public ActionResult Consult(string Campos)
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var Modelo = _ClientesPos.EnviarModelo(Campos);

            if (Modelo.Documento != string.Empty && Modelo.Nombre1 != string.Empty)
            {
                Session["Respuesta"] = "CLIENTE ENCONTRADO...";

                RecuperarCombos(Modelo);

                return View("Create", Modelo);
            }

            Session["Respuesta"] = "CLIENTE NO ENCONTRADO...";

            LlenarCombos();

            return View("Create", Modelo);
        }

        public ActionResult Create()
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            LlenarCombos();

            return View();
        }

        [HttpPost]
        public ActionResult Create(ModeloClientesPos Modelo)
        {
            DataSet DatosImportantes = JsonConvert.DeserializeObject<DataSet>(Session["DatosImportantes"].ToString());

            var Respuesta = _ClientesPos.InsertarActualizar(Modelo, Convert.ToInt32(DatosImportantes.Tables[0].Rows[0]["RowId_Usuario"]));

            if (Respuesta.Contains("Importacion exitosa"))
            {
                LlenarCombos();
                Session["Respuesta"] = Respuesta;
                return RedirectToAction("Create");
            }

            RecuperarCombos(Modelo);
            Session["Respuesta"] = Respuesta;
            return View("Create", Modelo);
        }


        public JsonResult GetCities(string RowId)
        {
            return Json(_Combos.ObtenerCiudades(RowId), JsonRequestBehavior.AllowGet);
        }

        private void LlenarCombos()
        {
            ViewBag.ListadoTipoDocumentos = _Combos.Obtener("Sp_Tipos_Documento", "C");
            ViewBag.ListadoDepartamentos = _Combos.Obtener("Sp_Departamentos");
            ViewBag.ListadoCiudades = _Combos.ObtenerCiudades("Sp_Ciudades");
            ViewBag.ListadoSexo = _Combos.Obtener("Sp_Generos");
        }

        private void LlenarCombosFiltros()
        {
            ViewBag.ListadoTiendas = _Combos.Obtener("Sp_Consultar_Tiendas");
            ViewBag.ListadoCiudades = _Combos.Obtener("Sp_Consultar_Ciudades");
            ViewBag.ListadoSexo = _Combos.Obtener("Sp_Generos");
            ViewBag.ListadoEstados = _Combos.Obtener("Sp_Consultar_Estados");
        }

        private void RecuperarCombos(ModeloClientesPos Modelo)
        {
            ViewBag.ListadoTipoDocumentos = _Combos.Obtener("Sp_Tipos_Documento", Modelo.RowIdTipoDocumento);
            ViewBag.ListadoDepartamentos = _Combos.Obtener("Sp_Departamentos", Modelo.RowIdDepartamento);
            ViewBag.ListadoCiudades = _Combos.ObtenerCiudades(Modelo.RowIdDepartamento, Modelo.RowIdCiudad);
            ViewBag.ListadoSexo = _Combos.Obtener("Sp_Generos", Modelo.RowIdSexo);
        }

        private void RecuperarCombosFiltros(int? RowIdTienda, string RowIdCiudad, int? RowIdSexo, int? RowIdEstado)
        {
            if (RowIdTienda != null)
            {
                ViewBag.ListadoTiendas = _Combos.Obtener("Sp_Consultar_Tiendas", RowIdTienda.ToString());
            }
            else
            {
                ViewBag.ListadoTiendas = _Combos.Obtener("Sp_Consultar_Tiendas");
            }

            if (RowIdCiudad != "")
            {
                ViewBag.ListadoCiudades = _Combos.Obtener("Sp_Consultar_Ciudades", RowIdCiudad.ToString());
            }
            else
            {
                ViewBag.ListadoCiudades = _Combos.Obtener("Sp_Consultar_Ciudades");
            }

            if (RowIdSexo != null)
            {
                ViewBag.ListadoSexo = _Combos.Obtener("Sp_Generos", RowIdSexo.ToString());
            }
            else
            {
                ViewBag.ListadoSexo = _Combos.Obtener("Sp_Generos");
            }

            if (RowIdEstado != null)
            {
                ViewBag.ListadoEstados = _Combos.Obtener("Sp_Consultar_Estados", RowIdEstado.ToString());
            }
            else
            {
                ViewBag.ListadoEstados = _Combos.Obtener("Sp_Consultar_Estados");
            }
        }
    }
}