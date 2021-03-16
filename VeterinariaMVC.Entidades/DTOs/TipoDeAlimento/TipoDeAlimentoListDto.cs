using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinariaMVC.Entidades.DTOs.TipoDeAlimento
{
    public class TipoDeAlimentoListDto : ICloneable
    {
        public int TipoDeAlimentoId { get; set; }
        public string Descripcion { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
