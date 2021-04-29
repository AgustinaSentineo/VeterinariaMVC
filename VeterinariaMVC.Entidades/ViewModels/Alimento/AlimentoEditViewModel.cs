using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using VeterinariaMVC.Entidades.ViewModels.Clasificacion;
using VeterinariaMVC.Entidades.ViewModels.Marca;
using VeterinariaMVC.Entidades.ViewModels.NecesidadEspecial;
using VeterinariaMVC.Entidades.ViewModels.TipoDeAlimento;
using VeterinariaMVC.Entidades.ViewModels.TipoDeMascota;

namespace VeterinariaMVC.Entidades.ViewModels.Alimento
{
    public class AlimentoEditViewModel
    {
        public int AlimentoId { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Marca")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un tipo de producto")]
        public int MarcaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Tipo de Alimento")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un tipo de producto")]
        public int TipoDeAlimentoId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Tipo de Mascota")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un tipo de producto")]
        public int TipoDeMascotaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Clasificacion")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un tipo de producto")]
        public int ClasificacionId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Necesidades Especiales")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un tipo de producto")]
        public int NecesidadesEspecialesId { get; set; }

        [Display(Name = "Rango de Edad")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string RangoEdad { get; set; }

        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string Cantidad { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Precio de Compra")]
        [Range(1, int.MaxValue, ErrorMessage = "El precio debe ser positivo")]
        public decimal PrecioCompra { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Precio de Venta")]
        [Range(1, int.MaxValue, ErrorMessage = "El precio debe ser positivo")]
        public decimal PrecioVenta { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El precio debe ser positivo")]
        public int Stock { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Imagen { get; set; }

        public HttpPostedFileBase ImagenFile { get; set; }

        public List<MarcaListViewModel> Marca { get; set; }
        public List<TipoDeAlimentoListViewModel> TipoDeAlimento { get; set; }
        public List<TipoDeMascotaListViewModel> TipoDeMascota { get; set; }
        public List<NecesidadEspecialListViewModel> NecesidadesEspeciales { get; set; }
        public List<ClasificacionListViewModel> Clasificacion { get; set; }

    }
}
