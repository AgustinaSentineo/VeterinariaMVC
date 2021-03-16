using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VeterinariaMVC.Entidades.DTOs.TipoDeMedicamento;
using VeterinariaMVC.Entidades.ViewModels.TipoDeMedicamento;
using VeterinariaMVC.Servicios.Servicios.Facades;

namespace VeterinariaMVC.Web.Controllers
{
    public class TipoDeMedicamentoController : Controller
    {
        private readonly IServicioTipoDeMedicamento servicio;
        private readonly IMapper mapper;

        public TipoDeMedicamentoController(IServicioTipoDeMedicamento _servicio)
        {
            servicio = _servicio;
            mapper = Mapeador.Mapeador.CrearMapper();
        }
        public ActionResult Index()
        {
            var listaDto = servicio.GetTipoDeMedicamento();
            var lista = mapper.Map<List<TipoDeMedicamentoListViewModel>>(listaDto);
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoDeMedicamentoEditViewModel tipoVm)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoVm);
            }

            TipoDeMedicamentoEditDto tipoDto = mapper.Map<TipoDeMedicamentoEditDto>(tipoVm);
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

            TipoDeMedicamentoEditDto tipoDto = servicio.GetTipoDeMedicamentoPorId(id);
            if (tipoDto == null)
            {
                return HttpNotFound("Código de tipo de medicamento inexistente...");
            }

            TipoDeMedicamentoEditViewModel tipoVm = mapper.Map<TipoDeMedicamentoEditViewModel>(tipoDto);
            return View(tipoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TipoDeMedicamentoEditViewModel tipoVm)
        {
            try
            {
                tipoVm = mapper.Map<TipoDeMedicamentoEditViewModel>(servicio.GetTipoDeMedicamentoPorId(tipoVm.TipoDeMedicamentoId));

                servicio.Borrar(tipoVm.TipoDeMedicamentoId);
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

            TipoDeMedicamentoEditDto tipoDto = servicio.GetTipoDeMedicamentoPorId(id);
            TipoDeMedicamentoEditViewModel tipoVm = mapper.Map<TipoDeMedicamentoEditViewModel>(tipoDto);
            return View(tipoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoDeMedicamentoEditViewModel tipoVm)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoVm);
            }

            TipoDeMedicamentoEditDto tipoDto = mapper.Map<TipoDeMedicamentoEditDto>(tipoVm);
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