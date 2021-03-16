using AutoMapper;
using System;
using VeterinariaMVC.Entidades.DTOs.FormaFarmaceutica;
using VeterinariaMVC.Entidades.DTOs.Laboratorio;
using VeterinariaMVC.Entidades.DTOs.Marca;
using VeterinariaMVC.Entidades.DTOs.TipoDeDocumento;
using VeterinariaMVC.Entidades.DTOs.TipoDeMascota;
using VeterinariaMVC.Entidades.DTOs.TipoDeMedicamento;
using VeterinariaMVC.Entidades.DTOs.TipoDeProducto;
using VeterinariaMVC.Entidades.DTOs.TipoDeTarea;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Entidades.ViewModels.FormaFarmaceutica;
using VeterinariaMVC.Entidades.ViewModels.Laboratorio;
using VeterinariaMVC.Entidades.ViewModels.Marca;
using VeterinariaMVC.Entidades.ViewModels.Provincia;
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
