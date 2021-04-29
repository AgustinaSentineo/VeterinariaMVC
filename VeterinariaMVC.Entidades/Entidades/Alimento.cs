namespace VeterinariaMVC.Entidades.Entidades
{
    public class Alimento
    {
        public int AlimentoId { get; set; }
        public string Nombre { get; set; } 
        public int TipoDeAlimentoId { get; set; }
        public TipoDeAlimento TipoDeAlimento { get; set; }
        public int ClasificacionId { get; set; }
        public Clasificacion Clasificacion { get; set; }
        public int TipoDeMascotaId { get; set; }
        public TipoDeMascota TipoDeMascota { get; set; }
        public string RangoEdad { get; set; }                
        public int NecesidadesEspecialesId { get; set; }
        public NecesidadesEspeciales NecesidadesEspeciales { get; set; }
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }        
        public string Cantidad { get; set; }        
        public decimal PrecioVenta { get; set; }
        public decimal PrecioCompra { get; set; }
        public int Stock { get; set; }
        public string Imagen { get; set; }
    }
}
