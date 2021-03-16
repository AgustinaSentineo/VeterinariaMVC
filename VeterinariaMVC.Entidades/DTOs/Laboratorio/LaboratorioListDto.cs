using System;

namespace VeterinariaMVC.Entidades.DTOs.Laboratorio
{
    public class LaboratorioListDto:ICloneable
    {
        public int LaboratorioId { get; set; }
        public string Descripcion { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
