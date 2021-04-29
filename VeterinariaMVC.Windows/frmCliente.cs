using AutoMapper;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VeterinariaMVC.Entidades.DTOs.Cliente;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariaMVC.Windows.Ninject;

namespace VeterinariaMVC.Windows
{
    public partial class frmCliente : Form
    {
        public frmCliente(IServicioCliente servicio, IServicioLocalidad servicioLocalidad, 
            IServicioProvincia servicioProvincia, IServicioTipoDeDocumento servicioTipoDeDocumento)
        {
            InitializeComponent();
            this.servicio = servicio;
            this.servicioTipoDeDocumento = servicioTipoDeDocumento;
            this.servicioLocalidad = servicioLocalidad;
            this.servicioProvincia = servicioProvincia;
        }

        private IServicioCliente servicio;
        private IServicioTipoDeDocumento servicioTipoDeDocumento;
        private IServicioLocalidad servicioLocalidad;
        private IServicioProvincia servicioProvincia;
        private IMapper mapper;

        private List<ClienteListDto> lista;

        private void frmCliente_Load(object sender, EventArgs e)
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
            foreach (var clienteDto in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, clienteDto);
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

        private void SetearFila(DataGridViewRow r, ClienteListDto cliente)
        {
            r.Cells[cmnNombre.Index].Value = cliente.Nombre;
            r.Cells[cmnCalle.Index].Value = cliente.Calle;
            r.Cells[cmnAltura.Index].Value = cliente.Altura;
            r.Cells[cmnEmail.Index].Value = cliente.CorreoElectronico;

            r.Tag = cliente;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmClienteAE frm = DI.Create<frmClienteAE>();
            frm.Titulo("Nuevo Cliente");
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    ClienteEditDto clienteEditDto = frm.GetCliente();
                    if (servicio.Existe(clienteEditDto))
                    {
                        frmMessageBox messageBox = new frmMessageBox();
                        messageBox.Show();
                        messageBox.ShowError("Cliente Existente", $"{clienteEditDto.Apellido}, {clienteEditDto.Nombre} ya existe en la base de datos");
                    }
                    servicio.Guardar(clienteEditDto);
                    DataGridViewRow r = ConstruirFila();
                    ClienteListDto clienteListDto = mapper.Map<ClienteListDto>(clienteEditDto);                  
                    SetearFila(r, clienteListDto);
                    AgregarFila(r);
                    frmMessageBox frmMessage = new frmMessageBox();
                    frmMessage.Show();
                    frmMessage.ShowInfo("Registro Agregado", $"{clienteEditDto.Apellido}, {clienteEditDto.Nombre} ya a sido agergado");
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
            var clienteListDto = r.Tag as ClienteListDto;
            frmMessageBox mb = new frmMessageBox();
            mb.ShowQuestion("Borrar Cliente", $"¿Esta seguro que desea eliminar {clienteListDto.Nombre} del registro?");
            DialogResult dr = mb.ShowDialog(this);
            if (dr == DialogResult.No)
            {
                return;
            }
            try
            {
                servicio.Borrar(clienteListDto.ClienteId);
                dgvDatos.Rows.Remove(r);
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowInfo("Cliente Borrado", $"{ clienteListDto.Nombre} se borro de la base de datos");

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
            var clienteListDto = r.Tag as ClienteListDto;
            var clienteCopia = (ClienteListDto)clienteListDto.Clone();
            frmClienteAE frm = DI.Create<frmClienteAE>();
            frm.Titulo("Editar Cliente");
            ClienteEditDto clienteEditDto = servicio.GetClientePorId(clienteListDto.ClienteId);
            frm.SetCliente(clienteEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            clienteEditDto = frm.GetCliente();
            if (servicio.Existe(clienteEditDto))
            {
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowError("Cliente Existente", $" { clienteEditDto.Apellido}, { clienteEditDto.Nombre}ya existe en la base de datos");
                SetearFila(r, clienteCopia);
                return;
            }
            try
            {
                servicio.Guardar(clienteEditDto);
                var cListDto = mapper.Map<ClienteListDto>(clienteEditDto);              
                SetearFila(r, cListDto);
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowInfo("Cliente Editado", $"{cListDto.Nombre}" +
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
