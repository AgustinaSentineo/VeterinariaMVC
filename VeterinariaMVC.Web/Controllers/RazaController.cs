using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VeterinariaMVC.Entidades.DTOs.Raza;
using VeterinariaMVC.Entidades.ViewModels.Raza;
using VeterinariaMVC.Entidades.ViewModels.TipoDeMascota;
using VeterinariaMVC.Servicios.Servicios.Facades;

namespace VeterinariaMVC.Web.Controllers
{
    public class RazaController : Controller
    {
        private readonly IServicioRaza servicio;
        private readonly IServicioTipoDeMascota serviciosTipo;

        private readonly IMapper mapper;
        public RazaController(IServicioRaza _servicio, IServicioTipoDeMascota _serviciosTipo)
        {
            servicio = _servicio;
            serviciosTipo = _serviciosTipo;
            mapper = Mapeador.Mapeador.CrearMapper();
        }
        // GET: Raza
        public ActionResult Index(string tipoMascota = null)
        {
            var listaDto = servicio.GetLista(tipoMascota);
            var listaVm = mapper.Map<List<RazaListViewModel>>(listaDto);

            var razaFilterVm = new RazaFilterListViewModel
            {
                Raza = listaVm,
                TipoDeMascota = mapper.Map<List<TipoDeMascotaListViewModel>>(serviciosTipo.GetTipoDeMascota())
            };
            return View(razaFilterVm);
        }

        [HttpGet]
        public ActionResult Create()
        {
            RazaEditViewModel razaVm = new RazaEditViewModel
            {
                TipoDeMascota = mapper
                    .Map<List<TipoDeMascotaListViewModel>>(serviciosTipo.GetTipoDeMascota())
            };
            return View(razaVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RazaEditViewModel razaVm)
        {
            if (!ModelState.IsValid)
            {
                razaVm.TipoDeMascota = mapper
                     .Map<List<TipoDeMascotaListViewModel>>(serviciosTipo.GetTipoDeMascota());
                return View(razaVm);
            }

            RazaEditDto razaDto = mapper.Map<RazaEditDto>(razaVm);
            if (servicio.Existe(razaDto))
            {
                ModelState.AddModelError(string.Empty, @"Raza existente...");
                razaVm.TipoDeMascota = mapper
                    .Map<List<TipoDeMascotaListViewModel>>(serviciosTipo.GetTipoDeMascota());
                return View(razaVm);
            }

            try
            {
                servicio.Guardar(razaDto);
                TempData["Msg"] = "Raza agregado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                razaVm.TipoDeMascota = mapper
                    .Map<List<TipoDeMascotaListViewModel>>(serviciosTipo.GetTipoDeMascota());
                return View(razaVm);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RazaEditDto razaEditDto = servicio.GetRazaPorId(id);
            RazaEditViewModel razaVm = mapper.Map<RazaEditViewModel>(razaEditDto);
            razaVm.TipoDeMascota= mapper
                .Map<List<TipoDeMascotaListViewModel>>(serviciosTipo.GetTipoDeMascota());

            return View(razaVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RazaEditViewModel razaVm)
        {
            if (!ModelState.IsValid)
            {
                razaVm.TipoDeMascota = mapper
                    .Map<List<TipoDeMascotaListViewModel>>(serviciosTipo.GetTipoDeMascota());
                return View(razaVm);
            }

            RazaEditDto razaDto = mapper.Map<RazaEditDto>(razaVm);
            if (servicio.Existe(razaDto))
            {
                ModelState.AddModelError(string.Empty, @"Raza existente...");

                razaVm.TipoDeMascota = mapper
                    .Map<List<TipoDeMascotaListViewModel>>(serviciosTipo.GetTipoDeMascota());
                return View(razaVm);
            }
            try
            {
                servicio.Guardar(razaDto);
                TempData["Msg"] = "Raza editada...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);

                razaVm.TipoDeMascota = mapper
                    .Map<List<TipoDeMascotaListViewModel>>(serviciosTipo.GetTipoDeMascota());
                return View(razaVm);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RazaEditDto razaEditDto = servicio.GetRazaPorId(id);
            if (razaEditDto == null)
            {
                return HttpNotFound("Código de raza inexistente...");
            }

            RazaListDto razaDto = mapper.Map<RazaListDto>(servicio.GetRazaPorId(id));
            var tipo = serviciosTipo.GetTipoDeMascotaPorId(razaEditDto.TipoDeMascotaId);
            razaDto.TipoDeMascota = tipo.Descripcion;

            RazaListViewModel razaVm = mapper.Map<RazaListViewModel>(razaDto);

            return View(razaVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete (RazaListViewModel razaVm)
        {
            try
            {
                RazaListDto razaDto = mapper
                    .Map<RazaListDto>(servicio.GetRazaPorId(razaVm.RazaId));
                razaVm = mapper.Map<RazaListViewModel>(razaDto);

                servicio.Borrar(razaVm.RazaId);
                TempData["Msg"] = "Registro borrado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
                return View(razaVm);
            }
        }
    }
}