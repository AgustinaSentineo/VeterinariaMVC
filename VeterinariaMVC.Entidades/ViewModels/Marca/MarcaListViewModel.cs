using System.ComponentModel.DataAnnotations;

namespace VeterinariaMVC.Entidades.ViewModels.Marca
{
    public class MarcaListViewModel
    {
        public int MarcaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
    }
}
