using System.ComponentModel.DataAnnotations;

namespace VeterinariaMVC.Entidades.ViewModels.NecesidadEspecial
{
    public class NecesidadEspecialListViewModel
    {
        public int NecesidadesEspecialesId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 5)]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
    }
}
