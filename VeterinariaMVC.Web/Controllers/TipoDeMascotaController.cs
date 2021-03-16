using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VeterinariaMVC.Entidades.DTOs.TipoDeMascota;
using VeterinariaMVC.Entidades.ViewModels.TipoDeMascota;
using VeterinariaMVC.Servicios.Servicios.Facades;

namespace VeterinariaMVC.Web.Controllers
{
    public class TipoDeMascotaController : Controller
    {
        private readonly IServicioTipoDeMascota servicio;
        private readonly IMapper mapper;

        public TipoDeMascotaController(IServicioTipoDeMascota _servicio)
        {
            servicio = _servicio;
            mapper = Mapeador.Mapeador.CrearMapper();
        }

        // GET: Provincias
        public ActionResult Index()
        {
            var listaDto = servicio.GetTipoDeMascota();
            var lista = mapper.Map<List<TipoDeMascotaListViewModel>>(listaDto);
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoDeMascotaEditViewModel tipoVm)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoVm);
            }

            TipoDeMascotaEditDto tipoDto = mapper.Map<TipoDeMascotaEditDto>(tipoVm);
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

            TipoDeMascotaEditDto tipoDto = servicio.GetTipoDeMascotaPorId(id);
            if (tipoDto == null)
            {
                return HttpNotFound("Código de Tipo de Mascota inexistente...");
            }

            TipoDeMascotaEditViewModel tipoVm = mapper.Map<TipoDeMascotaEditViewModel>(tipoDto);
            return View(tipoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TipoDeMascotaEditViewModel tipoVm)
        {
            try
            {
                tipoVm = mapper.Map<TipoDeMascotaEditViewModel>(servicio.GetTipoDeMascotaPorId(tipoVm.TipoDeMascotaId));

                servicio.Borrar(tipoVm.TipoDeMascotaId);
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

            TipoDeMascotaEditDto tipoDto = servicio.GetTipoDeMascotaPorId(id);
            TipoDeMascotaEditViewModel tipoVm = mapper.Map<TipoDeMascotaEditViewModel>(tipoDto);
            return View(tipoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoDeMascotaEditViewModel tipoVm)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoVm);
            }

            TipoDeMascotaEditDto tipoDto = mapper.Map<TipoDeMascotaEditDto>(tipoVm);
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