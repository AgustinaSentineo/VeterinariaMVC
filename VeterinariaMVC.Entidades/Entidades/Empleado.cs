namespace VeterinariaMVC.Entidades.Entidades
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int TipoDeDocumentoId { get; set; }
        public TipoDeDocumento TipoDeDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string Calle { get; set; }
        public string Altura { get; set; }
        public int LocalidadId { get; set; }
        public Localidad Localidad { get; set; }
        public int ProvinciaId { get; set; }
        public Provincia Provincia { get; set; }
        public string TelefonoMovil { get; set; }
        public string TelefonoFijo { get; set; }
        public string CorreoElectronico { get; set; }
        public int TipoDeTareaId { get; set; }
        public TipoDeTarea TipoDeTarea { get; set; }
    }
}
