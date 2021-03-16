using AutoMapper;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VeterinariaMVC.Entidades.DTOs.NecesidadEspecial;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariaMVC.Windows.Ninject;

namespace VeterinariaMVC.Windows
{
    public partial class frmNecesidadEspecial : Form
    {
        public frmNecesidadEspecial(IServicioNecesidadEspecial servicio)
        {
            InitializeComponent();
            this.servicio = servicio;
        }

        private IServicioNecesidadEspecial servicio;
        private IMapper mapper;
        private List<NecesidadEspecialListDto> lista;
        private void frmNecesidadEspecial_Load(object sender, EventArgs e)
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
            foreach (var necesidadDto in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, necesidadDto);
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

        private void SetearFila(DataGridViewRow r, NecesidadEspecialListDto necesidad)
        {
            r.Cells[cmnNe.Index].Value = necesidad.Descripcion;

            r.Tag = necesidad;
        }
 
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmNecesidadEspecialAE frm = DI.Create<frmNecesidadEspecialAE>();
            frm.Titulo("Nueva Necesidad Especial");
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    NecesidadEspecialEditDto necesidadEditDto = frm.GetNecesidadESpecial();
                    if (servicio.Existe(necesidadEditDto))
                    {
                        frmMessageBox messageBox = new frmMessageBox();
                        messageBox.Show();
                        messageBox.ShowError("Necesidad Especial Existente", $"{necesidadEditDto.Descripcion} ya existe en la base de datos");
                    }
                    servicio.Guardar(necesidadEditDto);
                    DataGridViewRow r = ConstruirFila();
                    NecesidadEspecialListDto necesidadListDto = mapper.Map<NecesidadEspecialListDto>(necesidadEditDto);
                    SetearFila(r, necesidadListDto);
                    AgregarFila(r);
                    frmMessageBox frmMessage = new frmMessageBox();
                    frmMessage.Show();
                    frmMessage.ShowInfo("Registro Agregado", $"{necesidadListDto.Descripcion} ya a sido agergado");
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
            var necesidadListDto = r.Tag as NecesidadEspecialListDto;
            frmMessageBox mb = new frmMessageBox();
            mb.ShowQuestion("Borrar Necesidad Especial", $"¿Esta seguro que desea eliminar {necesidadListDto.Descripcion} del registro?");
            DialogResult dr = mb.ShowDialog(this);
            if (dr == DialogResult.No)
            {
                return;
            }
            try
            {
                servicio.Borrar(necesidadListDto.NecesidadesEspecialesId);
                dgvDatos.Rows.Remove(r);
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowInfo("Necesidad Especial Borrada", $"{necesidadListDto.Descripcion} se borro de la base de datos");
                
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
            var necesidadListDto = r.Tag as NecesidadEspecialListDto;
            var necesidadCopia = (NecesidadEspecialListDto)necesidadListDto.Clone();
            frmNecesidadEspecialAE frm = DI.Create<frmNecesidadEspecialAE>();
            frm.Titulo("Editar Necesidad Especial");
            NecesidadEspecialEditDto necesidadEditDto = mapper.Map<NecesidadEspecialEditDto>(necesidadListDto);
            frm.SetNecesidadEspecial(necesidadEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            necesidadEditDto = frm.GetNecesidadESpecial();
            if (servicio.Existe(necesidadEditDto))
            {
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowError("Necesidad Especial Existente", $"{necesidadEditDto.Descripcion} ya existe en la base de datos");
                SetearFila(r, necesidadCopia);
                return;
            }
            try
            {
                servicio.Guardar(necesidadEditDto);
                var nListDto = mapper.Map<NecesidadEspecialListDto>(necesidadEditDto);
                SetearFila(r, nListDto);
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowInfo("Necesidad Especial Editada", $"{nListDto.Descripcion} " +
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
