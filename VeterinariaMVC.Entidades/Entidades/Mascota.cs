using System;

namespace VeterinariaMVC.Entidades.Entidades
{
    public class Mascota
    {
        public int MascotaId { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int TipoDeMascotaId { get; set; }
        public TipoDeMascota TipoDeMascota { get; set; }
        public int RazaId { get; set; }
        public Raza Raza { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
    }
}
