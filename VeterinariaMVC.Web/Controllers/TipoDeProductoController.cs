using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using VeterinariaMVC.Entidades.DTOs.TipoDeProducto;
using VeterinariaMVC.Entidades.ViewModels.TipoDeProducto;
using VeterinariaMVC.Servicios.Servicios.Facades;

namespace VeterinariaMVC.Web.Views
{
    public class TipoDeProductoController : Controller
    {
        private readonly IServicioTipoDeProducto servicio;
        private readonly IMapper mapper;

        public TipoDeProductoController(IServicioTipoDeProducto _servicio)
        {
            servicio = _servicio;
            mapper = Mapeador.Mapeador.CrearMapper();
        }

        public ActionResult Index()
        {
            var listaDto = servicio.GetLista();
            var lista = mapper.Map<List<TipoDeProductoListViewModel>>(listaDto);
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoDeProductoEditViewModel tipoVm)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoVm);
            }

            TipoDeProductoEditDto tipoDto = mapper.Map<TipoDeProductoEditDto>(tipoVm);
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

            TipoDeProductoEditDto tipoDto = servicio.GetTipoDeProductoId(id);
            if (tipoDto == null)
            {
                return HttpNotFound("Código de Tipo De Producto inexistente...");
            }

            TipoDeProductoEditViewModel tipoVm = mapper.Map<TipoDeProductoEditViewModel>(tipoDto);
            return View(tipoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TipoDeProductoEditViewModel tipoVm)
        {
            try
            {
                tipoVm = mapper.Map<TipoDeProductoEditViewModel>(servicio.GetTipoDeProductoId(tipoVm.TipoDeProductoId));

                servicio.Borrar(tipoVm.TipoDeProductoId);
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

            TipoDeProductoEditDto tipoDto = servicio.GetTipoDeProductoId(id);
            TipoDeProductoEditViewModel tipoVm = mapper.Map<TipoDeProductoEditViewModel>(tipoDto);
            return View(tipoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoDeProductoEditViewModel tipoVm)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoVm);
            }

            TipoDeProductoEditDto tipoDto = mapper.Map<TipoDeProductoEditDto>(tipoVm);
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