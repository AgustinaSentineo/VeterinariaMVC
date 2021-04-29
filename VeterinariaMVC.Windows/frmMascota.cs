using AutoMapper;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VeterinariaMVC.Entidades.DTOs.Mascota;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariaMVC.Windows.Ninject;

namespace VeterinariaMVC.Windows
{
    public partial class frmMascota : Form
    {
        public frmMascota( IServicioMascota servicio, IServicioCliente servicioCliente, IServicioRaza servicioRaza,
           IServicioTipoDeMascota servicioTipoDeMascota)
        {
            InitializeComponent();
            this.servicio = servicio;
            this.servicioTipoDeMascota= servicioTipoDeMascota;
            this.servicioRaza = servicioRaza;
        }

        private IServicioMascota servicio;
        private IServicioCliente servicioCliente;
        private IServicioTipoDeMascota servicioTipoDeMascota;
        private IServicioRaza servicioRaza;
        private IMapper mapper;

        private List<MascotaListDto> lista;
        private void frmMascota_Load(object sender, EventArgs e)
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
            foreach (var mascotaDto in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, mascotaDto);
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

        private void SetearFila(DataGridViewRow r, MascotaListDto mascota)
        {
            r.Cells[cmnNombre.Index].Value = mascota.Nombre;
            r.Cells[cmnCliente.Index].Value = mascota.Cliente;
            r.Cells[cmnTipo.Index].Value = mascota.TipoDeMascota;
            r.Cells[cmnFecha.Index].Value = mascota.FechaDeNacimiento.ToShortDateString();

            r.Tag = mascota;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmMascotaAE frm = DI.Create<frmMascotaAE>();
            frm.Titulo("Nueva Mascota");
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    MascotaEditDto mascotaEditDto = frm.GetMascota();
                    if (servicio.Existe(mascotaEditDto))
                    {
                        frmMessageBox messageBox = new frmMessageBox();
                        messageBox.Show();
                        messageBox.ShowError("Mascota Existente", $"{mascotaEditDto.Nombre} ya existe en la base de datos");
                    }
                    servicio.Guardar(mascotaEditDto);
                    DataGridViewRow r = ConstruirFila();
                    MascotaListDto mascotaListDto = mapper.Map<MascotaListDto>(mascotaEditDto);
                    mascotaListDto.Cliente = (servicioCliente
                            .GetClientePorId(mascotaEditDto.ClienteId))
                            .Nombre;
                    mascotaListDto.TipoDeMascota = (servicioTipoDeMascota
                        .GetTipoDeMascotaPorId(mascotaEditDto.TipoDeMascotaId))
                        .Descripcion;
                    SetearFila(r, mascotaListDto);
                    AgregarFila(r);
                    frmMessageBox frmMessage = new frmMessageBox();
                    frmMessage.Show();
                    frmMessage.ShowInfo("Registro Agregado", $"{mascotaListDto.Nombre} ya a sido agergado");
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
            var mascotaListDto = r.Tag as MascotaListDto;
            frmMessageBox mb = new frmMessageBox();
            mb.ShowQuestion("Borrar Mascota", $"¿Esta seguro que desea eliminar {mascotaListDto.Nombre} del registro?");
            DialogResult dr = mb.ShowDialog(this);
            if (dr == DialogResult.No)
            {
                return;
            }
            try
            {
                servicio.Borrar(mascotaListDto.MascotaId);
                dgvDatos.Rows.Remove(r);
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowInfo("Mascota Borrada", $"{mascotaListDto.Nombre} se borro de la base de datos");

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
            var mascotaListDto = r.Tag as MascotaListDto;
            var mascotaCopia = (MascotaListDto)mascotaListDto.Clone();
            frmMascotaAE frm = DI.Create<frmMascotaAE>();
            frm.Titulo("Editar Mascota");
            MascotaEditDto mascotaEditDto = servicio.GetMascotaPorId(mascotaListDto.MascotaId);
            frm.SetMascota(mascotaEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            mascotaEditDto = frm.GetMascota();
            if (servicio.Existe(mascotaEditDto))
            {
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowError("Mascota Existente", $"{mascotaEditDto.Nombre} ya existe en la base de datos");
                SetearFila(r, mascotaCopia);
                return;
            }
            try
            {
                servicio.Guardar(mascotaEditDto);
                var mListDto = mapper.Map<MascotaListDto>(mascotaEditDto);
                mascotaListDto.Cliente = (servicioCliente
                             .GetClientePorId(mascotaEditDto.ClienteId))
                             .Nombre;
                mascotaListDto.TipoDeMascota = (servicioTipoDeMascota
                    .GetTipoDeMascotaPorId(mascotaEditDto.TipoDeMascotaId))
                    .Descripcion;
                SetearFila(r, mListDto);
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowInfo("Mascota Editada", $"{mListDto.Nombre} " +
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
