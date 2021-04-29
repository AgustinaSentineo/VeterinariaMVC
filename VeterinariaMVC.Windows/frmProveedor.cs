using AutoMapper;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VeterinariaMVC.Entidades.DTOs.Proveedor;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariaMVC.Windows.Ninject;

namespace VeterinariaMVC.Windows
{
    public partial class frmProveedor : Form
    {
        public frmProveedor(IServicioProveedor servicio, IServicioLocalidad servicioLocalidad,
            IServicioProvincia servicioProvincia, IServicioTipoDeDocumento servicioTipoDeDocumento)
        {
            InitializeComponent();
            this.servicio = servicio;
            this.servicioTipoDeDocumento = servicioTipoDeDocumento;
            this.servicioLocalidad = servicioLocalidad;
            this.servicioProvincia = servicioProvincia;
        }

        private IServicioProveedor servicio;
        private IServicioTipoDeDocumento servicioTipoDeDocumento;
        private IServicioLocalidad servicioLocalidad;
        private IServicioProvincia servicioProvincia;
        private IMapper mapper;

        private List<ProveedorListDto> lista;
        private void frmProveedor_Load(object sender, EventArgs e)
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
            foreach (var proveedorDto in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, proveedorDto);
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

        private void SetearFila(DataGridViewRow r, ProveedorListDto proveedor)
        {
            r.Cells[cmnCUIT.Index].Value = proveedor.CUIT;
            r.Cells[cmnRazonSocial.Index].Value = proveedor.RazonSocial;
            r.Cells[cmnLocalidad.Index].Value = proveedor.Localidad;
            r.Cells[cmnProvincia.Index].Value = proveedor.Provincia;
            r.Cells[cmnEmail.Index].Value = proveedor.CorreoElectronico;

            r.Tag = proveedor;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmProveedorAE frm = DI.Create<frmProveedorAE>();
            frm.Titulo("Nuevo Proveedor");
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    ProveedorEditDto proveedorEditDto = frm.GetProveedor();
                    if (servicio.Existe(proveedorEditDto))
                    {
                        frmMessageBox messageBox = new frmMessageBox();
                        messageBox.Show();
                        messageBox.ShowError("Proveedor Existente", $"{proveedorEditDto.CUIT}-{proveedorEditDto.RazonSocial} ya existe en la base de datos");
                    }
                    servicio.Guardar(proveedorEditDto);
                    DataGridViewRow r = ConstruirFila();
                    ProveedorListDto proveedorListDto = mapper.Map<ProveedorListDto>(proveedorEditDto);
                    proveedorListDto.Provincia = (servicioProvincia
                            .GetProvinciaId(proveedorEditDto.ProvinciaId))
                            .NombreProvincia;
                    proveedorListDto.Localidad = (servicioLocalidad
                            .GetLocalidadPorId(proveedorEditDto.LocalidadId))
                            .NombreLocalidad;
                    SetearFila(r, proveedorListDto);
                    AgregarFila(r);
                    frmMessageBox frmMessage = new frmMessageBox();
                    frmMessage.Show();
                    frmMessage.ShowInfo("Registro Agregado", $"{proveedorListDto.CUIT}-{proveedorListDto.RazonSocial} ya a sido agergado");
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
            var proveedorListDto = r.Tag as ProveedorListDto;
            frmMessageBox mb = new frmMessageBox();
            mb.ShowQuestion("Borrar Proveedor", $"¿Esta seguro que desea eliminar {proveedorListDto.CUIT}-{proveedorListDto.RazonSocial} del registro?");
            DialogResult dr = mb.ShowDialog(this);
            if (dr == DialogResult.No)
            {
                return;
            }
            try
            {

                servicio.Borrar(proveedorListDto.ProveedorId);
                dgvDatos.Rows.Remove(r);
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowInfo("Proveedor Borrada", $"{proveedorListDto.CUIT}-{proveedorListDto.RazonSocial} se borro de la base de datos");

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
            var proveedorListDto = r.Tag as ProveedorListDto;
            var proveedorCopia = (ProveedorListDto)proveedorListDto.Clone();
            frmProveedorAE frm = DI.Create<frmProveedorAE>();
            frm.Titulo("Editar Proveedor");
            ProveedorEditDto proveedorEditDto = servicio.GetProveedorPorId(proveedorListDto.ProveedorId);
            frm.SetProveedor(proveedorEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            proveedorEditDto = frm.GetProveedor();
            if (servicio.Existe(proveedorEditDto))
            {
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowError("Proveedor Existente", $"{proveedorEditDto.CUIT}-{proveedorEditDto.RazonSocial} ya existe en la base de datos");
                SetearFila(r, proveedorCopia);
                return;
            }
            try
            {
                servicio.Guardar(proveedorEditDto);
                var pListDto = mapper.Map<ProveedorListDto>(proveedorEditDto);
                proveedorListDto.Provincia = (servicioProvincia
                          .GetProvinciaId(proveedorEditDto.ProvinciaId))
                          .NombreProvincia;
                proveedorListDto.Localidad= (servicioLocalidad
                          .GetLocalidadPorId(proveedorEditDto.LocalidadId))
                          .NombreLocalidad;
                SetearFila(r, pListDto);
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowInfo("Proveedor Editado", $"{pListDto.CUIT}-{pListDto.RazonSocial} " +
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
