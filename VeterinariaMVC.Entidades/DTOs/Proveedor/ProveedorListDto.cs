using System;

namespace VeterinariaMVC.Entidades.DTOs.Proveedor
{
    public class ProveedorListDto : ICloneable
    {
        public int ProveedorId { get; set; }
        public string CUIT { get; set; }
        public string RazonSocial { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public string CorreoElectronico { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
