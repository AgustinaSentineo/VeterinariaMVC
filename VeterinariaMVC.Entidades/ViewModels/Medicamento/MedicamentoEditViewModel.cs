using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using VeterinariaMVC.Entidades.ViewModels.FormaFarmaceutica;
using VeterinariaMVC.Entidades.ViewModels.Laboratorio;
using VeterinariaMVC.Entidades.ViewModels.TipoDeMedicamento;

namespace VeterinariaMVC.Entidades.ViewModels.Medicamento
{
    public class MedicamentoEditViewModel
    {
        public int MedicamentoId { get; set; }

        [Display(Name = "Nombre Comercial")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string NombreComercial { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Tipo de Medicamento")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un tipo de producto")]
        public int TipoDeMedicamentoId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Forma Farmaceutica")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un tipo de producto")]
        public int FormaFarmaceuticaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Laboratorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un tipo de producto")]
        public int LaboratorioId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Precio de Venta")]
        [Range(1, int.MaxValue, ErrorMessage = "El precio debe ser positivo")]
        public decimal PrecioVenta { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Unidades en Stock")]
        [Range(1, int.MaxValue, ErrorMessage = "El stock debe ser positivo")]
        public int UnidadesEnStock { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nivel de Reposicion")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe ser positivo")]
        public int NivelDeReposicion { get; set; }

        [Display(Name = "Cantidades por Unidad")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 2)]
        public string CantidadesPorUnidad { get; set; }
        public bool Suspendido { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Imagen { get; set; }

        public HttpPostedFileBase ImagenFile { get; set; }
        public List<TipoDeMedicamentoListViewModel> TipoDeMedicamento { get; set; }
        public List<FormaFarmaceuticaListViewModel> FormaFarmaceutica { get; set; }
        public List<LaboratorioListViewModel> Laboratorio { get; set; }
    }
}
