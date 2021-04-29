using System;

namespace VeterinariaMVC.Entidades.DTOs.Medicamento
{
    public class MedicamentoListDto : ICloneable
    {
        public int MedicamentoId { get; set; }
        public string NombreComercial { get; set; }
        public string TipoDeMedicamento { get; set; }
        public decimal PrecioVenta { get; set; }
        public bool Suspendido { get; set; }
        public string Imagen { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
