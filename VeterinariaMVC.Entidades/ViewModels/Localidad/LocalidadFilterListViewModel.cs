using System.Collections.Generic;
using VeterinariaMVC.Entidades.ViewModels.Provincia;

namespace VeterinariaMVC.Entidades.ViewModels.Localidad
{
    public class LocalidadFilterListViewModel
    {
        public List<LocalidadListViewModel> Localidad { get; set; }
        public List<ProvinciaListViewModel> Provincia { get; set; }

    }
}
