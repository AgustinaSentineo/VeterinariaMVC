using System.ComponentModel.DataAnnotations;

namespace VeterinariaMVC.Entidades.ViewModels.Localidad
{
    public class LocalidadListViewModel
    {
        public int LocalidadId { get; set; }

        [Display (Name ="Localidad")]
        public string NombreLocalidad { get; set; }

        [Display(Name = "Provincia")]
        public string Provincia { get; set; }
    }
}
