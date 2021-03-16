using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VeterinariaMVC.Entidades.DTOs.Localidad;
using VeterinariaMVC.Entidades.ViewModels.Localidad;
using VeterinariaMVC.Entidades.ViewModels.Provincia;
using VeterinariaMVC.Servicios.Servicios.Facades;

namespace VeterinariaMVC.Web.Controllers
{
    public class LocalidadController : Controller
    {
        private readonly IServicioLocalidad servicio;
        private readonly IServicioProvincia serviciosProvincia;

        private readonly IMapper mapper;
        public LocalidadController(IServicioLocalidad _servicio, IServicioProvincia _serviciosProvincia)
        {
            servicio = _servicio;
            serviciosProvincia = _serviciosProvincia;
            mapper = Mapeador.Mapeador.CrearMapper();
        }

        // GET: Localidad
        public ActionResult Index(string provincia = null)
        {
            var listaDto = servicio.GetLista(provincia);
            var listaVm = mapper.Map<List<LocalidadListViewModel>>(listaDto);

            var localidadFilterVm = new LocalidadFilterListViewModel
            {
                Localidad = listaVm,
                Provincia = mapper.Map<List<ProvinciaListViewModel>>(serviciosProvincia.GetLista())
            };
            return View(localidadFilterVm);
        }

        [HttpGet]
        public ActionResult Create()
        {
            LocalidadEditViewModel localidadVm = new LocalidadEditViewModel
            {
                Provincia = mapper
                    .Map<List<ProvinciaListViewModel>>(serviciosProvincia.GetLista())
            };
            return View(localidadVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocalidadEditViewModel localidadVm)
        {
            if (!ModelState.IsValid)
            {
               localidadVm.Provincia = mapper
                    .Map<List<ProvinciaListViewModel>>(serviciosProvincia.GetLista());
                return View(localidadVm);
            }

            LocalidadEditDto localidadDto = mapper.Map<LocalidadEditDto>(localidadVm);
            if (servicio.Existe(localidadDto))
            {
                ModelState.AddModelError(string.Empty, @"Localidad existente...");
                localidadVm.Provincia = mapper
                    .Map<List<ProvinciaListViewModel>>(serviciosProvincia.GetLista());
                return View(localidadVm);
            }

            try
            {
                servicio.Guardar(localidadDto);
                TempData["Msg"] = "Localidad agregado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                localidadVm.Provincia = mapper
                    .Map<List<ProvinciaListViewModel>>(serviciosProvincia.GetLista());
                return View(localidadVm);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            LocalidadEditDto localidadEditDto = servicio.GetLocalidadPorId(id);
            LocalidadEditViewModel localidadVm = mapper.Map<LocalidadEditViewModel>(localidadEditDto);
            localidadVm.Provincia = mapper
                .Map<List<ProvinciaListViewModel>>(serviciosProvincia.GetLista());

            return View(localidadVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LocalidadEditViewModel localidadVm)
        {
            if (!ModelState.IsValid)
            {
                localidadVm.Provincia = mapper
                    .Map<List<ProvinciaListViewModel>>(serviciosProvincia.GetLista());
                return View(localidadVm);
            }

            LocalidadEditDto localidadDto = mapper.Map<LocalidadEditDto>(localidadVm);
            if (servicio.Existe(localidadDto))
            {
                ModelState.AddModelError(string.Empty, @"Localidad existente...");

                localidadVm.Provincia = mapper
                    .Map<List<ProvinciaListViewModel>>(serviciosProvincia.GetLista());
                return View(localidadVm);
            }
            try
            {
                servicio.Guardar(localidadDto);
                TempData["Msg"] = "Localidad editada...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);

                localidadVm.Provincia = mapper
                    .Map<List<ProvinciaListViewModel>>(serviciosProvincia.GetLista());
                return View(localidadVm);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            LocalidadEditDto localidadEditDto = servicio.GetLocalidadPorId(id);
            if (localidadEditDto == null)
            {
                return HttpNotFound("Código de localidad inexistente...");
            }

            LocalidadListDto localidadDto = mapper.Map<LocalidadListDto>(servicio.GetLocalidadPorId(id));
            var provincia = serviciosProvincia.GetProvinciaId(localidadEditDto.ProvinciaId);
            localidadDto.Provincia = provincia.NombreProvincia;

            LocalidadListViewModel localidadVm = mapper.Map<LocalidadListViewModel>(localidadDto);

            return View(localidadVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(LocalidadListViewModel localidadVm)
        {
            try
            {
                LocalidadListDto localidadDto = mapper
                    .Map<LocalidadListDto>(servicio.GetLocalidadPorId(localidadVm.LocalidadId));
                localidadVm = mapper.Map<LocalidadListViewModel>(localidadDto);

                servicio.Borrar(localidadVm.LocalidadId);
                TempData["Msg"] = "Registro borrado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
                return View(localidadVm);
            }
        }
    }
}