using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using VeterinariaMVC.Entidades.DTOs.Mascota;
using VeterinariaMVC.Entidades.ViewModels.Cliente;
using VeterinariaMVC.Entidades.ViewModels.Mascota;
using VeterinariaMVC.Entidades.ViewModels.Raza;
using VeterinariaMVC.Entidades.ViewModels.TipoDeMascota;
using VeterinariaMVC.Servicios.Servicios.Facades;

namespace VeterinariaMVC.Web.Controllers
{
    public class MascotaController : Controller
    {
        private readonly IServicioMascota servicio;
        private readonly IServicioCliente servicioCliente;
        private readonly IServicioTipoDeMascota servicioTipoDeMascota;
        private readonly IServicioRaza servicioRaza;

        private readonly IMapper mapper;
        public MascotaController(IServicioMascota _servicio,IServicioCliente _servicioCliente, 
            IServicioTipoDeMascota _servicioTipo, IServicioRaza _servicioRaza)
        {
            servicio = _servicio;
            servicioTipoDeMascota = _servicioTipo;
            servicioCliente = _servicioCliente;
            servicioRaza = _servicioRaza;
            mapper = Mapeador.Mapeador.CrearMapper();
        }

        public ActionResult Index()
        {
            var listaDto = servicio.GetLista();
            var listaVm = mapper.Map<List<MascotaListViewModel>>(listaDto);


            return View(listaVm);
        }

        [HttpGet]
        public ActionResult Create()
        {
            MascotaEditViewModel mascotaVm = new MascotaEditViewModel
            {
                Cliente = mapper
                      .Map<List<ClienteListViewModel>>(servicioCliente.GetLista()),
                TipoDeMascota = mapper
                       .Map<List<TipoDeMascotaListViewModel>>(servicioTipoDeMascota.GetTipoDeMascota()),
                Raza = mapper
                       .Map<List<RazaListViewModel>>(servicioRaza.GetLista(null)),
            };
            return View(mascotaVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MascotaEditViewModel mascotaVm)
        {
            if (!ModelState.IsValid)
            {
                mascotaVm.Cliente = mapper
                        .Map<List<ClienteListViewModel>>(servicioCliente.GetLista());
                mascotaVm.TipoDeMascota = mapper
                       .Map<List<TipoDeMascotaListViewModel>>(servicioTipoDeMascota.GetTipoDeMascota());
                mascotaVm.Raza = mapper
                       .Map<List<RazaListViewModel>>(servicioRaza.GetLista(null));
                return View(mascotaVm);
            }

            MascotaEditDto mascotaDto = mapper.Map<MascotaEditDto>(mascotaVm);
            if (servicio.Existe(mascotaDto))
            {
                ModelState.AddModelError(string.Empty, @"Mascota existente...");

                mascotaVm.Cliente = mapper
                        .Map<List<ClienteListViewModel>>(servicioCliente.GetLista());
                mascotaVm.TipoDeMascota = mapper
                       .Map<List<TipoDeMascotaListViewModel>>(servicioTipoDeMascota.GetTipoDeMascota());
                mascotaVm.Raza = mapper
                       .Map<List<RazaListViewModel>>(servicioRaza.GetLista(null));
                return View(mascotaVm);
            }

            try
            {
                servicio.Guardar(mascotaDto);
                TempData["Msg"] = "Mascota agregado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);

                mascotaVm.Cliente = mapper
                        .Map<List<ClienteListViewModel>>(servicioCliente.GetLista());
                mascotaVm.TipoDeMascota = mapper
                       .Map<List<TipoDeMascotaListViewModel>>(servicioTipoDeMascota.GetTipoDeMascota());
                mascotaVm.Raza = mapper
                       .Map<List<RazaListViewModel>>(servicioRaza.GetLista(null));
                return View(mascotaVm);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MascotaEditDto mascotaEditDto = servicio.GetMascotaPorId(id);
            MascotaEditViewModel mascotaVm = mapper.Map<MascotaEditViewModel>(mascotaEditDto);

            mascotaVm.Cliente = mapper
                    .Map<List<ClienteListViewModel>>(servicioCliente.GetLista());
            mascotaVm.TipoDeMascota = mapper
                   .Map<List<TipoDeMascotaListViewModel>>(servicioTipoDeMascota.GetTipoDeMascota());
            mascotaVm.Raza = mapper
                   .Map<List<RazaListViewModel>>(servicioRaza.GetLista(null));
            return View(mascotaVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MascotaEditViewModel mascotaVm)
        {
            if (!ModelState.IsValid)
            {
                mascotaVm.Cliente = mapper
                        .Map<List<ClienteListViewModel>>(servicioCliente.GetLista());
                mascotaVm.TipoDeMascota = mapper
                       .Map<List<TipoDeMascotaListViewModel>>(servicioTipoDeMascota.GetTipoDeMascota());
                mascotaVm.Raza = mapper
                       .Map<List<RazaListViewModel>>(servicioRaza.GetLista(null));
                return View(mascotaVm);
            }

            MascotaEditDto mascotaDto = mapper.Map<MascotaEditDto>(mascotaVm);
            if (servicio.Existe(mascotaDto))
            {
                ModelState.AddModelError(string.Empty, @"Mascota existente...");
                mascotaVm.Cliente = mapper
                        .Map<List<ClienteListViewModel>>(servicioCliente.GetLista());
                mascotaVm.TipoDeMascota = mapper
                       .Map<List<TipoDeMascotaListViewModel>>(servicioTipoDeMascota.GetTipoDeMascota());
                mascotaVm.Raza = mapper
                       .Map<List<RazaListViewModel>>(servicioRaza.GetLista(null));
                return View(mascotaVm);
            }
            try
            {
                servicio.Guardar(mascotaDto);
                TempData["Msg"] = "Mascota editada...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);

                mascotaVm.Cliente = mapper
                        .Map<List<ClienteListViewModel>>(servicioCliente.GetLista());
                mascotaVm.TipoDeMascota = mapper
                       .Map<List<TipoDeMascotaListViewModel>>(servicioTipoDeMascota.GetTipoDeMascota());
                mascotaVm.Raza = mapper
                       .Map<List<RazaListViewModel>>(servicioRaza.GetLista(null));
                return View(mascotaVm);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MascotaEditDto mascotaEditDto = servicio.GetMascotaPorId(id);
            if (mascotaEditDto == null)
            {
                return HttpNotFound("Código de mascota inexistente...");
            }

            MascotaListDto mascotaDto = mapper.Map<MascotaListDto>(servicio.GetMascotaPorId(id));
            MascotaListViewModel mascotaVm = mapper.Map<MascotaListViewModel>(mascotaDto);

            return View(mascotaVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(MascotaListViewModel mascotaVm)
        {
            try
            {
                MascotaListDto mascotaDto = mapper
                    .Map<MascotaListDto>(servicio.GetMascotaPorId(mascotaVm.MascotaId));
                mascotaVm = mapper.Map<MascotaListViewModel>(mascotaDto);

                servicio.Borrar(mascotaVm.MascotaId);
                TempData["Msg"] = "Registro borrado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
                return View(mascotaVm);
            }
        }
    }
}