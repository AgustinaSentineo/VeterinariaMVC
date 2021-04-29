using System.ComponentModel.DataAnnotations;

namespace VeterinariaMVC.Entidades.ViewModels.Empleado
{
    public class EmpleadoListViewModel
    {
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        [Display(Name = "Email")]
        public string CorreoElectronico { get; set; }

        [Display(Name = "Tipo de Tarea")]
        public string TipoDeTarea { get; set; }
    }
}
