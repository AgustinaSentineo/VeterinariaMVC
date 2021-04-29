using System.ComponentModel.DataAnnotations;

namespace VeterinariaMVC.Entidades.ViewModels.Medicamento
{
    public class MedicamentoListViewModel
    {
        public int MedicamentoId { get; set; }

        [Display(Name = "Nombre Comercial")]
        public string NombreComercial { get; set; }

        [Display(Name = "Tipo de Medicamento")]
        public string TipoDeMedicamento { get; set; }

        [Display(Name = "Precio")]
        public decimal PrecioVenta { get; set; }
        public bool Suspendido { get; set; }
        public string Imagen { get; set; }
    }
}
