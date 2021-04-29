using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using VeterinariaMVC.Entidades.ViewModels.Marca;
using VeterinariaMVC.Entidades.ViewModels.TipoDeProducto;

namespace VeterinariaMVC.Entidades.ViewModels.Producto
{
    public class ProductoEditViewModel
    {
        public int ProductoId { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Tipo de Producto")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un tipo de producto")]
        public int TipoDeProductoId { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Marca")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una marca")]
        public int MarcaId { get; set; }

        [Display(Name = "Modelo")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string Modelo { get; set; }

        [Display(Name = "Descripción")]
        [StringLength(50, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El precio debe ser positivo")]
        public decimal PrecioCompra { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El precio debe ser positivo")]
        public decimal PrecioVenta { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El stock debe ser positivo")]
        public int Stock { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Imagen { get; set; }

        public HttpPostedFileBase ImagenFile { get; set; }
        public List<TipoDeProductoListViewModel> TipoProducto { get; set; }
        public List<MarcaListViewModel> Marca { get; set; }
    }
}
