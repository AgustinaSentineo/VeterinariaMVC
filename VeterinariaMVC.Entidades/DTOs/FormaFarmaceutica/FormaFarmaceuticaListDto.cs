using System;

namespace VeterinariaMVC.Entidades.DTOs.FormaFarmaceutica
{
    public class FormaFarmaceuticaListDto:ICloneable
    {
        public int FormaFarmaceuticaId { get; set; }
        public string Descripcion { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
