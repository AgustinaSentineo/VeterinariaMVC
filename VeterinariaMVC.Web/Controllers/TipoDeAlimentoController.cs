using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VeterinariaMVC.Entidades.DTOs.TipoDeAlimento;
using VeterinariaMVC.Entidades.ViewModels.TipoDeAlimento;
using VeterinariaMVC.Servicios.Servicios.Facades;

namespace VeterinariaMVC.Web.Controllers
{
    public class TipoDeAlimentoController : Controller
    {
        private readonly IServicioTipoDeAlimento servicio;
        private readonly IMapper mapper;

        public TipoDeAlimentoController(IServicioTipoDeAlimento _servicio)
        {
            servicio = _servicio;
            mapper = Mapeador.Mapeador.CrearMapper();
        }
        public ActionResult Index()
        {
            var listaDto = servicio.GetLista();
            var lista = mapper.Map<List<TipoDeAlimentoListViewModel>>(listaDto);
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoDeAlimentoEditViewModel tipoDeAlimentoVm)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoDeAlimentoVm);
            }

            TipoDeAlimentoEditDto tipoDeAlimentoDto = mapper.Map<TipoDeAlimentoEditDto>(tipoDeAlimentoVm);
            if (servicio.Existe(tipoDeAlimentoDto))
            {
                ModelState.AddModelError(string.Empty, "Registro existente...");
                return View(tipoDeAlimentoVm);
            }

            try
            {
                servicio.Guardar(tipoDeAlimentoDto);
                TempData["Msg"] = "Registro agregado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(tipoDeAlimentoVm);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TipoDeAlimentoEditDto tipoDeAlimentoDto = servicio.GetTipoDeAlimentoId(id);
            if (tipoDeAlimentoDto == null)
            {
                return HttpNotFound("Código de Tipo de Alimento inexistente...");
            }

            TipoDeAlimentoEditViewModel tipoDeAlimentoVm = mapper.Map<TipoDeAlimentoEditViewModel>(tipoDeAlimentoDto);
            return View(tipoDeAlimentoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TipoDeAlimentoEditViewModel tipoDeAlimentoVm)
        {
            try
            {
                tipoDeAlimentoVm = mapper.Map<TipoDeAlimentoEditViewModel>(servicio.GetTipoDeAlimentoId(tipoDeAlimentoVm.TipoDeAlimentoId));

                servicio.Borrar(tipoDeAlimentoVm.TipoDeAlimentoId);
                TempData["Msg"] = "Registro borrado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
                return View(tipoDeAlimentoVm);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TipoDeAlimentoEditDto tipoDeAlimentoDto = servicio.GetTipoDeAlimentoId(id);
            TipoDeAlimentoEditViewModel tipoDeAlimentoVm = mapper.Map<TipoDeAlimentoEditViewModel>(tipoDeAlimentoDto);
            return View(tipoDeAlimentoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoDeAlimentoEditViewModel tipoDeAlimentoVm)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoDeAlimentoVm);
            }

            TipoDeAlimentoEditDto tipoDeAlimentoDto = mapper.Map<TipoDeAlimentoEditDto>(tipoDeAlimentoVm);
            if (servicio.Existe(tipoDeAlimentoDto))
            {
                ModelState.AddModelError(string.Empty, "Registro duplicado...");
                return View(tipoDeAlimentoVm);
            }

            try
            {
                servicio.Guardar(tipoDeAlimentoDto);
                TempData["Msg"] = "Registro modificado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(tipoDeAlimentoVm);
            }
        }
    }
}