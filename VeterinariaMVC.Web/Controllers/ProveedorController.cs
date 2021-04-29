using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using VeterinariaMVC.Entidades.DTOs.Proveedor;
using VeterinariaMVC.Entidades.ViewModels.Localidad;
using VeterinariaMVC.Entidades.ViewModels.Proveedor;
using VeterinariaMVC.Entidades.ViewModels.Provincia;
using VeterinariaMVC.Entidades.ViewModels.TipoDeDocumento;
using VeterinariaMVC.Servicios.Servicios.Facades;

namespace VeterinariaMVC.Web.Controllers
{
    public class ProveedorController : Controller
    {
        private readonly IServicioProveedor servicio;
        private readonly IServicioTipoDeDocumento servicioTipoDeDocumento;
        private readonly IServicioLocalidad servicioLocalidad;
        private readonly IServicioProvincia serviciosProvincia;

        private readonly IMapper mapper;
        public ProveedorController(IServicioProveedor _servicio, IServicioTipoDeDocumento _servicioTipo, IServicioLocalidad _servicioLocalidad, IServicioProvincia _serviciosProvincia)
        {
            servicio = _servicio;
            servicioTipoDeDocumento = _servicioTipo;
            servicioLocalidad = _servicioLocalidad;
            serviciosProvincia = _serviciosProvincia;
            mapper = Mapeador.Mapeador.CrearMapper();
        }

        public ActionResult Index()
        {
            var listaDto = servicio.GetLista();
            var listaVm = mapper.Map<List<ProveedorListViewModel>>(listaDto);


            return View(listaVm);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ProveedorEditViewModel proveedorVm = new ProveedorEditViewModel
            {
                Provincia = mapper
                      .Map<List<ProvinciaListViewModel>>(serviciosProvincia.GetLista()),
                Localidad = mapper
                       .Map<List<LocalidadListViewModel>>(servicioLocalidad.GetLista(null)),
            };
            return View(proveedorVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProveedorEditViewModel proveedorVm)
        {
            if (!ModelState.IsValid)
            {
                proveedorVm.Provincia = mapper
                      .Map<List<ProvinciaListViewModel>>(serviciosProvincia.GetLista());
                proveedorVm.Localidad = mapper
                       .Map<List<LocalidadListViewModel>>(servicioLocalidad.GetLista(null));
                return View(proveedorVm);
            }

            ProveedorEditDto proveedorDto = mapper.Map<ProveedorEditDto>(proveedorVm);
            if (servicio.Existe(proveedorDto))
            {
                ModelState.AddModelError(string.Empty, @"Proveedor existente...");
                proveedorVm.Provincia = mapper
                        .Map<List<ProvinciaListViewModel>>(serviciosProvincia.GetLista());
                proveedorVm.Localidad = mapper
                       .Map<List<LocalidadListViewModel>>(servicioLocalidad.GetLista(null));
                return View(proveedorVm);
            }

            try
            {
                servicio.Guardar(proveedorDto);
                TempData["Msg"] = "Proveedor agregado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                proveedorVm.Provincia = mapper
                       .Map<List<ProvinciaListViewModel>>(serviciosProvincia.GetLista());
                proveedorVm.Localidad = mapper
                       .Map<List<LocalidadListViewModel>>(servicioLocalidad.GetLista(null));
                return View(proveedorVm);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProveedorEditDto proveedorEditDto = servicio.GetProveedorPorId(id);
            ProveedorEditViewModel proveedorVm = mapper.Map<ProveedorEditViewModel>(proveedorEditDto);
            proveedorVm.Provincia = mapper
                         .Map<List<ProvinciaListViewModel>>(serviciosProvincia.GetLista());
            proveedorVm.Localidad = mapper
                   .Map<List<LocalidadListViewModel>>(servicioLocalidad.GetLista(null));
            return View(proveedorVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProveedorEditViewModel proveedorVm)
        {
            if (!ModelState.IsValid)
            {
                proveedorVm.Provincia = mapper
                      .Map<List<ProvinciaListViewModel>>(serviciosProvincia.GetLista());
                proveedorVm.Localidad = mapper
                       .Map<List<LocalidadListViewModel>>(servicioLocalidad.GetLista(null));
                return View(proveedorVm);
            }

            ProveedorEditDto proveedorDto = mapper.Map<ProveedorEditDto>(proveedorVm);
            if (servicio.Existe(proveedorDto))
            {
                ModelState.AddModelError(string.Empty, @"Proveedor existente...");

                proveedorVm.Provincia = mapper
                       .Map<List<ProvinciaListViewModel>>(serviciosProvincia.GetLista());
                proveedorVm.Localidad = mapper
                       .Map<List<LocalidadListViewModel>>(servicioLocalidad.GetLista(null));
                return View(proveedorVm);
            }
            try
            {
                servicio.Guardar(proveedorDto);
                TempData["Msg"] = "Proveedor editada...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);

                proveedorVm.Provincia = mapper
                      .Map<List<ProvinciaListViewModel>>(serviciosProvincia.GetLista());
                proveedorVm.Localidad = mapper
                       .Map<List<LocalidadListViewModel>>(servicioLocalidad.GetLista(null));
                return View(proveedorVm);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProveedorEditDto proveedorEditDto = servicio.GetProveedorPorId(id);
            if (proveedorEditDto == null)
            {
                return HttpNotFound("Código de proveerdor inexistente...");
            }

            ProveedorListDto proveedorDto = mapper.Map<ProveedorListDto>(servicio.GetProveedorPorId(id));
            ProveedorListViewModel proveedorVm = mapper.Map<ProveedorListViewModel>(proveedorDto);

            return View(proveedorVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProveedorListViewModel proveedorVm)
        {
            try
            {
                ProveedorListDto proveedorDto = mapper
                    .Map<ProveedorListDto>(servicio.GetProveedorPorId(proveedorVm.ProveedorId));
                proveedorVm = mapper.Map<ProveedorListViewModel>(proveedorDto);

                servicio.Borrar(proveedorVm.ProveedorId);
                TempData["Msg"] = "Registro borrado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
                return View(proveedorVm);
            }
        }
    }
}