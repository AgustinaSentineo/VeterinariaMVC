using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinariaMVC.Entidades.DTOs.Marca;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Mapeador;
using VeterinariMVC.Datos.Repositorios.Facades;

namespace VeterinariMVC.Datos.Repositorios
{
    public class RepositorioMarca : IRepositorioMarca
    {
        private readonly VeterinariaDbContext context;
        private readonly IMapper mapper;

        public RepositorioMarca(VeterinariaDbContext _context)
        {
            context = _context;
            mapper = Mapeador.CrearMapper();
        }
        public List<MarcaListDto> GetLista()
        {
            try
            {
                var lista = context.Marcas.ToList();
                return mapper.Map<List<MarcaListDto>>(lista);
            }
            catch (Exception)
            {
                throw new Exception("Error al leer las Marcas");
            }
        }

        public MarcaEditDto GetMarcaId(int? Id)
        {
            try
            {
                return mapper
                    .Map<MarcaEditDto>(context.Marcas.SingleOrDefault(m => m.MarcaId == Id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer el Id");
            }
        }

        public void Guardar(Marca marca)
        {
            try
            {
                if (marca.MarcaId == 0)
                {
                    context.Marcas.Add(marca);
                }
                else
                {
                    var tipoDb = context.Marcas.SingleOrDefault(m => m.MarcaId == marca.MarcaId);
                    tipoDb.Nombre = marca.Nombre;

                    context.Entry(tipoDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {

                throw new Exception("Error al Guardar/Editar la marca");
            }
        }
        public void Borrar(int? Id)
        {
            try
            {
                var tipoDb = context.Marcas.SingleOrDefault(m => m.MarcaId == Id);
                context.Entry(tipoDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar borrar una marca");
            }
        }

        public bool Existe(Marca marca)
        {
            if (marca.MarcaId == 0)
            {
                return context.Marcas.Any(m => m.Nombre == marca.Nombre);
            }
            return context.Marcas.Any(m => m.Nombre == marca.Nombre &&
            m.MarcaId == marca.MarcaId);
        }

    }
}
