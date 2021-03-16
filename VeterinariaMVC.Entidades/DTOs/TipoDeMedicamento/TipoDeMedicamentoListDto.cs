using System;

namespace VeterinariaMVC.Entidades.DTOs.TipoDeMedicamento
{
    public class TipoDeMedicamentoListDto:ICloneable
    {
        public int TipoDeMedicamentoId { get; set; }
        public string Descripcion { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
