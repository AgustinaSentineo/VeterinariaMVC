using AutoMapper;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VeterinariaMVC.Entidades.DTOs.Laboratorio;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariaMVC.Windows.Ninject;

namespace VeterinariaMVC.Windows
{
    public partial class frmLaboratorio : Form
    {
        public frmLaboratorio(IServicioLaboratorio servicio)
        {
            InitializeComponent();
            this.servicio = servicio;
        }

        private IServicioLaboratorio servicio;
        private IMapper mapper;
        private List<LaboratorioListDto> lista;
        private void frmLaboratorio_Load(object sender, EventArgs e)
        {
            try
            {
                mapper = VeterinariaMVC.Mapeador.Mapeador.CrearMapper();
                lista = servicio.GetLaboratorio();
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var laboratorioDto in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, laboratorioDto);
                AgregarFila(r);
            }
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);

            return r;
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, LaboratorioListDto laboratorio)
        {
            r.Cells[cmnLab.Index].Value = laboratorio.Descripcion;

            r.Tag = laboratorio;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmLaboratorioAE frm = DI.Create<frmLaboratorioAE>();
            frm.Titulo("Nuevo Laboratorio");
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    LaboratorioEditDto labEditDto = frm.GetLaboratorio();
                    if (servicio.Existe(labEditDto))
                    {
                        frmMessageBox messageBox = new frmMessageBox();
                        messageBox.Show();
                        messageBox.ShowError("Laboratorio Existente", $"{labEditDto.Descripcion} ya existe en la base de datos");
                    }
                    servicio.Guardar(labEditDto);
                    DataGridViewRow r = ConstruirFila();
                    LaboratorioListDto labListDto = mapper.Map<LaboratorioListDto>(labEditDto);
                    SetearFila(r, labListDto);
                    AgregarFila(r);
                    frmMessageBox frmMessage = new frmMessageBox();
                    frmMessage.Show();
                    frmMessage.ShowInfo("Registro Agregado", $"{labListDto.Descripcion} ya a sido agergado");
                }
                catch (Exception)
                {
                    frmMessageBox frmMessage = new frmMessageBox();
                    frm.Show();
                    frmMessage.ShowError("Error", $"El registro no se pudo agregar. Intentelo nuevamente");
                }
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow r = dgvDatos.SelectedRows[0];
            var labListDto = r.Tag as LaboratorioListDto;
            frmMessageBox mb = new frmMessageBox();
            mb.ShowQuestion("Borrar Laboratorio", $"¿Esta seguro que desea eliminar {labListDto.Descripcion} del registro?");
            DialogResult dr = mb.ShowDialog(this);
            if (dr == DialogResult.No)
            {
                return;
            }
            try
            {
                //if (!servicio.EstaRelacionado(provinciaListDto))
                //{

                servicio.Borrar(labListDto.LaboratorioId);
                dgvDatos.Rows.Remove(r);
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowInfo("Laboratorio Borrada", $"{labListDto.Descripcion} se borro de la base de datos");
                //}
                //else
                //{
                //    frmMessageBox messageBox = new frmMessageBox();
                //    messageBox.Show();
                //    messageBox.ShowError("Provincia Relacionada", $"{provinciaListDto.NombreProvincia} esta relacionado con un registro en otra tabla. No puede ser borrado.");
                //}
            }
            catch (Exception)
            {
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowError("Error", $"Ocurrio un problema no se pudo completar la transaccion. Intentelo nuevamente.");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow r = dgvDatos.SelectedRows[0];
            var labListDto = r.Tag as LaboratorioListDto;
            var labCopia = (LaboratorioListDto)labListDto.Clone();
            frmLaboratorioAE frm = DI.Create<frmLaboratorioAE>();
            frm.Titulo("Editar Laboratorio");
            LaboratorioEditDto labEditDto = mapper.Map<LaboratorioEditDto>(labListDto);
            frm.SetLaboratorio(labEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            labEditDto = frm.GetLaboratorio();
            if (servicio.Existe(labEditDto))
            {
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowError("Laboratorio Existente", $"{labEditDto.Descripcion} ya existe en la base de datos");
                SetearFila(r, labCopia);
                return;
            }
            try
            {
                servicio.Guardar(labEditDto);
                var lListDto = mapper.Map<LaboratorioListDto>(labEditDto);
                SetearFila(r, lListDto);
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowInfo("Laboratorio Editada", $"{lListDto.Descripcion} " +
                    $"ah sido editada correctamente");

            }
            catch (Exception)
            {
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowError("Error", $"Ocurrio un problema no se pudo completar la transaccion. Intentelo nuevamente.");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
