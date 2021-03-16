using AutoMapper;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VeterinariaMVC.Entidades.DTOs.Marca;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariaMVC.Windows.Ninject;

namespace VeterinariaMVC.Windows
{
    public partial class frmMarca : Form
    {
        public frmMarca(IServicioMarca servicio)
        {
            InitializeComponent();
            this.servicio = servicio;
        }

        private IServicioMarca servicio;
        private IMapper mapper;
        private List<MarcaListDto> lista;
        private void frmMarca_Load(object sender, EventArgs e)
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
            foreach (var marcaDto in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, marcaDto);
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

        private void SetearFila(DataGridViewRow r, MarcaListDto marca)
        {
            r.Cells[cmnMarca.Index].Value = marca.Nombre;

            r.Tag = marca;
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmMarcaAE frm = DI.Create<frmMarcaAE>();
            frm.Titulo("Nueva Marca");
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    MarcaEditDto marcaEditDto = frm.GetMarca();
                    if (servicio.Existe(marcaEditDto))
                    {
                        frmMessageBox messageBox = new frmMessageBox();
                        messageBox.Show();
                        messageBox.ShowError("Marca Existente", $"{marcaEditDto.Nombre} ya existe en la base de datos");
                    }
                    servicio.Guardar(marcaEditDto);
                    DataGridViewRow r = ConstruirFila();
                    MarcaListDto marcaListDto = mapper.Map<MarcaListDto>(marcaEditDto);
                    SetearFila(r, marcaListDto);
                    AgregarFila(r);
                    frmMessageBox frmMessage = new frmMessageBox();
                    frmMessage.Show();
                    frmMessage.ShowInfo("Registro Agregado", $"{marcaListDto.Nombre} ya a sido agergado");
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
            var marcaListDto = r.Tag as MarcaListDto;
            frmMessageBox mb = new frmMessageBox();
            mb.ShowQuestion("Borrar Marca", $"¿Esta seguro que desea eliminar {marcaListDto.Nombre} del registro?");
            DialogResult dr = mb.ShowDialog(this);
            if (dr == DialogResult.No)
            {
                return;
            }
            try
            {
                //if (!servicio.EstaRelacionado(provinciaListDto))
                //{

                servicio.Borrar(marcaListDto.MarcaId);
                dgvDatos.Rows.Remove(r);
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowInfo("Marca Borrada", $"{marcaListDto.Nombre} se borro de la base de datos");
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
            var marcaListDto = r.Tag as MarcaListDto;
            var marcaCopia = (MarcaListDto)marcaListDto.Clone();
            frmMarcaAE frm = DI.Create<frmMarcaAE>();
            frm.Titulo("Editar Marca");
            MarcaEditDto marcaEditDto = mapper.Map<MarcaEditDto>(marcaListDto);
            frm.SetMarca(marcaEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            marcaEditDto = frm.GetMarca();
            if (servicio.Existe(marcaEditDto))
            {
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowError("Marca Existente", $"{marcaEditDto.Nombre} ya existe en la base de datos");
                SetearFila(r, marcaCopia);
                return;
            }
            try
            {
                servicio.Guardar(marcaEditDto);
                var mListDto = mapper.Map<MarcaListDto>(marcaEditDto);
                SetearFila(r, mListDto);
                frmMessageBox messageBox = new frmMessageBox();
                messageBox.Show();
                messageBox.ShowInfo("Marca Editada", $"{mListDto.Nombre} " +
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
