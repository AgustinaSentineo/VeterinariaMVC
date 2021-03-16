using System;

namespace VeterinariaMVC.Entidades.DTOs.Localidad
{
    public class LocalidadListDto:ICloneable
    {
        public int LocalidadId { get; set; }
        public string NombreLocalidad { get; set; }
        public string Provincia { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
