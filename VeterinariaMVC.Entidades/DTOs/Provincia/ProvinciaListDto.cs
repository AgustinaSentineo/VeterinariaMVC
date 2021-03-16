using System;

namespace VeterinariaMVC.Entities.DTOs.Provincia
{
    public class ProvinciaListDto:ICloneable
    {
        public int ProvinciaId { get; set; }
        public string NombreProvincia { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
