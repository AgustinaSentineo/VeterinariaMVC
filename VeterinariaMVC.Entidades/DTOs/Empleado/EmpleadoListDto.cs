using System;

namespace VeterinariaMVC.Entidades.DTOs.Empleado
{
    public class EmpleadoListDto : ICloneable
    {
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CorreoElectronico { get; set; }
        public string TipoDeTarea { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
