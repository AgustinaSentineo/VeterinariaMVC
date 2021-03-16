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
using VeterinariaMVC.Entidades.DTOs.TipoDeProducto;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariaMVC.Windows.Ninject;

namespace VeterinariaMVC.Windows
{
    public partial class frmTipoDeProducto : Form
    {
        public frmTipoDeProducto(IServicioTipoDeProducto servicio)
        {
            InitializeComponent();
            this.servicio = servicio;
        }

        private IServicioTipoDeProducto servicio;
        private IMapper mapper;
        private List<TipoDeProductoListDto> lista;
        private void frmTipoDeProducto_Load(object sender, EventArgs e)
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

        private void SetearFila(DataGridViewRow r, TipoDeProductoListDto tipo)
        {
            r.Cells[cmnProducto.Index].Value = tipo.Descripcion;

            r.Tag = tipo;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmTipoDeProductoAE frm = DI.Create<frmTipoDeProductoAE>();
            frm.Titulo("Nueva Tipo De Producto");
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    TipoDeProductoEditDto tipoEditDto = frm.GetTipoDeProducto();
                    if (servicio.Existe(tipoEditDto))
                    {
                        frmMessageBox messageBox = new frmMessageBox();
                        messageBox.Show();
                        messageBox.ShowError("Tipo De Producto Existente", $"{tipoEditDto.Descripcion} ya existe en la base de datos");
                    }
                    servicio.Guardar(tipoEditDto);
                    DataGridViewRow r = ConstruirFila();
                    TipoDeProductoListDto tipoListDto = mapper.Map<TipoDeProductoListDto>(tipoEditDto);
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
            var tipoListDto = r.Tag as TipoDeProductoListDto;
            frmMessageBox mb = new frmMessageBox();
            mb.ShowQuestion("Borrar Tipo De Producto", $"¿Esta seguro que desea eliminar {tipoListDto.Descripcion} del registro?");
            DialogResult dr = mb.ShowDialog(this);
            if (dr == DialogResult.No)
            {
                return;
            }
            try
            {
                //if (!servicio.EstaRelacionado(provinciaListDto))
                //{

                servicio.Borrar(tipoListDto.TipoDeProductoId);
                dgvDatos.Rows.Remove(r);
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowInfo("Tipo De Producto Borrada", $"{tipoListDto.Descripcion} se borro de la base de datos");
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
            var tipoListDto = r.Tag as TipoDeProductoListDto;
            var tipoCopia = (TipoDeProductoListDto)tipoListDto.Clone();
            frmTipoDeProductoAE frm = DI.Create<frmTipoDeProductoAE>();
            frm.Titulo("Editar Tipo De Producto");
            TipoDeProductoEditDto tipoEditDto = mapper.Map<TipoDeProductoEditDto>(tipoListDto);
            frm.SetTipoDeProducto(tipoEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            tipoEditDto = frm.GetTipoDeProducto();
            if (servicio.Existe(tipoEditDto))
            {
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowError("TipoDeProducto Existente", $"{tipoEditDto.Descripcion} ya existe en la base de datos");
                SetearFila(r, tipoCopia);
                return;
            }
            try
            {
                servicio.Guardar(tipoEditDto);
                var tpListDto = mapper.Map<TipoDeProductoListDto>(tipoEditDto);
                SetearFila(r, tpListDto);
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowInfo("Tipo De Producto Editada", $"{tpListDto.Descripcion} " +
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
