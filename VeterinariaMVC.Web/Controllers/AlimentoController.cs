using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using VeterinariaMVC.Entidades.DTOs.Alimento;
using VeterinariaMVC.Entidades.ViewModels.Alimento;
using VeterinariaMVC.Entidades.ViewModels.Clasificacion;
using VeterinariaMVC.Entidades.ViewModels.Marca;
using VeterinariaMVC.Entidades.ViewModels.NecesidadEspecial;
using VeterinariaMVC.Entidades.ViewModels.TipoDeAlimento;
using VeterinariaMVC.Entidades.ViewModels.TipoDeMascota;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariaMVC.Web.Classes;

namespace VeterinariaMVC.Web.Controllers
{
    public class AlimentoController : Controller
    {
        private readonly IServicioAlimento _servicio;
        private readonly IServicioTipoDeAlimento _serviciosTipoAlimento;
        private readonly IServicioTipoDeMascota _servicioTipoDeMascota;
        private readonly IServicioClasificacion _servicioClasificacion;
        private readonly IServicioNecesidadEspecial _servicioNecesidadesEspeciales;
        private readonly IServicioMarca _servicioMarca;

        private readonly IMapper _mapper;

        private readonly string folder = "~/Content/Imagenes/Alimentos/";
        public AlimentoController(IServicioAlimento servicio, IServicioTipoDeAlimento serviciosTipoAlimento,IServicioTipoDeMascota servicioTipoDeMascota,
            IServicioClasificacion servicioClasificacion, IServicioNecesidadEspecial servicioNecedidadEspecial, IServicioMarca servicioMarca)
        {
            _servicio = servicio;
            _servicioClasificacion = servicioClasificacion;
            _servicioNecesidadesEspeciales = servicioNecedidadEspecial;
            _serviciosTipoAlimento = serviciosTipoAlimento;
            _servicioTipoDeMascota = servicioTipoDeMascota;
            _servicioMarca = servicioMarca;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        public ActionResult Index()
        {
            var listaDto = _servicio.GetLista();
            var listaVm = _mapper.Map<List<AlimentoListViewModel>>(listaDto);


            return View(listaVm);
        }

        [HttpGet]
        public ActionResult Create()
        {
            AlimentoEditViewModel alimentoVm = new AlimentoEditViewModel
            {
                Imagen = $"ImagenNoDisponible.jpg",
                TipoDeAlimento = _mapper
                    .Map<List<TipoDeAlimentoListViewModel>>(_serviciosTipoAlimento.GetLista()),
                Marca = _mapper
                    .Map<List<MarcaListViewModel>>(_servicioMarca.GetLista()),
                TipoDeMascota = _mapper
                    .Map<List<TipoDeMascotaListViewModel>>(_servicioTipoDeMascota.GetTipoDeMascota()),
                Clasificacion = _mapper
                    .Map<List<ClasificacionListViewModel>>(_servicioClasificacion.GetLista()),
                NecesidadesEspeciales = _mapper
                    .Map<List<NecesidadEspecialListViewModel>>(_servicioNecesidadesEspeciales.GetLista())

            };
            return View(alimentoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AlimentoEditViewModel alimentoVm)
        {
            if (!ModelState.IsValid)
            {
                alimentoVm.Imagen = $"ImagenNoDisponible.jpg";
                alimentoVm.TipoDeAlimento = _mapper
                     .Map<List<TipoDeAlimentoListViewModel>>(_serviciosTipoAlimento.GetLista());
                alimentoVm.Marca = _mapper
                    .Map<List<MarcaListViewModel>>(_servicioMarca.GetLista());
                alimentoVm.TipoDeMascota = _mapper
                    .Map<List<TipoDeMascotaListViewModel>>(_servicioTipoDeMascota.GetTipoDeMascota());                
                alimentoVm.Clasificacion = _mapper
                    .Map<List<ClasificacionListViewModel>>(_servicioClasificacion.GetLista());
                alimentoVm.NecesidadesEspeciales = _mapper
                    .Map<List<NecesidadEspecialListViewModel>>(_servicioNecesidadesEspeciales.GetLista());
                return View(alimentoVm);
            }

            AlimentoEditDto alimentoDto = _mapper.Map<AlimentoEditDto>(alimentoVm);
            if (_servicio.Existe(alimentoDto))
            {
                ModelState.AddModelError(string.Empty, @"Alimento existente...");
                alimentoVm.Imagen = $"ImagenNoDisponible.jpg";
                alimentoVm.TipoDeAlimento = _mapper
                      .Map<List<TipoDeAlimentoListViewModel>>(_serviciosTipoAlimento.GetLista());
                alimentoVm.Marca = _mapper
                    .Map<List<MarcaListViewModel>>(_servicioMarca.GetLista());
                alimentoVm.TipoDeMascota = _mapper
                    .Map<List<TipoDeMascotaListViewModel>>(_servicioTipoDeMascota.GetTipoDeMascota());      
                alimentoVm.Clasificacion = _mapper
                    .Map<List<ClasificacionListViewModel>>(_servicioClasificacion.GetLista());
                alimentoVm.NecesidadesEspeciales = _mapper
                    .Map<List<NecesidadEspecialListViewModel>>(_servicioNecesidadesEspeciales.GetLista());
                return View(alimentoVm);
            }

            try
            {
                if (alimentoVm.ImagenFile != null)
                {
                    alimentoDto.Imagen = $"{alimentoVm.ImagenFile.FileName}";
                }

                _servicio.Guardar(alimentoDto);

                if (alimentoVm.ImagenFile != null)
                {
                    var file = $"{alimentoVm.ImagenFile.FileName}";
                    var response = FileHelper.UploadPhoto(alimentoVm.ImagenFile, folder, file);
                }

                TempData["Msg"] = "Alimento agregado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                alimentoVm.TipoDeAlimento = _mapper
                     .Map<List<TipoDeAlimentoListViewModel>>(_serviciosTipoAlimento.GetLista());
                alimentoVm.Marca = _mapper
                    .Map<List<MarcaListViewModel>>(_servicioMarca.GetLista());
                alimentoVm.TipoDeMascota = _mapper
                    .Map<List<TipoDeMascotaListViewModel>>(_servicioTipoDeMascota.GetTipoDeMascota());
                alimentoVm.Clasificacion = _mapper
                    .Map<List<ClasificacionListViewModel>>(_servicioClasificacion.GetLista());
                alimentoVm.NecesidadesEspeciales = _mapper
                    .Map<List<NecesidadEspecialListViewModel>>(_servicioNecesidadesEspeciales.GetLista());
                return View(alimentoVm);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AlimentoEditDto alimentoEditDto = _servicio.GetAlimentoPorId(id);
            AlimentoEditViewModel alimentoVm = _mapper.Map<AlimentoEditViewModel>(alimentoEditDto);
            alimentoVm.TipoDeAlimento = _mapper
                      .Map<List<TipoDeAlimentoListViewModel>>(_serviciosTipoAlimento.GetLista());
            alimentoVm.Marca = _mapper
                .Map<List<MarcaListViewModel>>(_servicioMarca.GetLista());
            alimentoVm.TipoDeMascota = _mapper
                .Map<List<TipoDeMascotaListViewModel>>(_servicioTipoDeMascota.GetTipoDeMascota());
            alimentoVm.Clasificacion = _mapper
                .Map<List<ClasificacionListViewModel>>(_servicioClasificacion.GetLista());
            alimentoVm.NecesidadesEspeciales = _mapper
                .Map<List<NecesidadEspecialListViewModel>>(_servicioNecesidadesEspeciales.GetLista());
            if (alimentoVm.Imagen == null)
            {
                alimentoVm.Imagen = $"ImagenNoDisponible.jpg";
            }
            else
            {
                alimentoVm.Imagen = $"{alimentoVm.Imagen}";
            }

            return View(alimentoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AlimentoEditViewModel alimentoVm)
        {
            if (!ModelState.IsValid)
            {
                alimentoVm.Imagen = $"ImagenNoDisponible.jpg";

                alimentoVm.TipoDeAlimento = _mapper
                     .Map<List<TipoDeAlimentoListViewModel>>(_serviciosTipoAlimento.GetLista());
                alimentoVm.Marca = _mapper
                    .Map<List<MarcaListViewModel>>(_servicioMarca.GetLista());
                alimentoVm.TipoDeMascota = _mapper
                    .Map<List<TipoDeMascotaListViewModel>>(_servicioTipoDeMascota.GetTipoDeMascota());
                alimentoVm.Clasificacion = _mapper
                    .Map<List<ClasificacionListViewModel>>(_servicioClasificacion.GetLista());
                alimentoVm.NecesidadesEspeciales = _mapper
                    .Map<List<NecesidadEspecialListViewModel>>(_servicioNecesidadesEspeciales.GetLista());
                return View(alimentoVm);
            }

            AlimentoEditDto alimentoDto = _mapper.Map<AlimentoEditDto>(alimentoVm);
            if (_servicio.Existe(alimentoDto))
            {
                ModelState.AddModelError(string.Empty, @"Alimento existente...");
                alimentoVm.Imagen = $"ImagenNoDisponible.jpg";

                alimentoVm.TipoDeAlimento = _mapper
                     .Map<List<TipoDeAlimentoListViewModel>>(_serviciosTipoAlimento.GetLista());
                alimentoVm.Marca = _mapper
                    .Map<List<MarcaListViewModel>>(_servicioMarca.GetLista());
                alimentoVm.TipoDeMascota = _mapper
                    .Map<List<TipoDeMascotaListViewModel>>(_servicioTipoDeMascota.GetTipoDeMascota());
                alimentoVm.Clasificacion = _mapper
                    .Map<List<ClasificacionListViewModel>>(_servicioClasificacion.GetLista());
                alimentoVm.NecesidadesEspeciales = _mapper
                    .Map<List<NecesidadEspecialListViewModel>>(_servicioNecesidadesEspeciales.GetLista());
                return View(alimentoVm);
            }

            try
            {
                if (alimentoVm.ImagenFile != null)
                {
                    alimentoDto.Imagen = $"{alimentoVm.ImagenFile.FileName}";
                }

                _servicio.Guardar(alimentoDto);

                if (alimentoVm.ImagenFile != null)
                {
                    var file = $"{alimentoVm.ImagenFile.FileName}";
                    var response = FileHelper.UploadPhoto(alimentoVm.ImagenFile, folder, file);
                }

                TempData["Msg"] = "Alimento editado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                alimentoVm.Imagen = $"{folder}ImagenNoDisponible.jpg";

                alimentoVm.TipoDeAlimento = _mapper
                          .Map<List<TipoDeAlimentoListViewModel>>(_serviciosTipoAlimento.GetLista());
                alimentoVm.Marca = _mapper
                    .Map<List<MarcaListViewModel>>(_servicioMarca.GetLista());
                alimentoVm.TipoDeMascota = _mapper
                    .Map<List<TipoDeMascotaListViewModel>>(_servicioTipoDeMascota.GetTipoDeMascota());
                alimentoVm.Clasificacion = _mapper
                    .Map<List<ClasificacionListViewModel>>(_servicioClasificacion.GetLista());
                alimentoVm.NecesidadesEspeciales = _mapper
                    .Map<List<NecesidadEspecialListViewModel>>(_servicioNecesidadesEspeciales.GetLista());
                return View(alimentoVm);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AlimentoEditDto alimentoEditDto = _servicio.GetAlimentoPorId(id);
            if (alimentoEditDto == null)
            {
                return HttpNotFound("Código de alimento inexistente...");
            }

            AlimentoListDto alimentoDto = _mapper.Map<AlimentoListDto>(_servicio.GetAlimentoPorId(id));
            var marca = _servicioMarca.GetMarcaId(alimentoEditDto.MarcaId);
            alimentoDto.Marca = marca.Nombre;
            var clasificacion = _servicioClasificacion.GetClasificacionId(alimentoEditDto.ClasificacionId);
            alimentoDto.Clasificacion = clasificacion.Descripcion;
            AlimentoListViewModel alimentoVm = _mapper.Map<AlimentoListViewModel>(alimentoDto);

            return View(alimentoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(AlimentoListViewModel alimentoVm)
        {
            try
            {
                AlimentoListDto alimentoDto = _mapper
                    .Map<AlimentoListDto>(_servicio.GetAlimentoPorId(alimentoVm.AlimentoId));
                alimentoVm = _mapper.Map<AlimentoListViewModel>(alimentoDto);

                _servicio.Borrar(alimentoVm.AlimentoId);
                TempData["Msg"] = "Registro borrado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
                return View(alimentoVm);
            }
        }
    }
}