using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using VeterinariaMVC.Entidades.DTOs.Medicamento;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Mapeador;
using VeterinariMVC.Datos.Repositorios.Facades;

namespace VeterinariMVC.Datos.Repositorios
{
    public class RepositorioMedicamento : IRepositorioMedicamento
    {
        private readonly VeterinariaDbContext _context;
        private readonly IMapper _mapper;

        public RepositorioMedicamento(VeterinariaDbContext context)
        {
            _context = context;
            _mapper = Mapeador.CrearMapper();
        }
        public List<MedicamentoListDto> GetLista()
        {
            try
            {
                var lista = _context.Medicamentos
             .Select(p => new MedicamentoListDto
             {
                 MedicamentoId = p.MedicamentoId,
                 NombreComercial =p.NombreComercial,
                 TipoDeMedicamento=p.TipoDeMedicamento.Descripcion,
                 Suspendido=p.Suspendido,
                 PrecioVenta = p.PrecioVenta,
                 Imagen = p.Imagen
             }).ToList();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer los medicamentos");
            }
        }

        public MedicamentoEditDto GetMedocamentoPorId(int? id)
        {
            try
            {
                return _mapper
                    .Map<MedicamentoEditDto>(_context.Medicamentos
                    .Include(p => p.TipoDeMedicamento)
                    .Include(p => p.Laboratorio)
                    .Include(p => p.FormaFarmaceutica)
                        .SingleOrDefault(p => p.MedicamentoId == id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer  un medicamento");
            }
        }

        public void Guardar(Medicamento medicamento)
        {
            try
            {
                if (medicamento.MedicamentoId == 0)
                {
                    _context.Medicamentos.Add(medicamento);
                }
                else
                {
                    var medicamentoInDb = _context
                        .Medicamentos
                        .SingleOrDefault(p => p.MedicamentoId == medicamento.MedicamentoId);
                    medicamentoInDb.NombreComercial = medicamento.NombreComercial;
                    medicamentoInDb.TipoDeMedicamentoId = medicamento.TipoDeMedicamentoId;
                    medicamentoInDb.FormaFarmaceuticaId = medicamento.FormaFarmaceuticaId;
                    medicamentoInDb.LaboratorioId = medicamento.LaboratorioId;
                    medicamentoInDb.PrecioVenta = medicamento.PrecioVenta;
                    medicamentoInDb.UnidadesEnStock = medicamento.UnidadesEnStock;
                    medicamentoInDb.NivelDeReposicion = medicamento.NivelDeReposicion;
                    medicamentoInDb.CantidadesPorUnidad = medicamento.CantidadesPorUnidad;
                    medicamentoInDb.Suspendido = medicamento.Suspendido;
                    medicamentoInDb.Imagen = medicamento.Imagen;
                    _context.Entry(medicamentoInDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar guardar un medicamento");
            }
        }
        public void Borrar(int VmMedicamentoId)
        {
            try
            {
                var medicamentoInDb = _context.Medicamentos.SingleOrDefault(p => p.MedicamentoId == VmMedicamentoId);
                if (medicamentoInDb == null)
                {
                    throw new Exception("Medicamento inexistente...");

                }

                _context.Entry(medicamentoInDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar borrar un medicamento");
            }
        }

        public bool Existe(Medicamento medicamento)
        {
            if (medicamento.MedicamentoId == 0)
            {
                return _context.Medicamentos.Any(p => p.NombreComercial == medicamento.NombreComercial);
            }

            return _context.Medicamentos.Any(p => p.NombreComercial == medicamento.NombreComercial
            && p.MedicamentoId != medicamento.MedicamentoId);
        }

    }
}
