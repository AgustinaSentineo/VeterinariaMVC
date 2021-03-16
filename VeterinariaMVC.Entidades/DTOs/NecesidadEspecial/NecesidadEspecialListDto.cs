using System;

namespace VeterinariaMVC.Entidades.DTOs.NecesidadEspecial
{
    public class NecesidadEspecialListDto : ICloneable
    {
        public int NecesidadesEspecialesId { get; set; }
        public string Descripcion { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
