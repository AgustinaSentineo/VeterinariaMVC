using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using VeterinariaMVC.Entidades.DTOs.Producto;
using VeterinariaMVC.Entidades.ViewModels.Marca;
using VeterinariaMVC.Entidades.ViewModels.Producto;
using VeterinariaMVC.Entidades.ViewModels.TipoDeProducto;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariaMVC.Web.Classes;

namespace VeterinariaMVC.Web.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IServicioProducto _servicio;
        private readonly IServicioTipoDeProducto _serviciosTipoProducto;
        private readonly IServicioMarca _servicioMarca;

        private readonly IMapper _mapper;

        private readonly string folder = "~/Content/Imagenes/Producto/";
        public ProductoController(IServicioProducto servicio, IServicioTipoDeProducto serviciosTipoProducto, IServicioMarca servicioMarca)
        {
            _servicio = servicio;
            _serviciosTipoProducto = serviciosTipoProducto;
            _servicioMarca = servicioMarca;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }


        // GET: Productos
        public ActionResult Index(string tipoProducto = null)
        {
            var listaDto = _servicio.GetLista(tipoProducto);
            var listaVm = _mapper.Map<List<ProductoListViewModel>>(listaDto);

            var productoFilterVm = new ProductoFilterViewModel
            {
                Productos = listaVm,
                TipoProducto = _mapper.Map<List<TipoDeProductoListViewModel>>(_serviciosTipoProducto.GetLista())

            };
            return View(productoFilterVm);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ProductoEditViewModel productoVm = new ProductoEditViewModel
            {
                Imagen = $"ImagenNoDisponible.jpg",
                TipoProducto = _mapper
                    .Map<List<TipoDeProductoListViewModel>>(_serviciosTipoProducto.GetLista()),
                Marca = _mapper
                    .Map<List<MarcaListViewModel>>(_servicioMarca.GetLista())
            };
            return View(productoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductoEditViewModel productoVm)
        {
            if (!ModelState.IsValid)
            {
                productoVm.Imagen = $"ImagenNoDisponible.jpg";
                productoVm.TipoProducto = _mapper
                    .Map<List<TipoDeProductoListViewModel>>(_serviciosTipoProducto.GetLista());
                productoVm.Marca = _mapper
                   .Map<List<MarcaListViewModel>>(_servicioMarca.GetLista());
                return View(productoVm);
            }

            ProductoEditDto productoDto = _mapper.Map<ProductoEditDto>(productoVm);
            if (_servicio.Existe(productoDto))
            {
                ModelState.AddModelError(string.Empty, @"Producto existente...");
                productoVm.Imagen = $"ImagenNoDisponible.jpg";
                productoVm.TipoProducto = _mapper
                    .Map<List<TipoDeProductoListViewModel>>(_serviciosTipoProducto.GetLista());
                productoVm.Marca = _mapper
                   .Map<List<MarcaListViewModel>>(_servicioMarca.GetLista());
                return View(productoVm);
            }

            try
            {
                if (productoVm.ImagenFile != null)
                {
                    productoDto.Imagen = $"{productoVm.ImagenFile.FileName}";
                }

                _servicio.Guardar(productoDto);

                if (productoVm.ImagenFile != null)
                {
                    var file = $"{productoVm.ImagenFile.FileName}";
                    var response = FileHelper.UploadPhoto(productoVm.ImagenFile, folder, file);
                }

                TempData["Msg"] = "Producto agregado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                productoVm.Imagen = $"ImagenNoDisponible.jpg";
                productoVm.TipoProducto = _mapper
                    .Map<List<TipoDeProductoListViewModel>>(_serviciosTipoProducto.GetLista());
                productoVm.Marca = _mapper
                   .Map<List<MarcaListViewModel>>(_servicioMarca.GetLista());
                return View(productoVm);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProductoEditDto productoEditDto = _servicio.GetProductoPorId(id);
            ProductoEditViewModel productoVm = _mapper.Map<ProductoEditViewModel>(productoEditDto);
            productoVm.TipoProducto = _mapper
                .Map<List<TipoDeProductoListViewModel>>(_serviciosTipoProducto.GetLista());
            productoVm.Marca = _mapper
                   .Map<List<MarcaListViewModel>>(_servicioMarca.GetLista());
            if (productoVm.Imagen == null)
            {
                productoVm.Imagen = $"ImagenNoDisponible.jpg";
            }
            else
            {
                productoVm.Imagen = $"{productoVm.Imagen}";
            }

            return View(productoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductoEditViewModel productoVm)
        {
            if (!ModelState.IsValid)
            {
                productoVm.Imagen = $"ImagenNoDisponible.jpg";

                productoVm.TipoProducto = _mapper
                    .Map<List<TipoDeProductoListViewModel>>(_serviciosTipoProducto.GetLista());
                productoVm.Marca = _mapper
                   .Map<List<MarcaListViewModel>>(_servicioMarca.GetLista());
                return View(productoVm);
            }

            ProductoEditDto productoDto = _mapper.Map<ProductoEditDto>(productoVm);
            if (_servicio.Existe(productoDto))
            {
                ModelState.AddModelError(string.Empty, @"Producto existente...");
                productoVm.Imagen = $"ImagenNoDisponible.jpg";

                productoVm.TipoProducto = _mapper
                    .Map<List<TipoDeProductoListViewModel>>(_serviciosTipoProducto.GetLista());
                productoVm.Marca = _mapper
                   .Map<List<MarcaListViewModel>>(_servicioMarca.GetLista());
                return View(productoVm);
            }

            try
            {
                if (productoVm.ImagenFile != null)
                {
                    productoDto.Imagen = $"{productoVm.ImagenFile.FileName}";
                }

                _servicio.Guardar(productoDto);

                if (productoVm.ImagenFile != null)
                {
                    var file = $"{productoVm.ImagenFile.FileName}";
                    var response = FileHelper.UploadPhoto(productoVm.ImagenFile, folder, file);
                }

                TempData["Msg"] = "Producto editado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                productoVm.Imagen = $"{folder}ImagenNoDisponible.jpg";

                productoVm.TipoProducto = _mapper
                    .Map<List<TipoDeProductoListViewModel>>(_serviciosTipoProducto.GetLista());
                productoVm.Marca = _mapper
                   .Map<List<MarcaListViewModel>>(_servicioMarca.GetLista());
                return View(productoVm);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProductoEditDto productoEditDto = _servicio.GetProductoPorId(id);
            if (productoEditDto == null)
            {
                return HttpNotFound("Código de producto inexistente...");
            }

            ProductoListDto productoDto = _mapper.Map<ProductoListDto>(_servicio.GetProductoPorId(id));
            var tipoProducto = _serviciosTipoProducto.GetTipoDeProductoId(productoEditDto.TipoDeProductoId);
            productoDto.TipoDeProducto = tipoProducto.Descripcion;      

            ProductoListViewModel productoVm = _mapper.Map<ProductoListViewModel>(productoDto);

            return View(productoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProductoListViewModel productoVm)
        {
            try
            {
                ProductoListDto productoDto = _mapper
                    .Map<ProductoListDto>(_servicio.GetProductoPorId(productoVm.ProductoId));
                productoVm = _mapper.Map<ProductoListViewModel>(productoDto);

                _servicio.Borrar(productoVm.ProductoId);
                TempData["Msg"] = "Registro borrado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
                return View(productoVm);
            }
        }
    }
}