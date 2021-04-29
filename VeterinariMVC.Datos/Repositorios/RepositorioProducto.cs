using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using VeterinariaMVC.Entidades.DTOs.Producto;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Mapeador;
using VeterinariMVC.Datos.Repositorios.Facades;

namespace VeterinariMVC.Datos.Repositorios
{
    public class RepositorioProducto : IRepositorioProducto
    {
        private readonly VeterinariaDbContext _context;
        private readonly IMapper _mapper;

        public RepositorioProducto(VeterinariaDbContext context)
        {
            _context = context;
            _mapper = Mapeador.CrearMapper();
        }
        public List<ProductoListDto> GetLista(string tipo)
        {
            try
            {

                if (tipo == null)
                {
                    var lista = _context.Productos.Include(p => p.TipoDeProducto)
                .Select(p => new ProductoListDto
                {
                    ProductoId = p.ProductoId,
                    Modelo = p.Modelo,
                    PrecioVenta = p.PrecioVenta,
                    TipoDeProducto = p.TipoDeProducto.Descripcion,
                    Imagen = p.Imagen
                }).ToList();
                    return lista;

                }
                else
                {
                    var lista = _context.Productos.Include(p => p.TipoDeProducto)
                        .Where(p => p.TipoDeProducto.Descripcion == tipo)
                        .Select(p => new ProductoListDto
                        {
                            ProductoId = p.ProductoId,
                            Modelo = p.Modelo,
                            PrecioVenta = p.PrecioVenta,
                            TipoDeProducto = p.TipoDeProducto.Descripcion,
                            Imagen = p.Imagen
                        }).ToList();
                    return lista;

                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer los productos");
            }
        }

        public bool Existe(Producto producto)
        {
            if (producto.ProductoId == 0)
            {
                return _context.Productos.Any(p => p.Descripcion == producto.Descripcion);
            }

            return _context.Productos.Any(p =>
                p.Descripcion == producto.Descripcion && p.ProductoId != producto.ProductoId);
        }

        public void Guardar(Producto producto)
        {
            try
            {
                if (producto.ProductoId == 0)
                {
                    _context.Productos.Add(producto);
                }
                else
                {
                    var productoInDb = _context
                        .Productos
                        .SingleOrDefault(p => p.ProductoId == producto.ProductoId);
                    productoInDb.TipoDeProductoId = producto.TipoDeProductoId;
                    productoInDb.Descripcion = producto.Descripcion;
                    productoInDb.ProductoId = producto.ProductoId;
                    productoInDb.Imagen = producto.Imagen;
                    productoInDb.PrecioCompra = producto.PrecioCompra;
                    productoInDb.PrecioVenta = producto.PrecioVenta;
                    productoInDb.MarcaId = producto.MarcaId;
                    productoInDb.Modelo = producto.Modelo;
                    productoInDb.Stock = producto.Stock;
                    _context.Entry(productoInDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar guardar un producto");
            }
        }

        public ProductoEditDto GetProductoPorId(int? id)
        {
            try
            {
                return _mapper
                    .Map<ProductoEditDto>(_context.Productos
                        .Include(p => p.TipoDeProducto)
                        .SingleOrDefault(p => p.ProductoId == id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer  un producto");
            }

        }

        public void Borrar(int tipoVmProductoId)
        {
            try
            {
                var productoInDb = _context.Productos.SingleOrDefault(p => p.ProductoId == tipoVmProductoId);
                if (productoInDb == null)
                {
                    throw new Exception("Producto inexistente...");

                }

                _context.Entry(productoInDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar borrar un producto");
            }
        }
    }
}
