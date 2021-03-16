using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VeterinariaMVC.Entidades.DTOs.NecesidadEspecial;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Mapeador;
using VeterinariMVC.Datos.Repositorios.Facades;

namespace VeterinariMVC.Datos.Repositorios
{
    public class RepositorioNecesidadEspecial : IRepositorioNecesidadEspecial
    {
        private readonly VeterinariaDbContext context;
        private readonly IMapper mapper;

        public RepositorioNecesidadEspecial(VeterinariaDbContext _context)
        {
            context = _context;
            mapper = Mapeador.CrearMapper();
        }
        public List<NecesidadEspecialListDto> GetLista()
        {
            try
            {
                var lista = context.NecesidadesEspeciales.ToList();
                return mapper.Map<List<NecesidadEspecialListDto>>(lista);
            }
            catch (Exception)
            {
                throw new Exception("Error al leer las Necesidades Especiales");
            }
        }

        public NecesidadEspecialEditDto GetNecesidadEspecialId(int? Id)
        {
            try
            {
                return mapper
                    .Map<NecesidadEspecialEditDto>(context.NecesidadesEspeciales.SingleOrDefault(n => n.NecesidadesEspecialesId == Id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer el Id");
            }
        }

        public void Guardar(NecesidadesEspeciales necesidadesEspeciales)
        {
            try
            {
                if (necesidadesEspeciales.NecesidadesEspecialesId == 0)
                {
                    context.NecesidadesEspeciales.Add(necesidadesEspeciales);
                }
                else
                {
                    var tipoDb = context.NecesidadesEspeciales.SingleOrDefault(n => n.NecesidadesEspecialesId == necesidadesEspeciales.NecesidadesEspecialesId);
                    tipoDb.Descripcion = necesidadesEspeciales.Descripcion;

                    context.Entry(tipoDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {

                throw new Exception("Error al Guardar/Editar los datos");
            }
        }
        public void Borrar(int? Id)
        {
            try
            {
                var tipoDb = context.NecesidadesEspeciales.SingleOrDefault(n => n.NecesidadesEspecialesId == Id);
                context.Entry(tipoDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar borrar el dato");
            }
        }

        public bool Existe(NecesidadesEspeciales necesidadesEspeciales)
        {
            if (necesidadesEspeciales.NecesidadesEspecialesId == 0)
            {
                return context.NecesidadesEspeciales.Any(n => n.Descripcion == necesidadesEspeciales.Descripcion);
            }
            return context.NecesidadesEspeciales.Any(n => n.Descripcion == necesidadesEspeciales.Descripcion &&
            n.NecesidadesEspecialesId == necesidadesEspeciales.NecesidadesEspecialesId);
        }

    }
}
