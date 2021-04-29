using AutoMapper;
using System;
using VeterinariaMVC.Entidades.DTOs.Alimento;
using VeterinariaMVC.Entidades.DTOs.Clasificacion;
using VeterinariaMVC.Entidades.DTOs.Cliente;
using VeterinariaMVC.Entidades.DTOs.Empleado;
using VeterinariaMVC.Entidades.DTOs.FormaFarmaceutica;
using VeterinariaMVC.Entidades.DTOs.Laboratorio;
using VeterinariaMVC.Entidades.DTOs.Localidad;
using VeterinariaMVC.Entidades.DTOs.Marca;
using VeterinariaMVC.Entidades.DTOs.Mascota;
using VeterinariaMVC.Entidades.DTOs.Medicamento;
using VeterinariaMVC.Entidades.DTOs.NecesidadEspecial;
using VeterinariaMVC.Entidades.DTOs.Producto;
using VeterinariaMVC.Entidades.DTOs.Proveedor;
using VeterinariaMVC.Entidades.DTOs.Raza;
using VeterinariaMVC.Entidades.DTOs.TipoDeAlimento;
using VeterinariaMVC.Entidades.DTOs.TipoDeDocumento;
using VeterinariaMVC.Entidades.DTOs.TipoDeMascota;
using VeterinariaMVC.Entidades.DTOs.TipoDeMedicamento;
using VeterinariaMVC.Entidades.DTOs.TipoDeProducto;
using VeterinariaMVC.Entidades.DTOs.TipoDeTarea;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Entidades.ViewModels.Alimento;
using VeterinariaMVC.Entidades.ViewModels.Clasificacion;
using VeterinariaMVC.Entidades.ViewModels.Cliente;
using VeterinariaMVC.Entidades.ViewModels.Empleado;
using VeterinariaMVC.Entidades.ViewModels.FormaFarmaceutica;
using VeterinariaMVC.Entidades.ViewModels.Laboratorio;
using VeterinariaMVC.Entidades.ViewModels.Localidad;
using VeterinariaMVC.Entidades.ViewModels.Marca;
using VeterinariaMVC.Entidades.ViewModels.Mascota;
using VeterinariaMVC.Entidades.ViewModels.Medicamento;
using VeterinariaMVC.Entidades.ViewModels.NecesidadEspecial;
using VeterinariaMVC.Entidades.ViewModels.Producto;
using VeterinariaMVC.Entidades.ViewModels.Proveedor;
using VeterinariaMVC.Entidades.ViewModels.Provincia;
using VeterinariaMVC.Entidades.ViewModels.Raza;
using VeterinariaMVC.Entidades.ViewModels.TipoDeAlimento;
using VeterinariaMVC.Entidades.ViewModels.TipoDeDocumento;
using VeterinariaMVC.Entidades.ViewModels.TipoDeMascota;
using VeterinariaMVC.Entidades.ViewModels.TipoDeMedicamento;
using VeterinariaMVC.Entidades.ViewModels.TipoDeProducto;
using VeterinariaMVC.Entidades.ViewModels.TipoDeTarea;
using VeterinariaMVC.Entities.DTOs.Provincia;

