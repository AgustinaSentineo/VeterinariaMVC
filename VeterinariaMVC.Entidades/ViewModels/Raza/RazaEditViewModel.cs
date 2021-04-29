using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinariaMVC.Entidades.ViewModels.TipoDeMascota;

namespace VeterinariaMVC.Entidades.ViewModels.Raza
{
    public class RazaEditViewModel
    {
        public int RazaId { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Tipo de Mascota")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un tipo de mascota")]
        public int TipoDeMascotaId { get; set; }

        public List<TipoDeMascotaListViewModel> TipoDeMascota { get; set; }
    }
}
