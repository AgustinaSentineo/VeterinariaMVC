using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VeterinariaMVC.Entidades.DTOs.Medicamento;
using VeterinariaMVC.Entidades.ViewModels.FormaFarmaceutica;
using VeterinariaMVC.Entidades.ViewModels.Laboratorio;
using VeterinariaMVC.Entidades.ViewModels.Medicamento;
using VeterinariaMVC.Entidades.ViewModels.TipoDeMedicamento;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariaMVC.Web.Classes;

namespace VeterinariaMVC.Web.Controllers
{
    public class MedicamentoController : Controller
    {
        private readonly IServicioMedicamento _servicio;
        private readonly IServicioTipoDeMedicamento _serviciosTipoMedicamento;
        private readonly IServicioFormaFarmaceutica _servicioFormaFarmaceutica;
        private readonly IServicioLaboratorio _servicioLaboratorio;

        private readonly IMapper _mapper;

        private readonly string folder = "~/Content/Imagenes/Medicamentos/";
        public MedicamentoController(IServicioMedicamento servicio, IServicioFormaFarmaceutica serviciosFormaFarmaceutica, 
            IServicioTipoDeMedicamento servicioTipoDeMedicamento, IServicioLaboratorio servicioLaboratorio)
        {
            _servicio = servicio;
            _serviciosTipoMedicamento = servicioTipoDeMedicamento;
            _servicioFormaFarmaceutica = serviciosFormaFarmaceutica;
            _servicioLaboratorio = servicioLaboratorio;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }
        // GET: Medicamento
        public ActionResult Index()
        {
            var listaDto = _servicio.GetLista();
            var listaVm = _mapper.Map<List<MedicamentoListViewModel>>(listaDto);


            return View(listaVm);
        }

