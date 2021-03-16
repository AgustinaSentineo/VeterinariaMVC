using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VeterinariaMVC.Datos.Repositorios.Facades;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Entities.DTOs.Provincia;
using VeterinariMVC.Datos;

namespace VeterinariaMVC.Datos.Repositorios
{
    public class RepositorioProvincias : IRepositorioProvincia
    {
        private readonly VeterinariaDbContext context;
        private readonly IMapper mapper;      

        public RepositorioProvincias(VeterinariaDbContext _context)
        {
            context = _context;
            mapper = Mapeador.Mapeador.CrearMapper();
        }
        public List<ProvinciaListDto> GetLista()
        {
            try
            {
                var lista = context.Provincias.ToList();
                return mapper.Map<List<ProvinciaListDto>>(lista);
            }
            catch (Exception)
            {
                throw new Exception("Error al leer las Provincias");
            }
        }

        public ProvinciaEditDto GetProvinciaId(int? Id)
        {
            try
            {
                return mapper
                    .Map<ProvinciaEditDto>(context.Provincias.SingleOrDefault(p => p.ProvinciaId == Id)); 
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer el Id");
            }
        }

        public void Guardar(Provincia provincia)
        {
            try
            {
                if (provincia.ProvinciaId == 0)
                {
                    context.Provincias.Add(provincia);
                }
                else
                {
                    var tipoDb = context.Provincias.SingleOrDefault(p => p.ProvinciaId == provincia.ProvinciaId);
                    tipoDb.NombreProvincia = provincia.NombreProvincia;

                    context.Entry(tipoDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {

                throw new Exception("Error al Guardar/Editar la provincia");
            }
        }

        public void Borrar(int? Id)
        {
            try
            {
                var tipoDb = context.Provincias.SingleOrDefault(p => p.ProvinciaId == Id);
                context.Entry(tipoDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar borrar una provincia");
            }
        }

        public bool Existe(Provincia provincia)
        {
            if (provincia.ProvinciaId == 0)
            {
                return context.Provincias.Any(p => p.NombreProvincia == provincia.NombreProvincia);
            }
            return context.Provincias.Any(p => p.NombreProvincia == provincia.NombreProvincia &&
            p.ProvinciaId == provincia.ProvinciaId);
        }

    }
}
