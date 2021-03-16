using AutoMapper;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VeterinariaMVC.Entidades.DTOs.Localidad;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariaMVC.Windows.Ninject;

namespace VeterinariaMVC.Windows
{
    public partial class frmLocalidad : Form
    {
        public frmLocalidad(IServicioLocalidad servicio, IServicioProvincia servicioProvincia)
        {
            InitializeComponent();
            this.servicio = servicio;
            this.servicioProvincia = servicioProvincia;
        }

        private IServicioLocalidad servicio;
        private IServicioProvincia servicioProvincia;
        private IMapper mapper;
        private List<LocalidadListDto> lista;

        private void frmLocalidad_Load(object sender, EventArgs e)
        {
            mapper = VeterinariaMVC.Mapeador.Mapeador.CrearMapper();
            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            try
            {
                lista = servicio.GetLista(null);
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
            foreach (var localidadDto in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, localidadDto);
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

        private void SetearFila(DataGridViewRow r, LocalidadListDto localidad)
        {
            r.Cells[cmnLocalidad.Index].Value = localidad.NombreLocalidad;
            r.Cells[cmnProvincias.Index].Value = localidad.Provincia;

            r.Tag = localidad;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmLocalidadAE frm = DI.Create<frmLocalidadAE>();
            frm.Titulo("Nueva Localidad");
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    LocalidadEditDto localidadEditDto = frm.GetLocalidad();
                    if (servicio.Existe(localidadEditDto))
                    {
                        frmMessageBox messageBox = new frmMessageBox();
                        messageBox.Show();
                        messageBox.ShowError("Localidad Existente", $"{localidadEditDto.NombreLocalidad} ya existe en la base de datos");
                    }
                    servicio.Guardar(localidadEditDto);
                    DataGridViewRow r = ConstruirFila();
                    LocalidadListDto localidadListDto = mapper.Map<LocalidadListDto>(localidadEditDto);
                    localidadListDto.Provincia = (servicioProvincia
                            .GetProvinciaId(localidadEditDto.ProvinciaId))
                            .NombreProvincia;
                    SetearFila(r, localidadListDto);
                    AgregarFila(r);
                    frmMessageBox frmMessage = new frmMessageBox();
                    frmMessage.Show();
                    frmMessage.ShowInfo("Registro Agregado", $"{localidadListDto.NombreLocalidad} ya a sido agergado");
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
            var localidadListDto = r.Tag as LocalidadListDto;
            frmMessageBox mb = new frmMessageBox();
            mb.ShowQuestion("Borrar Localidad", $"¿Esta seguro que desea eliminar {localidadListDto.NombreLocalidad} del registro?");
            DialogResult dr = mb.ShowDialog(this);
            if (dr == DialogResult.No)
            {
                return;
            }
            try
            {
                //if (!servicio.EstaRelacionado(provinciaListDto))
                //{

                servicio.Borrar(localidadListDto.LocalidadId);
                dgvDatos.Rows.Remove(r);
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowInfo("Localidad Borrada", $"{localidadListDto.NombreLocalidad} se borro de la base de datos");
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
            var localidadListDto = r.Tag as LocalidadListDto;
            var localidadCopia = (LocalidadListDto)localidadListDto.Clone();
            frmLocalidadAE frm = DI.Create<frmLocalidadAE>();
            frm.Titulo("Editar Localidad");
            LocalidadEditDto localidadEditDto = mapper.Map<LocalidadEditDto>(localidadListDto);
            frm.SetLocalidad(localidadEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            localidadEditDto = frm.GetLocalidad();
            if (servicio.Existe(localidadEditDto))
            {
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowError("Localidad Existente", $"{localidadEditDto.NombreLocalidad} ya existe en la base de datos");
                SetearFila(r, localidadCopia);
                return;
            }
            try
            {
                servicio.Guardar(localidadEditDto);
                var lListDto = mapper.Map<LocalidadListDto>(localidadEditDto);
                localidadListDto.Provincia = (servicioProvincia
                          .GetProvinciaId(localidadEditDto.ProvinciaId))
                          .NombreProvincia;
                SetearFila(r, lListDto);
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowInfo("Localidad Editada", $"{lListDto.NombreLocalidad} " +
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscarLocalidad frm = DI.Create<frmBuscarLocalidad>();
            frm.Titulo("Filtrar Localidades");
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            var tipoDto = frm.GetProvincia();
            try
            {
                lista = servicio.GetLista(tipoDto.NombreProvincia);
                MostrarDatosEnGrilla();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }
    }
}
