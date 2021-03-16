using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VeterinariaMVC.Entidades.DTOs.Laboratorio;
using VeterinariaMVC.Entidades.ViewModels.Laboratorio;
using VeterinariaMVC.Servicios.Servicios.Facades;

namespace VeterinariaMVC.Web.Controllers
{
    public class LaboratorioController : Controller
    {
        // GET: Laboratorio
        private readonly IServicioLaboratorio servicio;
        private readonly IMapper mapper;

        public LaboratorioController(IServicioLaboratorio _servicio)
        {
            servicio = _servicio;
            mapper = Mapeador.Mapeador.CrearMapper();
        }

        public ActionResult Index()
        {
            var listaDto = servicio.GetLaboratorio();
            var lista = mapper.Map<List<LaboratorioListViewModel>>(listaDto);
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LaboratorioEditViewModel laboratorioVm)
        {
            if (!ModelState.IsValid)
            {
                return View(laboratorioVm);
            }

            LaboratorioEditDto laboratorioDto = mapper.Map<LaboratorioEditDto>(laboratorioVm);
            if (servicio.Existe(laboratorioDto))
            {
                ModelState.AddModelError(string.Empty, "Registro existente...");
                return View(laboratorioVm);
            }

            try
            {
                servicio.Guardar(laboratorioDto);
                TempData["Msg"] = "Registro agregado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(laboratorioVm);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            LaboratorioEditDto laboratorioDto = servicio.GetLaboratorioPorId(id);
            if (laboratorioDto == null)
            {
                return HttpNotFound("Código del laboratorio inexistente...");
            }

            LaboratorioEditViewModel laboratorioVm = mapper.Map<LaboratorioEditViewModel>(laboratorioDto);
            return View(laboratorioVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(LaboratorioEditViewModel laboratorioVm)
        {
            try
            {
                laboratorioVm = mapper.Map<LaboratorioEditViewModel>(servicio.GetLaboratorioPorId(laboratorioVm.LaboratorioId));

                servicio.Borrar(laboratorioVm.LaboratorioId);
                TempData["Msg"] = "Registro borrado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
                return View(laboratorioVm);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            LaboratorioEditDto laboratorioDto = servicio.GetLaboratorioPorId(id);
            LaboratorioEditViewModel laboratorioVm = mapper.Map<LaboratorioEditViewModel>(laboratorioDto);
            return View(laboratorioVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LaboratorioEditViewModel laboratorioVm)
        {
            if (!ModelState.IsValid)
            {
                return View(laboratorioVm);
            }

            LaboratorioEditDto laboratorioDto = mapper.Map<LaboratorioEditDto>(laboratorioVm);
            if (servicio.Existe(laboratorioDto))
            {
                ModelState.AddModelError(string.Empty, "Registro duplicado...");
                return View(laboratorioVm);
            }

            try
            {
                servicio.Guardar(laboratorioDto);
                TempData["Msg"] = "Registro modificado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(laboratorioVm);
            }
        }
    }
}