namespace VeterinariaMVC.Mappeador
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            LoadMappingProvincia();
            LoadMappingFormaFarmaceutica();
            LoadMappingLaboratorio();
            LoadMappingTipoDeDocumento();
            LoadMappingTipoDeMascota();
            LoadMappingTipoDeMedicamento();
            LoadMappingTipoDeProducto();
            LoadMappingMarca();
            LoadMappingTipoDeTarea();
            LoadMappingLocalidad();
            LoadMappingRaza();
            LoadMappingTipoDeAlimento();
            LoadMappingClasificacion();
            LoadMappingNecesidadEspecial();
            LoadMappingCliente();
            LoadMappingEmpleado();
            LoadMappingMascota();
            LoadMappingProveedor();
            LoadMappingProducto();
            LoadMappingAlimento();
            LoadMappingMedicamento();
        }

        private void LoadMappingMedicamento()
        {
            CreateMap<Medicamento, MedicamentoListDto>();
            CreateMap<Medicamento, MedicamentoEditDto>().ReverseMap();
            CreateMap<MedicamentoListDto, MedicamentoListViewModel>().ReverseMap();
            CreateMap<MedicamentoEditDto, MedicamentoEditViewModel>().ReverseMap();
            CreateMap<MedicamentoEditDto, MedicamentoListDto>().ReverseMap();
        }

        private void LoadMappingAlimento()
        {
            CreateMap<Alimento, AlimentoListDto>();
            CreateMap<Alimento, AlimentoEditDto>().ReverseMap();
            CreateMap<AlimentoListDto, AlimentoListViewModel>().ReverseMap();
            CreateMap<AlimentoEditDto, AlimentoEditViewModel>().ReverseMap();
            CreateMap<AlimentoEditDto, AlimentoListDto>().ReverseMap();
        }

        private void LoadMappingProducto()
        {
            CreateMap<Producto, ProductoListDto>();
            CreateMap<Producto, ProductoEditDto>().ReverseMap();
            CreateMap<ProductoListDto, ProductoListViewModel>().ReverseMap();
            CreateMap<ProductoEditDto, ProductoEditViewModel>().ReverseMap();
            CreateMap<ProductoEditDto, ProductoListDto>().ReverseMap();
        }

        private void LoadMappingProveedor()
        {
            CreateMap<Proveedor, ProveedorListDto>();
            CreateMap<Proveedor, ProveedorEditDto>().ReverseMap();
            CreateMap<ProveedorListDto, ProveedorListViewModel>().ReverseMap();
            CreateMap<ProveedorEditDto, ProveedorEditViewModel>().ReverseMap();
            CreateMap<ProveedorEditDto, ProveedorListDto>().ReverseMap();
        }

        private void LoadMappingMascota()
        {
            CreateMap<Mascota, MascotaListDto>();
            CreateMap<Mascota, MascotaEditDto>().ReverseMap();
            CreateMap<MascotaListDto, MascotaListViewModel>().ReverseMap();
            CreateMap<MascotaEditDto, MascotaEditViewModel>().ReverseMap();
            CreateMap<MascotaEditDto, MascotaListDto>().ReverseMap();
        }

        private void LoadMappingEmpleado()
        {
            CreateMap<Empleado, EmpleadoListDto>();
               
            CreateMap<Empleado, EmpleadoEditDto>().ReverseMap();
            CreateMap<EmpleadoListDto, EmpleadoListViewModel>().ReverseMap();
            CreateMap<EmpleadoEditDto, EmpleadoEditViewModel>().ReverseMap();
            CreateMap<EmpleadoEditDto, EmpleadoListDto>()
                .ReverseMap();
        }

        private void LoadMappingCliente()
        {
            CreateMap<Cliente, ClienteListDto>();
               
            CreateMap<Cliente, ClienteEditDto>().ReverseMap();
            CreateMap<ClienteListDto, ClienteListViewModel>().ReverseMap();
            CreateMap<ClienteEditDto, ClienteEditViewModel>().ReverseMap();
            CreateMap<ClienteEditDto, ClienteListDto>()
                .ReverseMap();
        }

        private void LoadMappingNecesidadEspecial()
        {
            CreateMap<NecesidadesEspeciales, NecesidadEspecialListDto>();
            CreateMap<NecesidadesEspeciales, NecesidadEspecialEditDto>().ReverseMap();
            CreateMap<NecesidadEspecialListDto, NecesidadEspecialListViewModel>().ReverseMap();
            CreateMap<NecesidadEspecialEditDto, NecesidadEspecialEditViewModel>().ReverseMap();
            CreateMap<NecesidadEspecialEditDto, NecesidadEspecialListDto>().ReverseMap();
        }

        private void LoadMappingClasificacion()
        {
            CreateMap<Clasificacion, ClasificacionListDto>();
            CreateMap<Clasificacion, ClasificacionEditDto>().ReverseMap();
            CreateMap<ClasificacionListDto, ClasificacionListViewModel>().ReverseMap();
            CreateMap<ClasificacionEditDto, ClasificacionEditViewModel>().ReverseMap();
            CreateMap<ClasificacionEditDto, ClasificacionListDto>().ReverseMap();
        }

        private void LoadMappingTipoDeAlimento()
        {
            CreateMap<TipoDeAlimento, TipoDeAlimentoListDto>();
            CreateMap<TipoDeAlimento, TipoDeAlimentoEditDto>().ReverseMap();
            CreateMap<TipoDeAlimentoListDto, TipoDeAlimentoListViewModel>().ReverseMap();
            CreateMap<TipoDeAlimentoEditDto, TipoDeAlimentoEditViewModel>().ReverseMap();
            CreateMap<TipoDeAlimentoEditDto, TipoDeAlimentoListDto>().ReverseMap();
        }

        private void LoadMappingRaza()
        {
            CreateMap<Raza, RazaListDto>();
            CreateMap<Raza, RazaEditDto>().ReverseMap();
            CreateMap<RazaListDto, RazaListViewModel>().ReverseMap();
            CreateMap<RazaEditDto, RazaEditViewModel>().ReverseMap();
            CreateMap<RazaEditDto, RazaListDto>().ReverseMap();
        }

        private void LoadMappingLocalidad()
        {
            CreateMap<Localidad, LocalidadListDto>();
            CreateMap<Localidad, LocalidadEditDto>().ReverseMap();
            CreateMap<LocalidadListDto, LocalidadListViewModel>().ReverseMap();
            CreateMap<LocalidadEditDto, LocalidadEditViewModel>().ReverseMap();
            CreateMap<LocalidadEditDto, LocalidadListDto>().ReverseMap();
        }

        private void LoadMappingTipoDeTarea()
        {
            CreateMap<TipoDeTarea, TipoDeTareaListDto>();
            CreateMap<TipoDeTarea, TipoDeTareaEditDto>().ReverseMap();
            CreateMap<TipoDeTareaListDto, TipoDeTareaListViewModel>().ReverseMap();
            CreateMap<TipoDeTareaEditDto, TipoDeTareaEditViewModel>().ReverseMap();
            CreateMap<TipoDeTareaEditDto, TipoDeTareaListDto>().ReverseMap();
        }

        private void LoadMappingMarca()
        {
            CreateMap<Marca, MarcaListDto>();
            CreateMap<Marca, MarcaEditDto>().ReverseMap();
            CreateMap<MarcaListDto, MarcaListViewModel>().ReverseMap();
            CreateMap<MarcaEditDto, MarcaEditViewModel>().ReverseMap();
            CreateMap<MarcaEditDto, MarcaListDto>().ReverseMap();
        }

        private void LoadMappingTipoDeProducto()
        {
            CreateMap<TipoDeProducto, TipoDeProductoListDto>();
            CreateMap<TipoDeProducto, TipoDeProductoEditDto>().ReverseMap();
            CreateMap<TipoDeProductoListDto, TipoDeProductoListViewModel>().ReverseMap();
            CreateMap<TipoDeProductoEditDto, TipoDeProductoEditViewModel>().ReverseMap();
            CreateMap<TipoDeProductoEditDto, TipoDeProductoListDto>().ReverseMap();
        }

        private void LoadMappingProvincia()
        {
            CreateMap<Provincia, ProvinciaListDto>();
            CreateMap<Provincia, ProvinciaEditDto>().ReverseMap();
            CreateMap<ProvinciaListDto, ProvinciaListViewModel>().ReverseMap();
            CreateMap<ProvinciaEditDto, ProvinciaEditViewModel>().ReverseMap();
            CreateMap<ProvinciaEditDto, ProvinciaListDto>().ReverseMap();
        }

        private void LoadMappingFormaFarmaceutica()
        {
            CreateMap<FormaFarmaceutica, FormaFarmaceuticaListDto>();
            CreateMap<FormaFarmaceutica, FormaFarmaceuticaEditDto>().ReverseMap();
            CreateMap<FormaFarmaceuticaListDto, FormaFarmaceuticaListViewModel>().ReverseMap();
            CreateMap<FormaFarmaceuticaEditDto, FormaFarmaceuticaEditViewModel>().ReverseMap();
            CreateMap<FormaFarmaceuticaEditDto, FormaFarmaceuticaListDto>().ReverseMap();
        }

        private void LoadMappingLaboratorio()
        {
            CreateMap<Laboratorio, LaboratorioListDto>();
            CreateMap<Laboratorio, LaboratorioEditDto>().ReverseMap();
            CreateMap<LaboratorioListDto, LaboratorioListViewModel>().ReverseMap();
            CreateMap<LaboratorioEditDto, LaboratorioEditViewModel>().ReverseMap();
            CreateMap<LaboratorioEditDto, LaboratorioListDto>().ReverseMap();
        }

        private void LoadMappingTipoDeDocumento()
        {
            CreateMap<TipoDeDocumento, TipoDeDocumentoListDto>();
            CreateMap<TipoDeDocumento, TipoDeDocumentoEditDto>().ReverseMap();
            CreateMap<TipoDeDocumentoListDto, TipoDeDocumentoListViewModel>().ReverseMap();
            CreateMap<TipoDeDocumentoEditDto, TipoDeDocumentoEditViewModel>().ReverseMap();
            CreateMap<TipoDeDocumentoEditDto, TipoDeDocumentoListDto>().ReverseMap();
        }

        private void LoadMappingTipoDeMascota()
        {
            CreateMap<TipoDeMascota, TipoDeMascotaListDto>();
            CreateMap<TipoDeMascota, TipoDeMascotaEditDto>().ReverseMap();
            CreateMap<TipoDeMascotaListDto, TipoDeMascotaListViewModel>().ReverseMap();
            CreateMap<TipoDeMascotaEditDto, TipoDeMascotaEditViewModel>().ReverseMap();
            CreateMap<TipoDeMascotaEditDto, TipoDeMascotaListDto>().ReverseMap();
        }

        private void LoadMappingTipoDeMedicamento()
        {
            CreateMap<TipoDeMedicamento, TipoDeMedicamentoListDto>();
            CreateMap<TipoDeMedicamento, TipoDeMedicamentoEditDto>().ReverseMap();
            CreateMap<TipoDeMedicamentoListDto, TipoDeMedicamentoListViewModel>().ReverseMap();
            CreateMap<TipoDeMedicamentoEditDto, TipoDeMedicamentoEditViewModel>().ReverseMap();
            CreateMap<TipoDeMedicamentoEditDto, TipoDeMedicamentoListDto>().ReverseMap();
        }
    }
}
