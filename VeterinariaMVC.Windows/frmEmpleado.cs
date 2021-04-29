using AutoMapper;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VeterinariaMVC.Entidades.DTOs.Empleado;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariaMVC.Windows.Ninject;

namespace VeterinariaMVC.Windows
{
    public partial class frmEmpleado : Form
    {
        public frmEmpleado(IServicioEmpleado servicio, IServicioLocalidad servicioLocalidad,IServicioTipoDeTarea servicioTipoDeTarea,
            IServicioProvincia servicioProvincia, IServicioTipoDeDocumento servicioTipoDeDocumento)
        {
            InitializeComponent();
            this.servicio = servicio;
            this.servicioTipoDeTarea = servicioTipoDeTarea;
            this.servicioTipoDeDocumento = servicioTipoDeDocumento;
            this.servicioLocalidad = servicioLocalidad;
            this.servicioProvincia = servicioProvincia;
        }

        private IServicioEmpleado servicio;
        private IServicioTipoDeTarea servicioTipoDeTarea;
        private IServicioTipoDeDocumento servicioTipoDeDocumento;
        private IServicioLocalidad servicioLocalidad;
        private IServicioProvincia servicioProvincia;
        private IMapper mapper;

        private List<EmpleadoListDto> lista;
        private void frmEmpleado_Load(object sender, EventArgs e)
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
            foreach (var empeladoDto in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, empeladoDto);
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

        private void SetearFila(DataGridViewRow r, EmpleadoListDto empleado)
        {
            r.Cells[cmnNombre.Index].Value = empleado.Nombre;
            r.Cells[cmnTipo.Index].Value = empleado.TipoDeTarea;
            r.Cells[cmnEmail.Index].Value = empleado.CorreoElectronico;

            r.Tag = empleado;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmEmpleadoAE frm = DI.Create<frmEmpleadoAE>();
            frm.Titulo("Nuevo Empleado");
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    EmpleadoEditDto empleadoEditDto = frm.GetEmpleado();
                    if (servicio.Existe(empleadoEditDto))
                    {
                        frmMessageBox messageBox = new frmMessageBox();
                        messageBox.Show();
                        messageBox.ShowError("Empleado Existente", $"{empleadoEditDto.Nombre}, {empleadoEditDto.Apellido} ya existe en la base de datos");
                    }
                    servicio.Guardar(empleadoEditDto);
                    DataGridViewRow r = ConstruirFila();
                    EmpleadoListDto empleadoListDto = mapper.Map<EmpleadoListDto>(empleadoEditDto);
                    empleadoListDto.TipoDeTarea = (servicioTipoDeTarea
                            .GetTipoDeTareaId(empleadoEditDto.TipoDeTareaId))
                            .Descripcion;
                    SetearFila(r, empleadoListDto);
                    AgregarFila(r);
                    frmMessageBox frmMessage = new frmMessageBox();
                    frmMessage.Show();
                    frmMessage.ShowInfo("Registro Agregado", $"{empleadoListDto.Nombre} ya a sido agergado");
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
            var empleadoListDto = r.Tag as EmpleadoListDto;
            frmMessageBox mb = new frmMessageBox();
            mb.ShowQuestion("Borrar Empleado", $"¿Esta seguro que desea eliminar {empleadoListDto.Nombre} del registro?");
            DialogResult dr = mb.ShowDialog(this);
            if (dr == DialogResult.No)
            {
                return;
            }
            try
            {
                servicio.Borrar(empleadoListDto.EmpleadoId);
                dgvDatos.Rows.Remove(r);
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowInfo("Empleado Borrado", $"{empleadoListDto.Nombre} se borro de la base de datos");

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
            var empleadoListDto = r.Tag as EmpleadoListDto;
            var empleadoCopia = (EmpleadoListDto)empleadoListDto.Clone();
            frmEmpleadoAE frm = DI.Create<frmEmpleadoAE>();
            frm.Titulo("Editar Empleado");
            EmpleadoEditDto empleadoEditDto = servicio.GetEmpleadoPorId(empleadoListDto.EmpleadoId);
            frm.SetEmpleado(empleadoEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            empleadoEditDto = frm.GetEmpleado();
            if (servicio.Existe(empleadoEditDto))
            {
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowError("Empleado Existente", $"{empleadoEditDto.Nombre}, {empleadoEditDto.Apellido} ya existe en la base de datos");
                SetearFila(r, empleadoCopia);
                return;
            }
            try
            {
                servicio.Guardar(empleadoEditDto);
                var eListDto = mapper.Map<EmpleadoListDto>(empleadoEditDto);
                empleadoListDto.TipoDeTarea = (servicioTipoDeTarea
                          .GetTipoDeTareaId(empleadoEditDto.TipoDeTareaId))
                          .Descripcion;
                SetearFila(r, eListDto);
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowInfo("Empleado Editado", $"{eListDto.Nombre} " +
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
