using System;

namespace VeterinariaMVC.Entidades.DTOs.Raza
{
    public class RazaListDto:ICloneable
    {
        public int RazaId { get; set; }
        public string Descripcion { get; set; }
        public string TipoDeMascota { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
