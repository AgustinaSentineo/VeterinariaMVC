using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VeterinariaMVC.Datos.Repositorios.Facades;
using VeterinariaMVC.Entidades.DTOs.Laboratorio;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariMVC.Datos;

namespace VeterinariaMVC.Datos.Repositorios
{
    public class RepositorioLaboratorio : IRepositorioLaboratorio
    {
        private VeterinariaDbContext _context;
        private readonly IMapper _mapper;
        public RepositorioLaboratorio(VeterinariaDbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        public List<LaboratorioListDto> GetLista()
        {
            try
            {
                var lista = _context.Laboratorios.ToList();
                return _mapper.Map<List<LaboratorioListDto>>(lista);
            }
            catch (Exception)
            {
                throw new Exception("Error al leer los Laboratorios");
            }
        }

        public LaboratorioEditDto GetLaboratorioPorId(int? Id)
        {
            try
            {
                return _mapper
                    .Map<LaboratorioEditDto>(_context.Laboratorios.SingleOrDefault(l => l.LaboratorioId == Id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer el Id");
            }
        }

        public void Guardar(Laboratorio laboratorio)
        {
            try
            {
                if (laboratorio.LaboratorioId == 0)
                {
                    _context.Laboratorios.Add(laboratorio);
                }
                else
                {
                    var tipoDb = _context.Laboratorios.SingleOrDefault(l => l.LaboratorioId ==laboratorio.LaboratorioId);
                    tipoDb.Descripcion = laboratorio.Descripcion;

                    _context.Entry(tipoDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {

                throw new Exception("Error al Guardar/Editar el laboratorio");
            }
        }
        public void Borrar(int? id)
        {
            try
            {
                var tipoDb = _context.Laboratorios.SingleOrDefault(l => l.LaboratorioId == id);
                _context.Entry(tipoDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar borrar un laboratorio");
            }
        }

        public bool Existe(Laboratorio laboratorio)
        {
            if (laboratorio.LaboratorioId == 0)
            {
                return _context.Laboratorios.Any(l => l.Descripcion == laboratorio.Descripcion);
            }
            return _context.Laboratorios.Any(l => l.Descripcion == laboratorio.Descripcion &&
            l.LaboratorioId == laboratorio.LaboratorioId);
        }
        public bool EstaRelacionado(Laboratorio laboratorio)
        {
            throw new NotImplementedException();
        }

    }
}
