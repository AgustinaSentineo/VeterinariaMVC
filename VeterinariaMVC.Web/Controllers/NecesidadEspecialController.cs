using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using VeterinariaMVC.Entidades.DTOs.NecesidadEspecial;
using VeterinariaMVC.Entidades.ViewModels.NecesidadEspecial;
using VeterinariaMVC.Servicios.Servicios.Facades;

namespace VeterinariaMVC.Web.Controllers
{
    public class NecesidadEspecialController : Controller
    {
        private readonly IServicioNecesidadEspecial servicio;
        private readonly IMapper mapper;

        public NecesidadEspecialController(IServicioNecesidadEspecial _servicio)
        {
            servicio = _servicio;
            mapper = Mapeador.Mapeador.CrearMapper();
        }

        public ActionResult Index()
        {
            var listaDto = servicio.GetLista();
            var lista = mapper.Map<List<NecesidadEspecialListViewModel>>(listaDto);
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NecesidadEspecialEditViewModel necesidadEspecialVm)
        {
            if (!ModelState.IsValid)
            {
                return View(necesidadEspecialVm);
            }

            NecesidadEspecialEditDto necesidadEspecialDto = mapper.Map<NecesidadEspecialEditDto>(necesidadEspecialVm);
            if (servicio.Existe(necesidadEspecialDto))
            {
                ModelState.AddModelError(string.Empty, "Registro existente...");
                return View(necesidadEspecialVm);
            }

            try
            {
                servicio.Guardar(necesidadEspecialDto);
                TempData["Msg"] = "Registro agregado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(necesidadEspecialVm);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            NecesidadEspecialEditDto necesidadEspecialDto = servicio.GetNecesidadEspecialId(id);
            if (necesidadEspecialDto == null)
            {
                return HttpNotFound("Código de Necesidades Especiales inexistente...");
            }

            NecesidadEspecialEditViewModel necesidadEspecialVm = mapper.Map<NecesidadEspecialEditViewModel>(necesidadEspecialDto);
            return View(necesidadEspecialVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(NecesidadEspecialEditViewModel necesidadEspecialVm)
        {
            try
            {
                necesidadEspecialVm = mapper.Map<NecesidadEspecialEditViewModel>(servicio.GetNecesidadEspecialId(necesidadEspecialVm.NecesidadesEspecialesId));

                servicio.Borrar(necesidadEspecialVm.NecesidadesEspecialesId);
                TempData["Msg"] = "Registro borrado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
                return View(necesidadEspecialVm);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            NecesidadEspecialEditDto necesidadEspecialDto = servicio.GetNecesidadEspecialId(id);
            NecesidadEspecialEditViewModel necesidadEspecialVm = mapper.Map<NecesidadEspecialEditViewModel>(necesidadEspecialDto);
            return View(necesidadEspecialVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NecesidadEspecialEditViewModel necesidadEspecialVm)
        {
            if (!ModelState.IsValid)
            {
                return View(necesidadEspecialVm);
            }

            NecesidadEspecialEditDto necesidadEspecialDto = mapper.Map<NecesidadEspecialEditDto>(necesidadEspecialVm);
            if (servicio.Existe(necesidadEspecialDto))
            {
                ModelState.AddModelError(string.Empty, "Registro duplicado...");
                return View(necesidadEspecialVm);
            }

            try
            {
                servicio.Guardar(necesidadEspecialDto);
                TempData["Msg"] = "Registro modificado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(necesidadEspecialVm);
            }
        }
    }
}