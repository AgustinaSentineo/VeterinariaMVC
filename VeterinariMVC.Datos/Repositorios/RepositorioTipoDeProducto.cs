using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VeterinariaMVC.Entidades.DTOs.TipoDeProducto;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Mapeador;
using VeterinariMVC.Datos.Repositorios.Facades;

namespace VeterinariMVC.Datos.Repositorios
{
    public class RepositorioTipoDeProducto:IRepositorioTipoDeProducto
    {
        private readonly VeterinariaDbContext context;
        private readonly IMapper mapper;

        public RepositorioTipoDeProducto(VeterinariaDbContext _context)
        {
            context = _context;
            mapper = Mapeador.CrearMapper();
        }

        public List<TipoDeProductoListDto> GetLista()
        {
            try
            {
                var lista = context.TiposDeProductos.ToList();
                return mapper.Map<List<TipoDeProductoListDto>>(lista);
            }
            catch (Exception)
            {
                throw new Exception("Error al leer los Tipo de Producto");
            }
        }

        public TipoDeProductoEditDto GetTipoDeProductoId(int? Id)
        {
            try
            {
                return mapper
                    .Map<TipoDeProductoEditDto>(context.TiposDeProductos.SingleOrDefault(tp => tp.TipoDeProductoId == Id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer el Id");
            }
        }

        public void Guardar(TipoDeProducto tipoDeProducto)
        {
            try
            {
                if (tipoDeProducto.TipoDeProductoId == 0)
                {
                    context.TiposDeProductos.Add(tipoDeProducto);
                }
                else
                {
                    var tipoDb = context.TiposDeProductos.SingleOrDefault(tp => tp.TipoDeProductoId == tipoDeProducto.TipoDeProductoId);
                    tipoDb.Descripcion = tipoDeProducto.Descripcion;

                    context.Entry(tipoDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {

                throw new Exception("Error al Guardar/Editar el Tipo de Producto");
            }
        }
        public void Borrar(int? Id)
        {
            try
            {
                var tipoDb = context.TiposDeProductos.SingleOrDefault(tp => tp.TipoDeProductoId == Id);
                context.Entry(tipoDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar borrar un Tipo de Producto");
            }
        }

        public bool Existe(TipoDeProducto tipoDeProducto)
        {
            if (tipoDeProducto.TipoDeProductoId == 0)
            {
                return context.TiposDeProductos.Any(tp => tp.Descripcion == tipoDeProducto.Descripcion);
            }
            return context.TiposDeProductos.Any(tp => tp.Descripcion == tipoDeProducto.Descripcion &&
            tp.TipoDeProductoId == tipoDeProducto.TipoDeProductoId);
        }

    }
}
