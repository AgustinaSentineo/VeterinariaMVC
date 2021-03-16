using AutoMapper;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VeterinariaMVC.Entidades.DTOs.Clasificacion;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariaMVC.Windows.Ninject;

namespace VeterinariaMVC.Windows
{
    public partial class frmClasificacion : Form
    {
        public frmClasificacion(IServicioClasificacion servicio)
        {
            InitializeComponent();
            this.servicio = servicio;
        }

        private IServicioClasificacion servicio;
        private IMapper mapper;
        private List<ClasificacionListDto> lista;

        private void frmClasificacion_Load(object sender, EventArgs e)
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
            foreach (var clasificacionDto in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, clasificacionDto);
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

        private void SetearFila(DataGridViewRow r, ClasificacionListDto clasificacion)
        {
            r.Cells[cmnClasificacion.Index].Value = clasificacion.Descripcion;

            r.Tag = clasificacion;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmClasificacionAE frm = DI.Create<frmClasificacionAE>();
            frm.Titulo("Nueva Clasificacion");
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    ClasificacionEditDto clasificacionEditDto = frm.GetClasificacion();
                    if (servicio.Existe(clasificacionEditDto))
                    {
                        frmMessageBox messageBox = new frmMessageBox();
                        messageBox.Show();
                        messageBox.ShowError("Clasificacion Existente", $"{clasificacionEditDto.Descripcion} ya existe en la base de datos");
                    }
                    servicio.Guardar(clasificacionEditDto);
                    DataGridViewRow r = ConstruirFila();
                    ClasificacionListDto clasificacionListDto = mapper.Map<ClasificacionListDto>(clasificacionEditDto);
                    SetearFila(r, clasificacionListDto);
                    AgregarFila(r);
                    frmMessageBox frmMessage = new frmMessageBox();
                    frmMessage.Show();
                    frmMessage.ShowInfo("Registro Agregado", $"{clasificacionListDto.Descripcion} ya a sido agergado");
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
            var clasificacionListDto = r.Tag as ClasificacionListDto;
            frmMessageBox mb = new frmMessageBox();
            mb.ShowQuestion("Borrar Clasificacion", $"¿Esta seguro que desea eliminar {clasificacionListDto.Descripcion} del registro?");
            DialogResult dr = mb.ShowDialog(this);
            if (dr == DialogResult.No)
            {
                return;
            }
            try
            {

                servicio.Borrar(clasificacionListDto.ClasificacionId);
                dgvDatos.Rows.Remove(r);
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowInfo("Clasificacion Borrada", $"{clasificacionListDto.Descripcion} se borro de la base de datos");
           
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
            var clasificacionListDto = r.Tag as ClasificacionListDto;
            var clasificacionCopia = (ClasificacionListDto)clasificacionListDto.Clone();
            frmClasificacionAE frm = DI.Create<frmClasificacionAE>();
            frm.Titulo("Editar Clasificacion");
            ClasificacionEditDto clasificacionEditDto = mapper.Map<ClasificacionEditDto>(clasificacionListDto);
            frm.SetClasificacion(clasificacionEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            clasificacionEditDto = frm.GetClasificacion();
            if (servicio.Existe(clasificacionEditDto))
            {
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowError("Clasificacion Existente", $"{clasificacionEditDto.Descripcion} ya existe en la base de datos");
                SetearFila(r, clasificacionCopia);
                return;
            }
            try
            {
                servicio.Guardar(clasificacionEditDto);
                var cListDto = mapper.Map<ClasificacionListDto>(clasificacionEditDto);
                SetearFila(r, cListDto);
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowInfo("Clasificacion Editada", $"{cListDto.Descripcion} " +
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
