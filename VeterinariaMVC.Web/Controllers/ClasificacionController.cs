using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using VeterinariaMVC.Entidades.DTOs.Clasificacion;
using VeterinariaMVC.Entidades.ViewModels.Clasificacion;
using VeterinariaMVC.Servicios.Servicios.Facades;

namespace VeterinariaMVC.Web.Controllers
{
    public class ClasificacionController : Controller
    {
        private readonly IServicioClasificacion servicio;
        private readonly IMapper mapper;

        public ClasificacionController(IServicioClasificacion _servicio)
        {
            servicio = _servicio;
            mapper = Mapeador.Mapeador.CrearMapper();
        }
        public ActionResult Index()
        {
            var listaDto = servicio.GetLista();
            var lista = mapper.Map<List<ClasificacionListViewModel>>(listaDto);
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClasificacionEditViewModel clasificacionVm)
        {
            if (!ModelState.IsValid)
            {
                return View(clasificacionVm);
            }

            ClasificacionEditDto clasificacionDto = mapper.Map<ClasificacionEditDto>(clasificacionVm);
            if (servicio.Existe(clasificacionDto))
            {
                ModelState.AddModelError(string.Empty, "Registro existente...");
                return View(clasificacionVm);
            }

            try
            {
                servicio.Guardar(clasificacionDto);
                TempData["Msg"] = "Registro agregado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(clasificacionVm);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ClasificacionEditDto clasificacionDto = servicio.GetClasificacionId(id);
            if (clasificacionDto == null)
            {
                return HttpNotFound("Código de Clasificacion inexistente...");
            }

            ClasificacionEditViewModel clasificacionVm = mapper.Map<ClasificacionEditViewModel>(clasificacionDto);
            return View(clasificacionVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ClasificacionEditViewModel clasificacionVm)
        {
            try
            {
                clasificacionVm = mapper.Map<ClasificacionEditViewModel>(servicio.GetClasificacionId(clasificacionVm.ClasificacionId));

                servicio.Borrar(clasificacionVm.ClasificacionId);
                TempData["Msg"] = "Registro borrado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
                return View(clasificacionVm);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ClasificacionEditDto clasificacionDto = servicio.GetClasificacionId(id);
            ClasificacionEditViewModel clasificacionVm = mapper.Map<ClasificacionEditViewModel>(clasificacionDto);
            return View(clasificacionVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClasificacionEditViewModel clasificacionVm)
        {
            if (!ModelState.IsValid)
            {
                return View(clasificacionVm);
            }

            ClasificacionEditDto clasificacionDto = mapper.Map<ClasificacionEditDto>(clasificacionVm);
            if (servicio.Existe(clasificacionDto))
            {
                ModelState.AddModelError(string.Empty, "Registro duplicado...");
                return View(clasificacionVm);
            }

            try
            {
                servicio.Guardar(clasificacionDto);
                TempData["Msg"] = "Registro modificado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(clasificacionVm);
            }
        }
    }
}