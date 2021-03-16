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
using VeterinariaMVC.Entidades.DTOs.TipoDeAlimento;
using VeterinariaMVC.Servicios.Servicios;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariaMVC.Windows.Ninject;

namespace VeterinariaMVC.Windows
{
    public partial class frmTipoDeAlimento : Form
    {
        public frmTipoDeAlimento(ServicioTipoDeAlimento servicio)
        {
            InitializeComponent();
            this.servicio = servicio;
        }

        private IServicioTipoDeAlimento servicio;
        private IMapper mapper;
        private List<TipoDeAlimentoListDto> lista;

        private void frmTipoDeAlimento_Load(object sender, EventArgs e)
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
            foreach (var tipoDto in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, tipoDto);
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

        private void SetearFila(DataGridViewRow r, TipoDeAlimentoListDto tipo)
        {
            r.Cells[cmnTipo.Index].Value = tipo.Descripcion;

            r.Tag = tipo;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmTipoDeAlimentoAE frm = DI.Create<frmTipoDeAlimentoAE>();
            frm.Titulo("Nueva Tipo de Alimento");
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    TipoDeAlimentoEditDto tipoEditDto = frm.GetTipo();
                    if (servicio.Existe(tipoEditDto))
                    {
                        frmMessageBox messageBox = new frmMessageBox();
                        messageBox.Show();
                        messageBox.ShowError("Tipo de Alimento Existente", $"{tipoEditDto.Descripcion} ya existe en la base de datos");
                    }
                    servicio.Guardar(tipoEditDto);
                    DataGridViewRow r = ConstruirFila();
                    TipoDeAlimentoListDto tipoListDto = mapper.Map<TipoDeAlimentoListDto>(tipoEditDto);
                    SetearFila(r, tipoListDto);
                    AgregarFila(r);
                    frmMessageBox frmMessage = new frmMessageBox();
                    frmMessage.Show();
                    frmMessage.ShowInfo("Registro Agregado", $"{tipoListDto.Descripcion} ya a sido agergado");
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
            var tipoListDto = r.Tag as TipoDeAlimentoListDto;
            frmMessageBox mb = new frmMessageBox();
            mb.ShowQuestion("Borrar Tipo de Alimento", $"¿Esta seguro que desea eliminar {tipoListDto.Descripcion} del registro?");
            DialogResult dr = mb.ShowDialog(this);
            if (dr == DialogResult.No)
            {
                return;
            }
            try
            {
                servicio.Borrar(tipoListDto.TipoDeAlimentoId);
                dgvDatos.Rows.Remove(r);
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowInfo("Tipo de Alimento Borrada", $"{tipoListDto.Descripcion} se borro de la base de datos");
             
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
            var tipoListDto = r.Tag as TipoDeAlimentoListDto;
            var tipoCopia = (TipoDeAlimentoListDto)tipoListDto.Clone();
            frmTipoDeAlimentoAE frm = DI.Create<frmTipoDeAlimentoAE>();
            frm.Titulo("Editar Tipo de Alimento");
            TipoDeAlimentoEditDto tipoEditDto = mapper.Map<TipoDeAlimentoEditDto>(tipoListDto);
            frm.SetTipo(tipoEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            tipoEditDto = frm.GetTipo();
            if (servicio.Existe(tipoEditDto))
            {
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowError("Tipo de Alimento Existente", $"{tipoEditDto.Descripcion} ya existe en la base de datos");
                SetearFila(r, tipoCopia);
                return;
            }
            try
            {
                servicio.Guardar(tipoEditDto);
                var tListDto = mapper.Map<TipoDeAlimentoListDto>(tipoEditDto);
                SetearFila(r, tListDto);
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowInfo("Tipo de Alimento Editada", $"{tListDto.Descripcion} " +
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
