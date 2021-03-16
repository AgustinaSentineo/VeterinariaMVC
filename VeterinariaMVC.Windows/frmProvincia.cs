using AutoMapper;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VeterinariaMVC.Entities.DTOs.Provincia;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariaMVC.Windows.Ninject;

namespace VeterinariaMVC.Windows
{
    public partial class frmProvincia : Form
    {
        public frmProvincia(IServicioProvincia servicio)
        {
            InitializeComponent();
            this.servicio = servicio;
        }

        private IServicioProvincia servicio;
        private IMapper mapper;
        private List<ProvinciaListDto> lista;

        private void frmProvincia_Load(object sender, EventArgs e)
        {
            try
            {
                mapper = VeterinariaMVC.Mapeador.Mapeador.CrearMapper();
                lista = servicio.GetLista();
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
            foreach (var provinciaDto in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, provinciaDto);
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

        private void SetearFila(DataGridViewRow r, ProvinciaListDto provincia)
        {
            r.Cells[cmnProvincias.Index].Value = provincia.NombreProvincia;

            r.Tag = provincia;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmProvinciasAE frm = DI.Create<frmProvinciasAE>();
            frm.Titulo("Nueva Provincia");
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    ProvinciaEditDto provinciaEditDto = frm.GetProvincia();
                    if (servicio.Existe(provinciaEditDto))
                    {
                        frmMessageBox messageBox = new frmMessageBox();
                        messageBox.Show();
                        messageBox.ShowError("Provincia Existente", $"{provinciaEditDto.NombreProvincia} ya existe en la base de datos");
                    }
                    servicio.Guardar(provinciaEditDto);
                    DataGridViewRow r = ConstruirFila();
                    ProvinciaListDto provinciaListDto = mapper.Map<ProvinciaListDto>(provinciaEditDto);
                    SetearFila(r, provinciaListDto);
                    AgregarFila(r);
                    frmMessageBox frmMessage = new frmMessageBox();
                    frmMessage.Show();
                    frmMessage.ShowInfo("Registro Agregado", $"{provinciaListDto.NombreProvincia} ya a sido agergado");
                }
                catch (Exception)
                {
                    frmMessageBox frmMessage = new frmMessageBox();
                    frm.Show();
                    frmMessage.ShowError("Error", $"El registro no se pudo agregar. Intentelo nuevamente");
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow r = dgvDatos.SelectedRows[0];
            var provinciaListDto = r.Tag as ProvinciaListDto;
            frmMessageBox mb = new frmMessageBox();
            mb.ShowQuestion("Borrar Provincia", $"¿Esta seguro que desea eliminar {provinciaListDto.NombreProvincia} del registro?");
            DialogResult dr = mb.ShowDialog(this);
            if (dr == DialogResult.No)
            {
                return;
            }
            try
            {
                //if (!servicio.EstaRelacionado(provinciaListDto))
                //{

                servicio.Borrar(provinciaListDto.ProvinciaId);
                dgvDatos.Rows.Remove(r);
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowInfo("Provincia Borrada", $"{provinciaListDto.NombreProvincia} se borro de la base de datos");
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
            var provinciaListDto = r.Tag as ProvinciaListDto;
            var provinciaCopia = (ProvinciaListDto)provinciaListDto.Clone();
            frmProvinciasAE frm = DI.Create<frmProvinciasAE>();
            frm.Titulo("Editar Provincia");
            ProvinciaEditDto provinciaEditDto = mapper.Map<ProvinciaEditDto>(provinciaListDto);
            frm.SetProvincia(provinciaEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            provinciaEditDto = frm.GetProvincia();
            if (servicio.Existe(provinciaEditDto))
            {
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowError("Provincia Existente", $"{provinciaEditDto.NombreProvincia} ya existe en la base de datos");
                SetearFila(r, provinciaCopia);
                return;
            }
            try
            {
                servicio.Guardar(provinciaEditDto);
                var pListDto = mapper.Map<ProvinciaListDto>(provinciaEditDto);
                SetearFila(r, pListDto);
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowInfo("Provincia Editada", $"{pListDto.NombreProvincia} " +
                    $"ah sido editada correctamente");

            }
            catch (Exception)
            {
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowError("Error", $"Ocurrio un problema no se pudo completar la transaccion. Intentelo nuevamente.");
            }

        }
    }
}
