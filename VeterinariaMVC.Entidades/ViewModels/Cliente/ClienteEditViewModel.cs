using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VeterinariaMVC.Entidades.ViewModels.Localidad;
using VeterinariaMVC.Entidades.ViewModels.Provincia;
using VeterinariaMVC.Entidades.ViewModels.TipoDeDocumento;

namespace VeterinariaMVC.Entidades.ViewModels.Cliente
{
    public class ClienteEditViewModel
    {
        public int ClienteId { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string Nombre { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Tipo De Documento")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un tipo de documento")]
        public int TipoDeDocumentoId { get; set; }

        [Display(Name = "Nro de Documento")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string NroDocumento { get; set; }

        [Display(Name = "Calle")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string Calle { get; set; }
        public string Altura { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Localidad")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una localidad")]
        public int LocalidadId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Provincia")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una provincia")]
        public int ProvinciaId { get; set; }

        [Display(Name = "Celular")]
        public string TelefonoMovil { get; set; }

        [Display(Name = "Telefono Fijo")]
        public string TelefonoFijo { get; set; }
        public string CorreoElectronico { get; set; }

        public List<TipoDeDocumentoListViewModel> TipoDeDocumento { get; set; }
        public List<LocalidadListViewModel> Localidad { get; set; }
        public List<ProvinciaListViewModel> Provincia { get; set; }

    }
}
