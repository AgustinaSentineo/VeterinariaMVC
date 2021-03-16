using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using VeterinariaMVC.Entidades.DTOs.TipoDeDocumento;
using VeterinariaMVC.Entidades.ViewModels.TipoDeDocumento;
using VeterinariaMVC.Servicios.Servicios.Facades;

namespace VeterinariaMVC.Web.Controllers
{
    public class TipoDeDocumentoController : Controller
    {
        private readonly IServicioTipoDeDocumento servicio;
        private readonly IMapper mapper;

        public TipoDeDocumentoController(IServicioTipoDeDocumento _servicio)
        {
            servicio = _servicio;
            mapper = Mapeador.Mapeador.CrearMapper();
        }

        public ActionResult Index()
        {
            var listaDto = servicio.GetTipoDeDocumento();
            var lista = mapper.Map<List<TipoDeDocumentoListViewModel>>(listaDto);
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoDeDocumentoEditViewModel tipoVm)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoVm);
            }

            TipoDeDocumentoEditDto tipoDto = mapper.Map<TipoDeDocumentoEditDto>(tipoVm);
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

            TipoDeDocumentoEditDto tipoDto = servicio.GetTipoDeDocumentoPorId(id);
            if (tipoDto == null)
            {
                return HttpNotFound("Código de Tipo De Documento inexistente...");
            }

            TipoDeDocumentoEditViewModel tipoVm = mapper.Map<TipoDeDocumentoEditViewModel>(tipoDto);
            return View(tipoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TipoDeDocumentoEditViewModel tipoVm)
        {
            try
            {
                tipoVm = mapper.Map<TipoDeDocumentoEditViewModel>(servicio.GetTipoDeDocumentoPorId(tipoVm.TipoDeDocumentoId));

                servicio.Borrar(tipoVm.TipoDeDocumentoId);
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

            TipoDeDocumentoEditDto tipoDto = servicio.GetTipoDeDocumentoPorId(id);
            TipoDeDocumentoEditViewModel tipoVm = mapper.Map<TipoDeDocumentoEditViewModel>(tipoDto);
            return View(tipoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoDeDocumentoEditViewModel tipoVm)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoVm);
            }

            TipoDeDocumentoEditDto tipoDto = mapper.Map<TipoDeDocumentoEditDto>(tipoVm);
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