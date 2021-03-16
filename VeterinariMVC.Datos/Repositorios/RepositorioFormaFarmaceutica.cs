using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VeterinariaMVC.Datos.Repositorios.Facades;
using VeterinariaMVC.Entidades.DTOs.FormaFarmaceutica;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariMVC.Datos;

namespace VeterinariaMVC.Datos.Repositorios
{
    public class RepositorioFormaFarmaceutica : IRepositorioFormaFarmaceutica
    {
        private VeterinariaDbContext _context;
        private readonly IMapper mapper;
        public RepositorioFormaFarmaceutica(VeterinariaDbContext context)
        {
            _context = context;
            mapper = Mapeador.Mapeador.CrearMapper();

        }

        public List<FormaFarmaceuticaListDto> GetFormaFarmaceutica()
        {
            try
            {
                var lista = _context.FormasFarmaceuticas.ToList();
                return mapper.Map<List<FormaFarmaceuticaListDto>>(lista);
            }
            catch (Exception)
            {
                throw new Exception("Error al leer las Formas Farmaceuticas");
            }
        }

        public FormaFarmaceuticaEditDto GetObjeto(int? id)
        {
            try
            {
                return mapper
                    .Map<FormaFarmaceuticaEditDto>(_context.FormasFarmaceuticas.SingleOrDefault(f => f.FormaFarmaceuticaId == id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer el Id");
            }
        }

        public void Agregar(FormaFarmaceutica formaFarmaceutica)
        {
            try
            {
                if (formaFarmaceutica.FormaFarmaceuticaId == 0)
                {
                    _context.FormasFarmaceuticas.Add(formaFarmaceutica);
                }
                else
                {
                    var tipoDb = _context.FormasFarmaceuticas.SingleOrDefault(f => f.FormaFarmaceuticaId == formaFarmaceutica.FormaFarmaceuticaId);
                    tipoDb.Descripcion = formaFarmaceutica.Descripcion;
                    _context.Entry(tipoDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {

                throw new Exception("Error al Guardar/Editar la forma farmaceutica");
            }
        }

        public void Borrar(int? Id)
        {
            try
            {
                var tipoDb = _context.FormasFarmaceuticas.SingleOrDefault(f => f.FormaFarmaceuticaId == Id);
                _context.Entry(tipoDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar borrar una forma farmaceutica");
            }
        }

        public bool Existe(FormaFarmaceutica formaFarmaceutica)
        {
            if (formaFarmaceutica.FormaFarmaceuticaId == 0)
            {
                return _context.FormasFarmaceuticas.Any(f => f.Descripcion == formaFarmaceutica.Descripcion);
            }
            return _context.FormasFarmaceuticas.Any(f => f.Descripcion == formaFarmaceutica.Descripcion &&
            f.FormaFarmaceuticaId == formaFarmaceutica.FormaFarmaceuticaId);
        }

        public bool EstaRelacionado(FormaFarmaceutica formaFarmaceutica)
        {
            throw new NotImplementedException();
        }

    }
}
