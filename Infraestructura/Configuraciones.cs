namespace Infraestructura
{
    public class Configuraciones
    {
        public static string ConexionPortal = "data source=localhost;initial catalog=Integracion-Coordinadora;user id=sa;password=siesa-123";

        public static string ConexionNacional = "data source=172.17.50.4;initial catalog=Integracion-VTEX;user id=sa;password=Sa123456";

        public static string ConexionInternacional = "data source=172.17.50.4;initial catalog=Integracion-VTEX-Internacional;user id=sa;password=Sa123456";

        public static Ws_GTReal.wsGenerarPlano ObjGeneric = new Ws_GTReal.wsGenerarPlano();

        public static string CorreoEmpresa = "";

        public static string ClaveEmpresa = "";

        public static string RutaPlanoReal = @"C:\inetpub\wwwroot\GTIntegration\Planos\";

        public static string RutaPlanoPruebas = @"C:\inetpub\wwwroot\GTIntegrationPruebas\Planos\";

        public static string RutaHTMLLocal = @"C:\Users\Usuario\Documents\Codigo Fuente\Integracion Agua Bendita Portal VTEX\Interfaz\Content\html\HTML.txt";

        public static string RutaHTMLServidor = @"C:\inetpub\wwwroot\Portal-VTEX\Html\HTML.txt";
    }
}
