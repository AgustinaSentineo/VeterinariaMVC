using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using VeterinariaMVC.Entidades.DTOs.Raza;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Mapeador;
using VeterinariMVC.Datos.Repositorios.Facades;

namespace VeterinariMVC.Datos.Repositorios
{
    public class RepositorioRaza : IRepositorioRaza
    {
        private readonly VeterinariaDbContext context;
        private readonly IMapper mapper;
        public RepositorioRaza(VeterinariaDbContext _context)
        {
            context = _context;
            mapper = Mapeador.CrearMapper();
        }
        public List<RazaListDto> GetLista(string tipomascota)
        {
            try
            {
                if (tipomascota == null)
                {
                    var lista = context.Razas.Include(r => r.TipoDeMascota)
                .Select(r => new RazaListDto
                {
                    RazaId = r.RazaId,
                    Descripcion = r.Descripcion,
                    TipoDeMascota = r.TipoDeMascota.Descripcion,
                }).ToList();
                    return lista;

                }
                else
                {
                    var lista = context.Razas.Include(r => r.TipoDeMascota)
                        .Where(r => r.TipoDeMascota.Descripcion == tipomascota)
                      .Select(r => new RazaListDto
                      {
                          RazaId = r.RazaId,
                          Descripcion = r.Descripcion,
                          TipoDeMascota = r.TipoDeMascota.Descripcion,
                      }).ToList();
                    return lista;

                }
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer las razas");
            }
        }

        public RazaEditDto GetRazaPorId(int? id)
        {
            try
            {
                return mapper
                    .Map<RazaEditDto>(context.Razas
                        .Include(r => r.TipoDeMascota)
                        .SingleOrDefault(r => r.RazaId == id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer una raza");
            }
        }

        public void Guardar(Raza raza)
        {
            try
            {
                if (raza.RazaId == 0)
                {
                    context.Razas.Add(raza);
                }
                else
                {
                    var razaInDb = context
                        .Razas
                        .SingleOrDefault(r => r.RazaId == raza.RazaId);
                    razaInDb.TipoDeMascotaId = raza.TipoDeMascotaId;
                    razaInDb.Descripcion = raza.Descripcion;
                    razaInDb.RazaId = raza.RazaId;
                    context.Entry(razaInDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar guardar una raza");
            }
        }
        public void Borrar(int vmRazaId)
        {
            try
            {
                var razaInDb = context.Razas.SingleOrDefault(r => r.RazaId == vmRazaId);
                if (razaInDb == null)
                {
                    throw new Exception("Raza inexistente...");

                }

                context.Entry(razaInDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar borrar una raza");
            }
        }

        public bool Existe(Raza raza)
        {
            if (raza.RazaId == 0)
            {
                return context.Razas.Any(r => r.Descripcion == raza.Descripcion);
            }

            return context.Razas.Any(r => r.Descripcion == raza.Descripcion
            && r.RazaId != raza.RazaId);
        }
    }
}
