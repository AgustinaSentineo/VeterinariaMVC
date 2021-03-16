using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeterinariaMVC.Entidades.DTOs.FormaFarmaceutica;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariaMVC.Windows.Ninject;

namespace VeterinariaMVC.Windows
{
    public partial class frmFormaFarmaceutica : Form
    {
        public frmFormaFarmaceutica(IServicioFormaFarmaceutica servicio)
        {
            InitializeComponent();
            this.servicio = servicio;
        }

        private IServicioFormaFarmaceutica servicio;
        private IMapper mapper;
        private List<FormaFarmaceuticaListDto> lista;
        private void frmFormaFarmaceutica_Load(object sender, EventArgs e)
        {
            try
            {
                mapper = VeterinariaMVC.Mapeador.Mapeador.CrearMapper();
                lista = servicio.GetFormaFarmaceutica();
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
            foreach (var formaDto in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, formaDto);
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

        private void SetearFila(DataGridViewRow r, FormaFarmaceuticaListDto forma)
        {
            r.Cells[cmnForma.Index].Value = forma.Descripcion;

            r.Tag = forma;
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmFormaFarmaceuticaAE frm = DI.Create<frmFormaFarmaceuticaAE>();
            frm.Titulo("Nueva Forma Farmaceutica");
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    FormaFarmaceuticaEditDto formaEditDto = frm.GetForma();
                    if (servicio.Existe(formaEditDto))
                    {
                        frmMessageBox messageBox = new frmMessageBox();
                        messageBox.Show();
                        messageBox.ShowError("Forma Farmaceutica Existente", $"{formaEditDto.Descripcion} ya existe en la base de datos");
                    }
                    servicio.Agregar(formaEditDto);
                    DataGridViewRow r = ConstruirFila();
                    FormaFarmaceuticaListDto formaListDto = mapper.Map<FormaFarmaceuticaListDto>(formaEditDto);
                    SetearFila(r, formaListDto);
                    AgregarFila(r);
                    frmMessageBox frmMessage = new frmMessageBox();
                    frmMessage.Show();
                    frmMessage.ShowInfo("Registro Agregado", $"{formaListDto.Descripcion} ya a sido agergado");
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
            var formaListDto = r.Tag as FormaFarmaceuticaListDto;
            frmMessageBox mb = new frmMessageBox();
            mb.ShowQuestion("Borrar Forma Farmaceutica", $"¿Esta seguro que desea eliminar {formaListDto.Descripcion} del registro?");
            DialogResult dr = mb.ShowDialog(this);
            if (dr == DialogResult.No)
            {
                return;
            }
            try
            {
                //if (!servicio.EstaRelacionado(provinciaListDto))
                //{

                servicio.Borrar(formaListDto.FormaFarmaceuticaId);
                dgvDatos.Rows.Remove(r);
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowInfo("Forma Farmaceutica Borrada", $"{formaListDto.Descripcion} se borro de la base de datos");
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
            var formaListDto = r.Tag as FormaFarmaceuticaListDto;
            var formaCopia = (FormaFarmaceuticaListDto)formaListDto.Clone();
            frmFormaFarmaceuticaAE frm = DI.Create<frmFormaFarmaceuticaAE>();
            frm.Titulo("Editar Forma Farmaceutica");
            FormaFarmaceuticaEditDto formaEditDto = mapper.Map<FormaFarmaceuticaEditDto>(formaListDto);
            frm.SetForma(formaEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            formaEditDto = frm.GetForma();
            if (servicio.Existe(formaEditDto))
            {
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowError("Forma Farmaceutica Existente", $"{formaEditDto.Descripcion} ya existe en la base de datos");
                SetearFila(r, formaCopia);
                return;
            }
            try
            {
                servicio.Agregar(formaEditDto);
                var fListDto = mapper.Map<FormaFarmaceuticaListDto>(formaEditDto);
                SetearFila(r, fListDto);
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowInfo("Forma Farmaceutica Editada", $"{fListDto.Descripcion} " +
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
