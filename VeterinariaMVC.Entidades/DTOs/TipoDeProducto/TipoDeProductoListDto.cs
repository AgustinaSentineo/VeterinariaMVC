using System;

namespace VeterinariaMVC.Entidades.DTOs.TipoDeProducto
{
    public class TipoDeProductoListDto:ICloneable
    {
        public int TipoDeProductoId { get; set; }

        public string Descripcion { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
