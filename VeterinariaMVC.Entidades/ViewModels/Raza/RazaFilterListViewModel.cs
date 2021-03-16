using System.Collections.Generic;
using VeterinariaMVC.Entidades.ViewModels.TipoDeMascota;

namespace VeterinariaMVC.Entidades.ViewModels.Raza
{
    public class RazaFilterListViewModel
    {
        public List<RazaListViewModel> Raza { get; set; }
        public List<TipoDeMascotaListViewModel> TipoDeMascota { get; set; }
    }
}
