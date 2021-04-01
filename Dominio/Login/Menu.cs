using Infraestructura.CRUD;
using System;
using System.Data;

namespace Dominio.Login
{
    public class Menu
    {
        private readonly BDLogin _BDLogin = new BDLogin();
        public string Obtener(int RowId_Perfil, string ColorBoton, string ColorTextoBoton)
        {
            DataSet DsMenu = _BDLogin.Sp_Admin_Menu(RowId_Perfil);
            return CrearMenu(RowId_Perfil, DsMenu, ColorBoton, ColorTextoBoton);
        }

        private string CrearMenu(int RowId_Perfil, DataSet DsMenu, string ColorBoton, string ColorTextoBoton)
        {
            var Menu = "";
            int Contador = 0;
            Menu += "<ul class=\"nav nav-primary\">";
            Menu += "<li id=\"Elemento\" class=\"nav-item active\">";

            foreach (DataRow RegistroMenu in DsMenu.Tables[0].Rows)
            {

                if (RegistroMenu["Descripcion"].ToString() == "Administracion")
                {
                    Menu += "<a data-toggle=\"collapse\" href=\"#dashboard\" class=\"collapsed\" aria-expanded=\"false\" style=\"" + ColorBoton + ";" + ColorTextoBoton + "\" > ";
                    Menu += "<i class=\"" + RegistroMenu["Icono"].ToString() + "\"></i>";
                    Menu += "<p>" + RegistroMenu["Descripcion"].ToString() + "</p>";
                    Menu += "<span class=\"caret\"></span>";
                    Menu += "</a>";
                    Menu += "<div class=\"collapse\" id=\"dashboard\">";
                    Menu += "<ul class=\"nav nav-collapse\">";
                    Menu += "<li>";

                    DataSet DsSubMenu = _BDLogin.Sp_Admin_SubMenu(RowId_Perfil, (int)RegistroMenu["RowId"]);

                    foreach (DataRow RegistroSubMenu in DsSubMenu.Tables[0].Rows)
                    {
                        Menu += "<a href=\"/" + RegistroSubMenu["Controlador"].ToString() + "\">";
                        Menu += "<span class=\"sub-item\">" + RegistroSubMenu["DescripcionHijo"].ToString() + "</span>";
                        Menu += "</a>";
                    }

                    Menu += "</li>";
                    Menu += "</ul>";
                    Menu += "</div>";
                    Menu += "</li>";
                }
                else
                {
                    Contador++;

                    if (Contador == 1)
                    {
                        Menu += "<li class=\"nav-section\">";
                        Menu += "<span class=\"sidebar-mini-icon\">";
                        Menu += "<i class=\"fa fa-ellipsis-h\"></i>";
                        Menu += "</span>";
                        Menu += "<h4 class=\"text-section\">Formularios Publicos</h4>";
                        Menu += "</li>";
                    }

                    Menu += "<li class=\"nav-item\">";
                    Menu += "<a data-toggle=\"collapse\" href=\"#subMenu" + Contador.ToString() + "\">";
                    Menu += "<i class=\"" + RegistroMenu["Icono"].ToString() + "\"></i>";
                    Menu += "<p>" + RegistroMenu["Descripcion"].ToString() + "</p>";
                    Menu += "<span class=\"caret\"></span>";
                    Menu += "</a>";
                    Menu += "<div class=\"collapse\" id=\"subMenu" + Contador.ToString() + "\">";
                    Menu += "<ul class=\"nav nav-collapse\">";
                    Menu += "<li>";

                    DataSet DsSubMenu = _BDLogin.Sp_Admin_SubMenu(RowId_Perfil, (int)RegistroMenu["RowId"]);

                    foreach (DataRow RegistroSubMenu in DsSubMenu.Tables[0].Rows)
                    {
                        Menu += "<a href=\"/" + RegistroSubMenu["Controlador"].ToString() + "\">";
                        Menu += "<span class=\"sub-item\">" + RegistroSubMenu["DescripcionHijo"].ToString() + "</span>";
                        Menu += "</a>";
                    }

                    Menu += "</li>";
                    Menu += "</ul>";
                    Menu += "</div>";
                }
            }
            Menu += "</li>";
            Menu += "</ul>";

            if (Menu == "<ul class=\"nav nav-primary\"><li id=\"Elemento\" class=\"nav-item active\"></li></ul>")
            {
                return "Error";
            }

            return Menu;
        }
    }
}
