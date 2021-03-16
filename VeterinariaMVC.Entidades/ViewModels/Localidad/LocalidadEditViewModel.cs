using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VeterinariaMVC.Entidades.ViewModels.Provincia;

namespace VeterinariaMVC.Entidades.ViewModels.Localidad
{
    public class LocalidadEditViewModel
    {
        public int LocalidadId { get; set; }

        [Display(Name = "Localidad")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]

        public string NombreLocalidad { get; set; }

       
        [Required(ErrorMessage = "El campo {0} es requerido")] 
        [Display(Name = "Provincia")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una provincia")] 
       
        public int ProvinciaId { get; set; }
        public List<ProvinciaListViewModel> Provincia { get; set; }
    }
}
