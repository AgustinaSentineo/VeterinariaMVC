using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VeterinariaMVC.Entidades.DTOs.Alimento;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Mapeador;
using VeterinariMVC.Datos.Repositorios.Facades;

namespace VeterinariMVC.Datos.Repositorios
{
    public class RepositorioAlimento : IRepositorioAlimento
    {
        private readonly VeterinariaDbContext _context;
        private readonly IMapper _mapper;

        public RepositorioAlimento(VeterinariaDbContext context)
        {
            _context = context;
            _mapper = Mapeador.CrearMapper();
        }
        public List<AlimentoListDto> GetLista()
        {
            try
            {
                var lista = _context.Alimentos
             .Select(p => new AlimentoListDto
             {
                 AlimentoId = p.AlimentoId,
                 Nombre = p.Nombre,
                 Marca=p.Marca.Nombre,
                 Clasificacion=p.Clasificacion.Descripcion,
                 RangoEdad=p.RangoEdad,
                 PrecioVenta = p.PrecioVenta,
                 Imagen = p.Imagen
             }).ToList();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer los alimentos");
            }
        }

        public AlimentoEditDto GetAlimentoPorId(int? id)
        {
            try
            {
                return _mapper
                    .Map<AlimentoEditDto>(_context.Alimentos
                    .Include(p => p.Marca)
                        .SingleOrDefault(p => p.AlimentoId == id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer  un alimento");
            }
        }

        public void Guardar(Alimento alimento)
        {
            try
            {
                if (alimento.AlimentoId == 0)
                {
                    _context.Alimentos.Add(alimento);
                }
                else
                {
                    var alimentoInDb = _context
                        .Alimentos
                        .SingleOrDefault(p => p.AlimentoId == alimento.AlimentoId);
                    alimentoInDb.Nombre = alimento.Nombre;
                    alimentoInDb.TipoDeAlimentoId = alimento.TipoDeAlimentoId;
                    alimentoInDb.ClasificacionId = alimento.ClasificacionId;
                    alimentoInDb.TipoDeMascotaId= alimento.TipoDeMascotaId;
                    alimentoInDb.RangoEdad = alimento.RangoEdad;
                    alimentoInDb.NecesidadesEspecialesId = alimento.NecesidadesEspecialesId;
                    alimentoInDb.MarcaId = alimento.MarcaId;                 
                    alimentoInDb.Cantidad = alimento.Cantidad;
                    alimentoInDb.PrecioVenta = alimento.PrecioVenta; 
                    alimentoInDb.PrecioCompra = alimento.PrecioCompra;                                 
                    alimentoInDb.Stock = alimento.Stock;
                    alimentoInDb.Imagen = alimento.Imagen;
                    _context.Entry(alimentoInDb).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar guardar un alimento");
            }
        }
        public void Borrar(int VmAlimentoId)
        {
            try
            {
                var alimentoInDb = _context.Alimentos.SingleOrDefault(p => p.AlimentoId == VmAlimentoId);
                if (alimentoInDb == null)
                {
                    throw new Exception("Alimento inexistente...");

                }

                _context.Entry(alimentoInDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar borrar un alimento");
            }
        }

        public bool Existe(Alimento alimento)
        {
            if (alimento.AlimentoId == 0)
            {
                return _context.Alimentos.Any(p => p.Nombre == alimento.Nombre && p.MarcaId == alimento.MarcaId);
            }

            return _context.Alimentos.Any(p => p.Nombre == alimento.Nombre && p.MarcaId == alimento.MarcaId 
            && p.AlimentoId != alimento.AlimentoId);
        }

    }
}
