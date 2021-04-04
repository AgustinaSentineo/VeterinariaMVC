using AutoMapper;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VeterinariaMVC.Entidades.DTOs.Raza;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariaMVC.Windows.Ninject;

namespace VeterinariaMVC.Windows
{
    public partial class frmRaza : Form
    {
        public frmRaza(IServicioRaza servicio, IServicioTipoDeMascota servicioTipo)
        {
            InitializeComponent();
            this.servicio = servicio;
            this.servicioTipo = servicioTipo;
        }

        private IServicioRaza servicio;
        private IServicioTipoDeMascota servicioTipo;
        private IMapper mapper;
        private List<RazaListDto> lista;

        private void frmRaza_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
            mapper = VeterinariaMVC.Mapeador.Mapeador.CrearMapper();
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
            foreach (var razaDto in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, razaDto);
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

        private void SetearFila(DataGridViewRow r, RazaListDto raza)
        {
            r.Cells[cmnRaza.Index].Value = raza.Descripcion;
            r.Cells[cmnTipo.Index].Value = raza.TipoDeMascota;

            r.Tag = raza;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmRazaAE frm = DI.Create<frmRazaAE>();
            frm.Titulo("Nueva Raza");
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    RazaEditDto razaEditDto = frm.GetRaza();
                    if (servicio.Existe(razaEditDto))
                    {
                        frmMessageBox messageBox = new frmMessageBox();
                        messageBox.Show();
                        messageBox.ShowError("Raza Existente", $"{razaEditDto.Descripcion} ya existe en la base de datos");
                    }
                    servicio.Guardar(razaEditDto);
                    DataGridViewRow r = ConstruirFila();
                    RazaListDto razaListDto = mapper.Map<RazaListDto>(razaEditDto);
                    razaListDto.TipoDeMascota = (servicioTipo
                            .GetTipoDeMascotaPorId(razaEditDto.TipoDeMascotaId))
                            .Descripcion;
                    SetearFila(r, razaListDto);
                    AgregarFila(r);
                    frmMessageBox frmMessage = new frmMessageBox();
                    frmMessage.Show();
                    frmMessage.ShowInfo("Registro Agregado", $"{razaListDto.Descripcion} ya a sido agergado");
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
            var razaListDto = r.Tag as RazaListDto;
            frmMessageBox mb = new frmMessageBox();
            mb.ShowQuestion("Borrar Raza", $"¿Esta seguro que desea eliminar {razaListDto.Descripcion} del registro?");
            DialogResult dr = mb.ShowDialog(this);
            if (dr == DialogResult.No)
            {
                return;
            }
            try
            {

                servicio.Borrar(razaListDto.RazaId);
                dgvDatos.Rows.Remove(r);
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowInfo("Raza Borrada", $"{razaListDto.Descripcion} se borro de la base de datos");
             
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
            var razaListDto = r.Tag as RazaListDto;
            var razaCopia = (RazaListDto)razaListDto.Clone();
            frmRazaAE frm = DI.Create<frmRazaAE>();
            frm.Titulo("Editar Raza");
            RazaEditDto razaEditDto = servicio.GetRazaPorId(razaListDto.RazaId);
            frm.SetRaza(razaEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            razaEditDto = frm.GetRaza();
            if (servicio.Existe(razaEditDto))
            {
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowError("Raza Existente", $"{razaEditDto.Descripcion} ya existe en la base de datos");
                SetearFila(r, razaCopia);
                return;
            }
            try
            {
                servicio.Guardar(razaEditDto);
                var rListDto = mapper.Map<RazaListDto>(razaEditDto);
                razaListDto.TipoDeMascota = (servicioTipo
                          .GetTipoDeMascotaPorId(razaEditDto.TipoDeMascotaId))
                          .Descripcion;
                SetearFila(r, rListDto);
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowInfo("Raza Editada", $"{rListDto.Descripcion} " +
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            frmBuscarRaza frm = DI.Create<frmBuscarRaza>();
            frm.Titulo("Filtrar Razas");
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            var tipoDto = frm.GetTipo();
            try
            {
                lista = servicio.GetLista(tipoDto.Descripcion);
                MostrarDatosEnGrilla();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }
    }
}
