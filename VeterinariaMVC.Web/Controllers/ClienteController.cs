using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using VeterinariaMVC.Entidades.DTOs.Cliente;
using VeterinariaMVC.Entidades.ViewModels.Cliente;
using VeterinariaMVC.Entidades.ViewModels.Localidad;
using VeterinariaMVC.Entidades.ViewModels.Provincia;
using VeterinariaMVC.Entidades.ViewModels.TipoDeDocumento;
using VeterinariaMVC.Servicios.Servicios.Facades;

namespace VeterinariaMVC.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IServicioCliente servicio;
        private readonly IServicioTipoDeDocumento servicioTipoDeDocumento;
        private readonly IServicioLocalidad servicioLocalidad;
        private readonly IServicioProvincia serviciosProvincia;

        private readonly IMapper mapper;
        public ClienteController(IServicioCliente _servicio, IServicioTipoDeDocumento _servicioTipo, IServicioLocalidad _servicioLocalidad, IServicioProvincia _serviciosProvincia)
        {
            servicio = _servicio;
            servicioTipoDeDocumento = _servicioTipo;
            servicioLocalidad = _servicioLocalidad;
            serviciosProvincia = _serviciosProvincia;
            mapper = Mapeador.Mapeador.CrearMapper();
        }

        public ActionResult Index()
        {
            var listaDto = servicio.GetLista();
            var listaVm = mapper.Map<List<ClienteListViewModel>>(listaDto);

         
            return View(listaVm);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ClienteEditViewModel clienteVm = new ClienteEditViewModel
            {
                Provincia = mapper
                      .Map<List<ProvinciaListViewModel>>(serviciosProvincia.GetLista()),                
                Localidad = mapper
                       .Map<List<LocalidadListViewModel>>(servicioLocalidad.GetLista(null)),
                TipoDeDocumento = mapper
                       .Map<List<TipoDeDocumentoListViewModel>>(servicioTipoDeDocumento.GetTipoDeDocumento())
            };
            return View(clienteVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteEditViewModel clienteVm)
        {
            if (!ModelState.IsValid)
            {
                clienteVm.Provincia = mapper
                      .Map<List<ProvinciaListViewModel>>(serviciosProvincia.GetLista());
                clienteVm.Localidad = mapper
                       .Map<List<LocalidadListViewModel>>(servicioLocalidad.GetLista(null));
                clienteVm.TipoDeDocumento = mapper
                       .Map<List<TipoDeDocumentoListViewModel>>(servicioTipoDeDocumento.GetTipoDeDocumento());
                return View(clienteVm);
            }

            ClienteEditDto clienteDto = mapper.Map<ClienteEditDto>(clienteVm);
            if (servicio.Existe(clienteDto))
            {
                ModelState.AddModelError(string.Empty, @"Cliente existente...");
                clienteVm.Provincia = mapper
                    .Map<List<ProvinciaListViewModel>>(serviciosProvincia.GetLista());
                clienteVm.Localidad = mapper
                      .Map<List<LocalidadListViewModel>>(servicioLocalidad.GetLista(null));
                clienteVm.TipoDeDocumento = mapper
                       .Map<List<TipoDeDocumentoListViewModel>>(servicioTipoDeDocumento.GetTipoDeDocumento());
                return View(clienteVm);
            }

            try
            {
                servicio.Guardar(clienteDto);
                TempData["Msg"] = "Localidad agregado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                clienteVm.Provincia = mapper
                    .Map<List<ProvinciaListViewModel>>(serviciosProvincia.GetLista());
                clienteVm.Localidad = mapper
                     .Map<List<LocalidadListViewModel>>(servicioLocalidad.GetLista(null));
                clienteVm.TipoDeDocumento = mapper
                       .Map<List<TipoDeDocumentoListViewModel>>(servicioTipoDeDocumento.GetTipoDeDocumento());
                return View(clienteVm);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ClienteEditDto clienteEditDto = servicio.GetClientePorId(id);
            ClienteEditViewModel clienteVm = mapper.Map<ClienteEditViewModel>(clienteEditDto);
            clienteVm.Provincia = mapper
                .Map<List<ProvinciaListViewModel>>(serviciosProvincia.GetLista());
            clienteVm.Localidad = mapper
                     .Map<List<LocalidadListViewModel>>(servicioLocalidad.GetLista(null));
            clienteVm.TipoDeDocumento = mapper
                   .Map<List<TipoDeDocumentoListViewModel>>(servicioTipoDeDocumento.GetTipoDeDocumento());
            return View(clienteVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteEditViewModel clienteVm)
        {
            if (!ModelState.IsValid)
            {
                clienteVm.Provincia = mapper
                    .Map<List<ProvinciaListViewModel>>(serviciosProvincia.GetLista());
                clienteVm.Localidad = mapper
                     .Map<List<LocalidadListViewModel>>(servicioLocalidad.GetLista(null));
                clienteVm.TipoDeDocumento = mapper
                       .Map<List<TipoDeDocumentoListViewModel>>(servicioTipoDeDocumento.GetTipoDeDocumento());
                return View(clienteVm);
            }

            ClienteEditDto clienteDto = mapper.Map<ClienteEditDto>(clienteVm);
            if (servicio.Existe(clienteDto))
            {
                ModelState.AddModelError(string.Empty, @"Cliente existente...");

                clienteVm.Provincia = mapper
                    .Map<List<ProvinciaListViewModel>>(serviciosProvincia.GetLista());
                clienteVm.Localidad = mapper
                    .Map<List<LocalidadListViewModel>>(servicioLocalidad.GetLista(null));
                clienteVm.TipoDeDocumento = mapper
                    .Map<List<TipoDeDocumentoListViewModel>>(servicioTipoDeDocumento.GetTipoDeDocumento());
                return View(clienteVm);
            }
            try
            {
                servicio.Guardar(clienteDto);
                TempData["Msg"] = "Cliente editada...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);

                clienteVm.Provincia = mapper
                    .Map<List<ProvinciaListViewModel>>(serviciosProvincia.GetLista());
                clienteVm.Localidad = mapper
                    .Map<List<LocalidadListViewModel>>(servicioLocalidad.GetLista(null));
                clienteVm.TipoDeDocumento = mapper
                    .Map<List<TipoDeDocumentoListViewModel>>(servicioTipoDeDocumento.GetTipoDeDocumento());
                return View(clienteVm);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ClienteEditDto clienteEditDto = servicio.GetClientePorId(id);
            if (clienteEditDto == null)
            {
                return HttpNotFound("Código de cliente inexistente...");
            }

            ClienteListDto clienteDto = mapper.Map<ClienteListDto>(servicio.GetClientePorId(id));
            ClienteListViewModel clienteVm = mapper.Map<ClienteListViewModel>(clienteDto);

            return View(clienteVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ClienteListViewModel clienteVm)
        {
            try
            {
                ClienteListDto clienteDto = mapper
                    .Map<ClienteListDto>(servicio.GetClientePorId(clienteVm.ClienteId));
                clienteVm = mapper.Map<ClienteListViewModel>(clienteDto);

                servicio.Borrar(clienteVm.ClienteId);
                TempData["Msg"] = "Registro borrado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
                return View(clienteVm);
            }
        }
    }
}
