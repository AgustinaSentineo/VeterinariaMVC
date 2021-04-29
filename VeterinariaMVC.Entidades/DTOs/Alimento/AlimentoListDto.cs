using System;

namespace VeterinariaMVC.Entidades.DTOs.Alimento
{
    public class AlimentoListDto : ICloneable
    {
        public int AlimentoId { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Clasificacion { get; set; }
        public string RangoEdad { get; set; }
        public decimal PrecioVenta { get; set; }
        public string Imagen { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
