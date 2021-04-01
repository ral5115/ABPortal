using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelos
{
    public class ModeloClientesPos
    {
        public int RowId { get; set; }
        public string Documento { get; set; }
        public string RowIdTipoDocumento { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string FechaNacimiento { get; set; }
        public string RH { get; set; }
        public string Direccion { get; set; }
        public string RowIdDepartamento { get; set; }
        public string RowIdCiudad { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }
        public string RowIdSexo { get; set; }
        public int RowIdUsuario { get; set; }
        public string HabeasData { get; set; }
    }
}
