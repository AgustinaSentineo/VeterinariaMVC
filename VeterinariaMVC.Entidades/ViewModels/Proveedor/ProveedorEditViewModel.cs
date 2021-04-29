using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VeterinariaMVC.Entidades.ViewModels.Localidad;
using VeterinariaMVC.Entidades.ViewModels.Provincia;
using VeterinariaMVC.Entidades.ViewModels.TipoDeDocumento;

namespace VeterinariaMVC.Entidades.ViewModels.Proveedor
{
    public class ProveedorEditViewModel
    {
        public int ProveedorId { get; set; }

        [Display(Name = "CUIT")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string CUIT { get; set; }

        [Display(Name = "Razon Social")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string RazonSocial { get; set; }

        [Display(Name = "Persona de Contacto")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string PersonaDeContacto { get; set; }

        [Display(Name = "Calle")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string Calle { get; set; }
        public string Altura { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Provincia")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una provincia")]
        public int ProvinciaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Localidad")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una localidad")]
        public int LocalidadId { get; set; }

        [Display(Name = "Celular")]
        public string TelefonoMovil { get; set; }

        [Display(Name = "Telefono Fijo")]
        public string TelefonoFijo { get; set; }
        public string CorreoElectronico { get; set; }
        public List<LocalidadListViewModel> Localidad { get; set; }
        public List<ProvinciaListViewModel> Provincia { get; set; }
    }
}
