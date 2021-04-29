using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using VeterinariaMVC.Entidades.DTOs.Empleado;
using VeterinariaMVC.Entidades.ViewModels.Empleado;
using VeterinariaMVC.Entidades.ViewModels.Localidad;
using VeterinariaMVC.Entidades.ViewModels.Provincia;
using VeterinariaMVC.Entidades.ViewModels.TipoDeDocumento;
using VeterinariaMVC.Entidades.ViewModels.TipoDeTarea;
using VeterinariaMVC.Servicios.Servicios.Facades;

namespace VeterinariaMVC.Web.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly IServicioEmpleado servicio;
        private readonly IServicioTipoDeDocumento servicioTipoDeDocumento;
        private readonly IServicioLocalidad servicioLocalidad;
        private readonly IServicioProvincia serviciosProvincia;
        private readonly IServicioTipoDeTarea servicioTipoTarea;

        private readonly IMapper mapper;
        public EmpleadoController(IServicioEmpleado _servicio, IServicioTipoDeDocumento _servicioTipo, IServicioLocalidad _servicioLocalidad, 
            IServicioProvincia _serviciosProvincia, IServicioTipoDeTarea _servicioTipoDeTarea)
        {
            servicio = _servicio;
            servicioTipoDeDocumento = _servicioTipo;
            servicioLocalidad = _servicioLocalidad;
            serviciosProvincia = _serviciosProvincia;
            servicioTipoTarea = _servicioTipoDeTarea;
            mapper = Mapeador.Mapeador.CrearMapper();
        }

        public ActionResult Index()
        {
            var listaDto = servicio.GetLista();
            var listaVm = mapper.Map<List<EmpleadoListViewModel>>(listaDto);


            return View(listaVm);
        }

        [HttpGet]
        public ActionResult Create()
        {
            EmpleadoEditViewModel empleadoVm = new EmpleadoEditViewModel
            {
                Provincia = mapper
                      .Map<List<ProvinciaListViewModel>>(serviciosProvincia.GetLista()),
                Localidad = mapper
                       .Map<List<LocalidadListViewModel>>(servicioLocalidad.GetLista(null)),
                TipoDeDocumento = mapper
                       .Map<List<TipoDeDocumentoListViewModel>>(servicioTipoDeDocumento.GetTipoDeDocumento()),
                TipoDeTarea = mapper
                       .Map<List<TipoDeTareaListViewModel>>(servicioTipoTarea.GetLista())
            };
            return View(empleadoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmpleadoEditViewModel empleadoVm)
        {
            if (!ModelState.IsValid)
            {
                empleadoVm.Provincia = mapper
                      .Map<List<ProvinciaListViewModel>>(serviciosProvincia.GetLista());
                empleadoVm.Localidad = mapper
                       .Map<List<LocalidadListViewModel>>(servicioLocalidad.GetLista(null));
                empleadoVm.TipoDeDocumento = mapper
                       .Map<List<TipoDeDocumentoListViewModel>>(servicioTipoDeDocumento.GetTipoDeDocumento());
                empleadoVm.TipoDeTarea = mapper
                      .Map<List<TipoDeTareaListViewModel>>(servicioTipoTarea.GetLista());
                return View(empleadoVm);
            }

            EmpleadoEditDto empleadoDto = mapper.Map<EmpleadoEditDto>(empleadoVm);
            if (servicio.Existe(empleadoDto))
            {
                ModelState.AddModelError(string.Empty, @"Empleado existente...");
                empleadoVm.Provincia = mapper
                      .Map<List<ProvinciaListViewModel>>(serviciosProvincia.GetLista());
                empleadoVm.Localidad = mapper
                       .Map<List<LocalidadListViewModel>>(servicioLocalidad.GetLista(null));
                empleadoVm.TipoDeDocumento = mapper
                       .Map<List<TipoDeDocumentoListViewModel>>(servicioTipoDeDocumento.GetTipoDeDocumento());
                empleadoVm.TipoDeTarea = mapper
                      .Map<List<TipoDeTareaListViewModel>>(servicioTipoTarea.GetLista());
                return View(empleadoVm);
            }

            try
            {
                servicio.Guardar(empleadoDto);
                TempData["Msg"] = "Empleado agregado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                empleadoVm.Provincia = mapper
                                  .Map<List<ProvinciaListViewModel>>(serviciosProvincia.GetLista());
                empleadoVm.Localidad = mapper
                       .Map<List<LocalidadListViewModel>>(servicioLocalidad.GetLista(null));
                empleadoVm.TipoDeDocumento = mapper
                       .Map<List<TipoDeDocumentoListViewModel>>(servicioTipoDeDocumento.GetTipoDeDocumento());
                empleadoVm.TipoDeTarea = mapper
                      .Map<List<TipoDeTareaListViewModel>>(servicioTipoTarea.GetLista());
                return View(empleadoVm);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EmpleadoEditDto empleadoEditDto = servicio.GetEmpleadoPorId(id);
            EmpleadoEditViewModel empleadoVm = mapper.Map<EmpleadoEditViewModel>(empleadoEditDto);
            empleadoVm.Provincia = mapper
                                 .Map<List<ProvinciaListViewModel>>(serviciosProvincia.GetLista());
            empleadoVm.Localidad = mapper
                   .Map<List<LocalidadListViewModel>>(servicioLocalidad.GetLista(null));
            empleadoVm.TipoDeDocumento = mapper
                   .Map<List<TipoDeDocumentoListViewModel>>(servicioTipoDeDocumento.GetTipoDeDocumento());
            empleadoVm.TipoDeTarea = mapper
                  .Map<List<TipoDeTareaListViewModel>>(servicioTipoTarea.GetLista());
            return View(empleadoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmpleadoEditViewModel empleadoVm)
        {
            if (!ModelState.IsValid)
            {
                empleadoVm.Provincia = mapper
                       .Map<List<ProvinciaListViewModel>>(serviciosProvincia.GetLista());
                empleadoVm.Localidad = mapper
                       .Map<List<LocalidadListViewModel>>(servicioLocalidad.GetLista(null));
                empleadoVm.TipoDeDocumento = mapper
                       .Map<List<TipoDeDocumentoListViewModel>>(servicioTipoDeDocumento.GetTipoDeDocumento());
                empleadoVm.TipoDeTarea = mapper
                      .Map<List<TipoDeTareaListViewModel>>(servicioTipoTarea.GetLista());
                return View(empleadoVm);
            }

            EmpleadoEditDto empleadoDto = mapper.Map<EmpleadoEditDto>(empleadoVm);
            if (servicio.Existe(empleadoDto))
            {
                ModelState.AddModelError(string.Empty, @"Empleado existente...");

                empleadoVm.Provincia = mapper
                     .Map<List<ProvinciaListViewModel>>(serviciosProvincia.GetLista());
                empleadoVm.Localidad = mapper
                       .Map<List<LocalidadListViewModel>>(servicioLocalidad.GetLista(null));
                empleadoVm.TipoDeDocumento = mapper
                       .Map<List<TipoDeDocumentoListViewModel>>(servicioTipoDeDocumento.GetTipoDeDocumento());
                empleadoVm.TipoDeTarea = mapper
                      .Map<List<TipoDeTareaListViewModel>>(servicioTipoTarea.GetLista());
                return View(empleadoVm);
            }
            try
            {
                servicio.Guardar(empleadoDto);
                TempData["Msg"] = "Empleado editada...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);

                empleadoVm.Provincia = mapper
                       .Map<List<ProvinciaListViewModel>>(serviciosProvincia.GetLista());
                empleadoVm.Localidad = mapper
                       .Map<List<LocalidadListViewModel>>(servicioLocalidad.GetLista(null));
                empleadoVm.TipoDeDocumento = mapper
                       .Map<List<TipoDeDocumentoListViewModel>>(servicioTipoDeDocumento.GetTipoDeDocumento());
                empleadoVm.TipoDeTarea = mapper
                      .Map<List<TipoDeTareaListViewModel>>(servicioTipoTarea.GetLista());
                return View(empleadoVm);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EmpleadoEditDto empleadoEditDto = servicio.GetEmpleadoPorId(id);
            if (empleadoEditDto == null)
            {
                return HttpNotFound("Código de empelado inexistente...");
            }

            EmpleadoListDto empleadoDto = mapper.Map<EmpleadoListDto>(servicio.GetEmpleadoPorId(id));
            EmpleadoListViewModel empleadoVm = mapper.Map<EmpleadoListViewModel>(empleadoDto);

            return View(empleadoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(EmpleadoListViewModel empleadoVm)
        {
            try
            {
                EmpleadoListDto empeladoDto = mapper
                    .Map<EmpleadoListDto>(servicio.GetEmpleadoPorId(empleadoVm.EmpleadoId));
                empleadoVm = mapper.Map<EmpleadoListViewModel>(empeladoDto);

                servicio.Borrar(empleadoVm.EmpleadoId);
                TempData["Msg"] = "Registro borrado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
                return View(empleadoVm);
            }
        }
    }
}
