using System.ComponentModel.DataAnnotations;

namespace VeterinariaMVC.Entidades.ViewModels.Raza
{
    public class RazaListViewModel
    {
        public int RazaId { get; set; }

        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Display(Name = "Tipo de Mascota")]
        public string TipoDeMascota { get; set; }
    }
}
