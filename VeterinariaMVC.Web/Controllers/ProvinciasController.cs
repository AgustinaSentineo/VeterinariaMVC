using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using VeterinariaMVC.Entidades.ViewModels.Provincia;
using VeterinariaMVC.Entities.DTOs.Provincia;
using VeterinariaMVC.Servicios.Servicios.Facades;

namespace VeterinariaMVC.Web.Controllers
{
    public class ProvinciasController : Controller
    {
        private readonly IServicioProvincia servicio;
        private readonly IMapper mapper;

        public ProvinciasController(IServicioProvincia _servicio)
        {
            servicio = _servicio;
            mapper = Mapeador.Mapeador.CrearMapper();
        }

        // GET: Provincias
        public ActionResult Index()
        {
            var listaDto = servicio.GetLista();
            var lista = mapper.Map<List<ProvinciaListViewModel>>(listaDto);
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProvinciaEditViewModel provinciaVm)
        {
            if (!ModelState.IsValid)
            {
                return View(provinciaVm);
            }

            ProvinciaEditDto provinciaDto = mapper.Map<ProvinciaEditDto>(provinciaVm);
            if (servicio.Existe(provinciaDto))
            {
                ModelState.AddModelError(string.Empty, "Registro existente...");
                return View(provinciaVm);
            }

            try
            {
                servicio.Guardar(provinciaDto);
                TempData["Msg"] = "Registro agregado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(provinciaVm);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProvinciaEditDto provinciaDto = servicio.GetProvinciaId(id);
            if (provinciaDto == null)
            {
                return HttpNotFound("Código de provincia inexistente...");
            }

            ProvinciaEditViewModel provinciaVm = mapper.Map<ProvinciaEditViewModel>(provinciaDto);
            return View(provinciaVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProvinciaEditViewModel provinciaVm)
        {
            try
            {
                provinciaVm = mapper.Map<ProvinciaEditViewModel>(servicio.GetProvinciaId(provinciaVm.ProvinciaId));

                servicio.Borrar(provinciaVm.ProvinciaId);
                TempData["Msg"] = "Registro borrado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
                return View(provinciaVm);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProvinciaEditDto provinciaDto = servicio.GetProvinciaId(id);
            ProvinciaEditViewModel provinciaVm = mapper.Map<ProvinciaEditViewModel>(provinciaDto);
            return View(provinciaVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProvinciaEditViewModel provinciaVm)
        {
            if (!ModelState.IsValid)
            {
                return View(provinciaVm);
            }

            ProvinciaEditDto provinciaDto = mapper.Map<ProvinciaEditDto>(provinciaVm);
            if (servicio.Existe(provinciaDto))
            {
                ModelState.AddModelError(string.Empty, "Registro duplicado...");
                return View(provinciaVm);
            }

            try
            {
                servicio.Guardar(provinciaDto);
                TempData["Msg"] = "Registro modificado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(provinciaVm);
            }
        }
    }
}