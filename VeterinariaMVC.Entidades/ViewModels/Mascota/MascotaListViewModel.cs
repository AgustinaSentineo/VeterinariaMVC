using System;
using System.ComponentModel.DataAnnotations;

namespace VeterinariaMVC.Entidades.ViewModels.Mascota
{
    public class MascotaListViewModel
    {
        public int MascotaId { get; set; }

        [Display(Name = "Dueño")]
        public string Cliente { get; set; }

        [Display(Name = "Tipo de Mascota")]
        public string TipoDeMascota { get; set; }
        public string Nombre { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaDeNacimiento { get; set; }
    }
}
