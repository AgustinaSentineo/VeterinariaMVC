using System;

namespace VeterinariaMVC.Entidades.DTOs.Clasificacion
{
    public class ClasificacionListDto:ICloneable
    {
        public int ClasificacionId { get; set; }
        public string Descripcion { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
