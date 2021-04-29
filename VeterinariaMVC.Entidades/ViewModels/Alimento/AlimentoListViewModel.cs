using System.ComponentModel.DataAnnotations;

namespace VeterinariaMVC.Entidades.ViewModels.Alimento
{
    public class AlimentoListViewModel
    {
        public int AlimentoId { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Clasificacion { get; set; }

        [Display(Name = "Rango de Edad")]
        public string RangoEdad { get; set; }

        [Display(Name = "Precio de Venta")]
        public decimal PrecioVenta { get; set; }
        public string Imagen { get; set; }
    }
}
