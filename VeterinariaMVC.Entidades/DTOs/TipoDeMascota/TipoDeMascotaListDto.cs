using System;

namespace VeterinariaMVC.Entidades.DTOs.TipoDeMascota
{
    public class TipoDeMascotaListDto:ICloneable
    {
        public int TipoDeMascotaId { get; set; }
        public string Descripcion { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
