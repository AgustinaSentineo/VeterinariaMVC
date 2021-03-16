using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using VeterinariaMVC.Entidades.DTOs.Marca;
using VeterinariaMVC.Entidades.ViewModels.Marca;
using VeterinariaMVC.Servicios.Servicios.Facades;

namespace VeterinariaMVC.Web.Views
{
    public class MarcaController : Controller
    {
        private readonly IServicioMarca servicio;
        private readonly IMapper mapper;

        public MarcaController(IServicioMarca _servicio)
        {
            servicio = _servicio;
            mapper = Mapeador.Mapeador.CrearMapper();
        }

        public ActionResult Index()
        {
            var listaDto = servicio.GetLista();
            var lista = mapper.Map<List<MarcaListViewModel>>(listaDto);
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MarcaEditViewModel marcaVm)
        {
            if (!ModelState.IsValid)
            {
                return View(marcaVm);
            }

            MarcaEditDto marcaDto = mapper.Map<MarcaEditDto>(marcaVm);
            if (servicio.Existe(marcaDto))
            {
                ModelState.AddModelError(string.Empty, "Registro existente...");
                return View(marcaVm);
            }

            try
            {
                servicio.Guardar(marcaDto);
                TempData["Msg"] = "Registro agregado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(marcaVm);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MarcaEditDto marcaDto = servicio.GetMarcaId(id);
            if (marcaDto == null)
            {
                return HttpNotFound("Código de Marca inexistente...");
            }

            MarcaEditViewModel marcaVm = mapper.Map<MarcaEditViewModel>(marcaDto);
            return View(marcaVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(MarcaEditViewModel marcaVm)
        {
            try
            {
                marcaVm = mapper.Map<MarcaEditViewModel>(servicio.GetMarcaId(marcaVm.MarcaId));

                servicio.Borrar(marcaVm.MarcaId);
                TempData["Msg"] = "Registro borrado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
                return View(marcaVm);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MarcaEditDto marcaDto = servicio.GetMarcaId(id);
            MarcaEditViewModel marcaVm = mapper.Map<MarcaEditViewModel>(marcaDto);
            return View(marcaVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MarcaEditViewModel marcaVm)
        {
            if (!ModelState.IsValid)
            {
                return View(marcaVm);
            }

            MarcaEditDto marcaDto = mapper.Map<MarcaEditDto>(marcaVm);
            if (servicio.Existe(marcaDto))
            {
                ModelState.AddModelError(string.Empty, "Registro duplicado...");
                return View(marcaVm);
            }

            try
            {
                servicio.Guardar(marcaDto);
                TempData["Msg"] = "Registro modificado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(marcaVm);
            }
        }
    }
}