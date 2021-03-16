using System.ComponentModel.DataAnnotations;

namespace VeterinariaMVC.Entidades.ViewModels.Provincia
{
    public class ProvinciaEditViewModel
    {
        public int ProvinciaId { get; set; }

        [Required(ErrorMessage ="El campo {0} es requerido")]
        [StringLength(100, ErrorMessage ="El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength =3)]
        [Display(Name = "Nombre de Provincia")]
        public string NombreProvincia { get; set; }
    }
}
