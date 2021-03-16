using System;

namespace VeterinariaMVC.Entidades.DTOs.Marca
{
    public class MarcaListDto:ICloneable
    {
        public int MarcaId { get; set; }

        public string Nombre { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
