using System;

namespace VeterinariaMVC.Entidades.DTOs.TipoDeTarea
{
    public class TipoDeTareaListDto:ICloneable
    {
        public int TipoDeTareaId { get; set; }

        public string Descripcion { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
