using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VeterinariaMVC.Entidades.ViewModels.Cliente;
using VeterinariaMVC.Entidades.ViewModels.Raza;
using VeterinariaMVC.Entidades.ViewModels.TipoDeMascota;

namespace VeterinariaMVC.Entidades.ViewModels.Mascota
{
    public class MascotaEditViewModel
    {
        public int MascotaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Dueño")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un dueño")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Tipo de Mascota")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una tipo de mascota")]
        public int TipoDeMascotaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Raza")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una raza")]
        public int RazaId { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string Nombre { get; set; }
        public DateTime FechaDeNacimiento { get; set; }

        public List<TipoDeMascotaListViewModel> TipoDeMascota { get; set; }
        public List<RazaListViewModel> Raza { get; set; }
        public List<ClienteListViewModel> Cliente { get; set; }
    }
}
