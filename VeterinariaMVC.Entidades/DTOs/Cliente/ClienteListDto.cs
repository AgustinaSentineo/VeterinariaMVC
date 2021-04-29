using System;

namespace VeterinariaMVC.Entidades.DTOs.Cliente
{
    public class ClienteListDto : ICloneable
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }   
        public string Calle { get; set; }
        public string Altura { get; set; }
        public string CorreoElectronico { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
