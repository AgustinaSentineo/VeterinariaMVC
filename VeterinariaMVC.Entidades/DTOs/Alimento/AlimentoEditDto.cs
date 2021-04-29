namespace VeterinariaMVC.Entidades.DTOs.Alimento
{
    public class AlimentoEditDto
    {
        public int AlimentoId { get; set; }
        public string Nombre { get; set; }       
        public int TipoDeAlimentoId { get; set; }
        public int ClasificacionId { get; set; }
        public int TipoDeMascotaId { get; set; }
        public string RangoEdad { get; set; }
        public int NecesidadesEspecialesId { get; set; }
        public int MarcaId { get; set; } 
        public string Cantidad { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PrecioCompra { get; set; }        
        public int Stock { get; set; }
        public string Imagen { get; set; }
    }
}
