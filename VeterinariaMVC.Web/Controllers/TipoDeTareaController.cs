using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VeterinariaMVC.Entidades.DTOs.TipoDeTarea;
using VeterinariaMVC.Entidades.ViewModels.TipoDeTarea;
using VeterinariaMVC.Servicios.Servicios.Facades;

namespace VeterinariaMVC.Web.Controllers
{
    public class TipoDeTareaController : Controller
    {
        private readonly IServicioTipoDeTarea servicio;
        private readonly IMapper mapper;

        public TipoDeTareaController(IServicioTipoDeTarea _servicio)
        {
            servicio = _servicio;
            mapper = Mapeador.Mapeador.CrearMapper();
        }

        public ActionResult Index()
        {
            var listaDto = servicio.GetLista();
            var lista = mapper.Map<List<TipoDeTareaListViewModel>>(listaDto);
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoDeTareaEditViewModel tipoVm)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoVm);
            }

            TipoDeTareaEditDto tipoDto = mapper.Map<TipoDeTareaEditDto>(tipoVm);
            if (servicio.Existe(tipoDto))
            {
                ModelState.AddModelError(string.Empty, "Registro existente...");
                return View(tipoVm);
            }

            try
            {
                servicio.Guardar(tipoDto);
                TempData["Msg"] = "Registro agregado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(tipoVm);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TipoDeTareaEditDto tipoDto = servicio.GetTipoDeTareaId(id);
            if (tipoDto == null)
            {
                return HttpNotFound("Código de Tipo De Tarea inexistente...");
            }

            TipoDeTareaEditViewModel tipoVm = mapper.Map<TipoDeTareaEditViewModel>(tipoDto);
            return View(tipoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TipoDeTareaEditViewModel tipoVm)
        {
            try
            {
                tipoVm = mapper.Map<TipoDeTareaEditViewModel>(servicio.GetTipoDeTareaId(tipoVm.TipoDeTareaId));

                servicio.Borrar(tipoVm.TipoDeTareaId);
                TempData["Msg"] = "Registro borrado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
                return View(tipoVm);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TipoDeTareaEditDto tipoDto = servicio.GetTipoDeTareaId(id);
            TipoDeTareaEditViewModel tipoVm = mapper.Map<TipoDeTareaEditViewModel>(tipoDto);
            return View(tipoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoDeTareaEditViewModel tipoVm)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoVm);
            }

            TipoDeTareaEditDto tipoDto = mapper.Map<TipoDeTareaEditDto>(tipoVm);
            if (servicio.Existe(tipoDto))
            {
                ModelState.AddModelError(string.Empty, "Registro duplicado...");
                return View(tipoVm);
            }

            try
            {
                servicio.Guardar(tipoDto);
                TempData["Msg"] = "Registro modificado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(tipoVm);
            }
        }
    }
}