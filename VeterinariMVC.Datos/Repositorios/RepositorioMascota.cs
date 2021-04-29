using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using VeterinariaMVC.Entidades.DTOs.Mascota;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Mapeador;
using VeterinariMVC.Datos.Repositorios.Facades;

namespace VeterinariMVC.Datos.Repositorios
{
    public class RepositorioMascota : IRepositorioMascota
    {
        private readonly VeterinariaDbContext context;
        private readonly IMapper mapper;
        public RepositorioMascota(VeterinariaDbContext _context)
        {
            context = _context;
            mapper = Mapeador.CrearMapper();
        }
        public List<MascotaListDto> GetLista()
        {
            try
            {
                var lista = context.Mascotas.Include(m => m.Cliente)
                  .Select(m => new MascotaListDto
                  {
                      MascotaId = m.MascotaId,
                      Nombre = m.Nombre,
                      TipoDeMascota = m.TipoDeMascota.Descripcion,
                      Cliente = m.Cliente.Apellido,
                      FechaDeNacimiento = m.FechaDeNacimiento,

                  }).ToList();

                return lista;

            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer las mascotas");
            }
        }

        public MascotaEditDto GetMascotaPorId(int? id)
        {
            try
            {
                return mapper
                    .Map<MascotaEditDto>(context.Mascotas
                        .SingleOrDefault(c => c.MascotaId == id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer un mascota");
            }
        }

        public void Guardar(Mascota mascota)
        {
            try
            {
                if (mascota.MascotaId == 0)
                {
                    context.Mascotas.Add(mascota);
                }
                else
                {
                    var mascotaInDb = context
                        .Mascotas
                        .SingleOrDefault(c => c.MascotaId == mascota.MascotaId);

                    mascotaInDb.MascotaId = mascota.MascotaId;
                    mascotaInDb.Nombre = mascota.Nombre;
                    mascotaInDb.FechaDeNacimiento = mascota.FechaDeNacimiento;
                    mascotaInDb.TipoDeMascotaId = mascota.TipoDeMascotaId;
                    mascotaInDb.RazaId = mascota.RazaId;
                    mascotaInDb.ClienteId = mascota.ClienteId;
                    context.Entry(mascotaInDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar guardar una mascota");
            }
        }
        public void Borrar(int vmMascotaId)
        {
            try
            {
                var mascotaInDb = context.Mascotas.SingleOrDefault(c => c.MascotaId == vmMascotaId);
                if (mascotaInDb == null)
                {
                    throw new Exception("Mascota inexistente...");

                }

                context.Entry(mascotaInDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar borrar una mascota");
            }
        }

        public bool Existe(Mascota mascota)
        {
            if (mascota.MascotaId == 0)
            {
                return context.Mascotas.Any(c => c.Nombre == mascota.Nombre && c.FechaDeNacimiento== mascota.FechaDeNacimiento);
            }

            return context.Mascotas.Any(c => c.Nombre == mascota.Nombre && c.FechaDeNacimiento == mascota.FechaDeNacimiento 
            && c.MascotaId != mascota.MascotaId);
        }

    }
}
