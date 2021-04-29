using System;

namespace VeterinariaMVC.Entidades.DTOs.Mascota
{
    public class MascotaListDto : ICloneable
    {
        public int MascotaId { get; set; }
        public string Cliente { get; set; }
        public string TipoDeMascota { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaDeNacimiento { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
