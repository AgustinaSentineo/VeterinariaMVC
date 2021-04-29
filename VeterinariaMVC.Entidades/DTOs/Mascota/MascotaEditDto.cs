using System;

namespace VeterinariaMVC.Entidades.DTOs.Mascota
{
    public class MascotaEditDto
    {
        public int MascotaId { get; set; }
        public int ClienteId { get; set; }
        public int TipoDeMascotaId { get; set; }
        public int RazaId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
    }
}
