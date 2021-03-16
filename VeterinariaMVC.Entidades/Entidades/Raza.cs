namespace VeterinariaMVC.Entidades.Entidades
{
    public class Raza
    {
        public int RazaId { get; set; }
        public string Descripcion { get; set; }
        public int TipoDeMascotaId { get; set; }
        public TipoDeMascota TipoDeMascota { get; set; }
    }
}
