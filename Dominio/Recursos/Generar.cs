using SpreadsheetLight;
using System.Data;

namespace Dominio.Recursos
{
    public class Generar
    {
        public void Excel(DataSet DsClientesPos, string Ruta)
        {
            SLDocument _SLDocument = new SLDocument();
            _SLDocument.ImportDataTable(1, 1, DsClientesPos.Tables[0], true);
            _SLDocument.SaveAs(Ruta);
        }
    }
}