        [HttpGet]
        public ActionResult Create()
        {
            MedicamentoEditViewModel medicamentoVm = new MedicamentoEditViewModel
            {
                Imagen = $"ImagenNoDisponible.jpg",
                TipoDeMedicamento = _mapper
                    .Map<List<TipoDeMedicamentoListViewModel>>(_serviciosTipoMedicamento.GetTipoDeMedicamento()),
                FormaFarmaceutica = _mapper
                    .Map<List<FormaFarmaceuticaListViewModel>>(_servicioFormaFarmaceutica.GetFormaFarmaceutica()),
                Laboratorio = _mapper
                    .Map<List<LaboratorioListViewModel>>(_servicioLaboratorio.GetLaboratorio()),
               

            };
            return View(medicamentoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MedicamentoEditViewModel medicamentoVm)
        {
            if (!ModelState.IsValid)
            {
                medicamentoVm.Imagen = $"ImagenNoDisponible.jpg";
                medicamentoVm.TipoDeMedicamento = _mapper
                                 .Map<List<TipoDeMedicamentoListViewModel>>(_serviciosTipoMedicamento.GetTipoDeMedicamento());
                medicamentoVm.FormaFarmaceutica = _mapper
                    .Map<List<FormaFarmaceuticaListViewModel>>(_servicioFormaFarmaceutica.GetFormaFarmaceutica());
                medicamentoVm.Laboratorio = _mapper
                    .Map<List<LaboratorioListViewModel>>(_servicioLaboratorio.GetLaboratorio());
                return View(medicamentoVm);
            }

            MedicamentoEditDto medicamentoDto = _mapper.Map<MedicamentoEditDto>(medicamentoVm);
            if (_servicio.Existe(medicamentoDto))
            {
                ModelState.AddModelError(string.Empty, @"Medicamento existente...");
                medicamentoVm.Imagen = $"ImagenNoDisponible.jpg";
                medicamentoVm.TipoDeMedicamento = _mapper
                                 .Map<List<TipoDeMedicamentoListViewModel>>(_serviciosTipoMedicamento.GetTipoDeMedicamento());
                medicamentoVm.FormaFarmaceutica = _mapper
                    .Map<List<FormaFarmaceuticaListViewModel>>(_servicioFormaFarmaceutica.GetFormaFarmaceutica());
                medicamentoVm.Laboratorio = _mapper
                    .Map<List<LaboratorioListViewModel>>(_servicioLaboratorio.GetLaboratorio());
                return View(medicamentoVm);
            }

            try
            {
                if (medicamentoVm.ImagenFile != null)
                {
                    medicamentoDto.Imagen = $"{medicamentoVm.ImagenFile.FileName}";
                }

                _servicio.Guardar(medicamentoDto);

                if (medicamentoVm.ImagenFile != null)
                {
                    var file = $"{medicamentoVm.ImagenFile.FileName}";
                    var response = FileHelper.UploadPhoto(medicamentoVm.ImagenFile, folder, file);
                }

                TempData["Msg"] = "Medicamento agregado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                medicamentoVm.TipoDeMedicamento = _mapper
                                .Map<List<TipoDeMedicamentoListViewModel>>(_serviciosTipoMedicamento.GetTipoDeMedicamento());
                medicamentoVm.FormaFarmaceutica = _mapper
                    .Map<List<FormaFarmaceuticaListViewModel>>(_servicioFormaFarmaceutica.GetFormaFarmaceutica());
                medicamentoVm.Laboratorio = _mapper
                    .Map<List<LaboratorioListViewModel>>(_servicioLaboratorio.GetLaboratorio());
                return View(medicamentoVm);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MedicamentoEditDto medicamentoEditDto = _servicio.GetMedicamentoPorId(id);
            MedicamentoEditViewModel medicamentoVm = _mapper.Map<MedicamentoEditViewModel>(medicamentoEditDto);
            medicamentoVm.TipoDeMedicamento = _mapper
                                .Map<List<TipoDeMedicamentoListViewModel>>(_serviciosTipoMedicamento.GetTipoDeMedicamento());
            medicamentoVm.FormaFarmaceutica = _mapper
                .Map<List<FormaFarmaceuticaListViewModel>>(_servicioFormaFarmaceutica.GetFormaFarmaceutica());
            medicamentoVm.Laboratorio = _mapper
                .Map<List<LaboratorioListViewModel>>(_servicioLaboratorio.GetLaboratorio());
            if (medicamentoVm.Imagen == null)
            {
                medicamentoVm.Imagen = $"ImagenNoDisponible.jpg";
            }
            else
            {
                medicamentoVm.Imagen = $"{medicamentoVm.Imagen}";
            }

            return View(medicamentoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MedicamentoEditViewModel medicamentoVm)
        {
            if (!ModelState.IsValid)
            {
                medicamentoVm.Imagen = $"ImagenNoDisponible.jpg";

                medicamentoVm.TipoDeMedicamento = _mapper
                                .Map<List<TipoDeMedicamentoListViewModel>>(_serviciosTipoMedicamento.GetTipoDeMedicamento());
                medicamentoVm.FormaFarmaceutica = _mapper
                    .Map<List<FormaFarmaceuticaListViewModel>>(_servicioFormaFarmaceutica.GetFormaFarmaceutica());
                medicamentoVm.Laboratorio = _mapper
                    .Map<List<LaboratorioListViewModel>>(_servicioLaboratorio.GetLaboratorio());
                return View(medicamentoVm);
            }

            MedicamentoEditDto medicamentoDto = _mapper.Map<MedicamentoEditDto>(medicamentoVm);
            if (_servicio.Existe(medicamentoDto))
            {
                ModelState.AddModelError(string.Empty, @"Medicamento existente...");
                medicamentoVm.Imagen = $"ImagenNoDisponible.jpg";
                medicamentoVm.TipoDeMedicamento = _mapper
                                .Map<List<TipoDeMedicamentoListViewModel>>(_serviciosTipoMedicamento.GetTipoDeMedicamento());
                medicamentoVm.FormaFarmaceutica = _mapper
                    .Map<List<FormaFarmaceuticaListViewModel>>(_servicioFormaFarmaceutica.GetFormaFarmaceutica());
                medicamentoVm.Laboratorio = _mapper
                    .Map<List<LaboratorioListViewModel>>(_servicioLaboratorio.GetLaboratorio());
                return View(medicamentoVm);
            }

            try
            {
                if (medicamentoVm.ImagenFile != null)
                {
                    medicamentoDto.Imagen = $"{medicamentoVm.ImagenFile.FileName}";
                }

                _servicio.Guardar(medicamentoDto);

                if (medicamentoVm.ImagenFile != null)
                {
                    var file = $"{medicamentoVm.ImagenFile.FileName}";
                    var response = FileHelper.UploadPhoto(medicamentoVm.ImagenFile, folder, file);
                }

                TempData["Msg"] = "Medicamento editado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                medicamentoVm.Imagen = $"{folder}ImagenNoDisponible.jpg";

                medicamentoVm.TipoDeMedicamento = _mapper
                                     .Map<List<TipoDeMedicamentoListViewModel>>(_serviciosTipoMedicamento.GetTipoDeMedicamento());
                medicamentoVm.FormaFarmaceutica = _mapper
                    .Map<List<FormaFarmaceuticaListViewModel>>(_servicioFormaFarmaceutica.GetFormaFarmaceutica());
                medicamentoVm.Laboratorio = _mapper
                    .Map<List<LaboratorioListViewModel>>(_servicioLaboratorio.GetLaboratorio());
                return View(medicamentoVm);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MedicamentoEditDto medicamentoEditDto = _servicio.GetMedicamentoPorId(id);
            if (medicamentoEditDto == null)
            {
                return HttpNotFound("Código de medicamento inexistente...");
            }

            MedicamentoListDto medicamentoDto = _mapper.Map<MedicamentoListDto>(_servicio.GetMedicamentoPorId(id));
            var tipoDeMedicamento = _serviciosTipoMedicamento.GetTipoDeMedicamentoPorId(medicamentoEditDto.TipoDeMedicamentoId);
            medicamentoDto.TipoDeMedicamento= tipoDeMedicamento.Descripcion;           
            MedicamentoListViewModel medicamentoVm = _mapper.Map<MedicamentoListViewModel>(medicamentoDto);

            return View(medicamentoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(MedicamentoListViewModel medicamentoVm)
        {
            try
            {
                MedicamentoListDto medicamentoDto = _mapper
                    .Map<MedicamentoListDto>(_servicio.GetMedicamentoPorId(medicamentoVm.MedicamentoId));
                medicamentoVm = _mapper.Map<MedicamentoListViewModel>(medicamentoDto);

                _servicio.Borrar(medicamentoVm.MedicamentoId);
                TempData["Msg"] = "Registro borrado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
                return View(medicamentoVm);
            }
        }
    }
}