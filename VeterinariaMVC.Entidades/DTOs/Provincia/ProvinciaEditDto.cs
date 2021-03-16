using System.ComponentModel.DataAnnotations;

namespace VeterinariaMVC.Entities.DTOs.Provincia
{
    public class ProvinciaEditDto
    {
        public int ProvinciaId { get; set; }

        [Display (Name = "NombreProvincia")]
        public string NombreProvincia { get; set; }
    }
}
