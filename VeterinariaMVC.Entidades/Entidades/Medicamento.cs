namespace VeterinariaMVC.Entidades.Entidades
{
    public class Medicamento
    {
        public int MedicamentoId { get; set; }
        public string NombreComercial { get; set; }
        public int TipoDeMedicamentoId { get; set; }
        public TipoDeMedicamento TipoDeMedicamento { get; set; }
        public int FormaFarmaceuticaId { get; set; }
        public FormaFarmaceutica FormaFarmaceutica { get; set; }
        public int LaboratorioId { get; set; }
        public Laboratorio Laboratorio { get; set; }
        public decimal PrecioVenta { get; set; }
        public int UnidadesEnStock { get; set; }
        public int NivelDeReposicion { get; set; }
        public string CantidadesPorUnidad { get; set; }
        public bool Suspendido { get; set; }
        public string Imagen { get; set; }
    }
}
