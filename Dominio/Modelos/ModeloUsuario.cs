namespace Dominio.Modelos
{
    public class ModeloUsuario
    {
        public int RowId { get; set; }
        public int IdPerfil { get; set; }
        public string Documento { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
    }
}