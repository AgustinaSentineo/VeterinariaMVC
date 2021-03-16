using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VeterinariaMVC.Entidades.DTOs.FormaFarmaceutica;
using VeterinariaMVC.Entidades.ViewModels.FormaFarmaceutica;
using VeterinariaMVC.Servicios.Servicios.Facades;

namespace VeterinariaMVC.Web.Controllers
{
    public class FormaFarmaceuticaController : Controller
    {
        private readonly IServicioFormaFarmaceutica servicio;
        private readonly IMapper mapper;

        public FormaFarmaceuticaController(IServicioFormaFarmaceutica _servicio)
        {
            servicio = _servicio;
            mapper = Mapeador.Mapeador.CrearMapper();
        }

        public ActionResult Index()
        {
            var listaDto = servicio.GetFormaFarmaceutica();
            var lista = mapper.Map<List<FormaFarmaceuticaListViewModel>>(listaDto);
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormaFarmaceuticaEditViewModel formaVm)
        {
            if (!ModelState.IsValid)
            {
                return View(formaVm);
            }

            FormaFarmaceuticaEditDto formaDto = mapper.Map<FormaFarmaceuticaEditDto>(formaVm);
            if (servicio.Existe(formaDto))
            {
                ModelState.AddModelError(string.Empty, "Registro existente...");
                return View(formaVm);
            }

            try
            {
                servicio.Agregar(formaDto);
                TempData["Msg"] = "Registro agregado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(formaVm);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            FormaFarmaceuticaEditDto formaDto = servicio.GetObjeto(id);
            if (formaDto == null)
            {
                return HttpNotFound("Código de forma farmaceutica inexistente...");
            }

            FormaFarmaceuticaEditViewModel formaVm = mapper.Map<FormaFarmaceuticaEditViewModel>(formaDto);
            return View(formaVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(FormaFarmaceuticaEditViewModel formaVm)
        {
            try
            {
                formaVm = mapper.Map<FormaFarmaceuticaEditViewModel>(servicio.GetObjeto(formaVm.FormaFarmaceuticaId));

                servicio.Borrar(formaVm.FormaFarmaceuticaId);
                TempData["Msg"] = "Registro borrado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
                return View(formaVm);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            FormaFarmaceuticaEditDto formaDto = servicio.GetObjeto(id);
            FormaFarmaceuticaEditViewModel formaVm = mapper.Map<FormaFarmaceuticaEditViewModel>(formaDto);
            return View(formaVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormaFarmaceuticaEditViewModel formaVm)
        {
            if (!ModelState.IsValid)
            {
                return View(formaVm);
            }

            FormaFarmaceuticaEditDto formaDto = mapper.Map<FormaFarmaceuticaEditDto>(formaVm);
            if (servicio.Existe(formaDto))
            {
                ModelState.AddModelError(string.Empty, "Registro duplicado...");
                return View(formaVm);
            }

            try
            {
                servicio.Agregar(formaDto);
                TempData["Msg"] = "Registro modificado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(formaVm);
            }
        }
    }
}
