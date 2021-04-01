using System.Data;
using System.IO;
using System.Text;

namespace Dominio.Recursos
{
    public class Deserealizar
    {
        public string XML(string RespuestaERP)
        {
            DataSet DsErrores = new DataSet();
            StringBuilder ErrorSiesaDescompuesto = new StringBuilder();

            if (RespuestaERP.Contains("<NewDataSet>"))
            {
                RespuestaERP = RespuestaERP.Substring(RespuestaERP.ToString().IndexOf("<NewDataSet>"), 13 + RespuestaERP.ToString().IndexOf("</NewDataSet>") - RespuestaERP.ToString().IndexOf("<NewDataSet>"));
                StringReader _StringReader = new StringReader(RespuestaERP);
                DsErrores.ReadXml(_StringReader, XmlReadMode.Auto);

                foreach (DataRow FilaError in DsErrores.Tables[0].Rows)
                {
                    ErrorSiesaDescompuesto.AppendLine(FilaError["f_detalle"].ToString() + "\r\n");
                }

                return ErrorSiesaDescompuesto.ToString();
            }
            else
            {
                return RespuestaERP;
            }
        }
    }
}
