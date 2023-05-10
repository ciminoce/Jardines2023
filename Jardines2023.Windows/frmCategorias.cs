using Jardines2023.Entidades.Entidades;
using Jardines2023.Servicios.Servicios;
using System.Collections.Generic;
using System;
using System.Windows.Forms;

namespace Jardines2023.Windows
{
    public partial class frmCategorias : Form
    {
        public frmCategorias()
        {
            InitializeComponent();
            _servicio = new ServiciosCategorias();
        }

        private readonly ServiciosCategorias _servicio;
        private List<Categoria> lista;

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            try
            {
                lista = _servicio.GetCategorias();
                lblCantidad.Text = _servicio.GetCantidad().ToString();
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
            foreach (var categoria in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, categoria);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Categoria categoria)
        {
            r.Cells[colCategoria.Index].Value = categoria.NombreCategoria;
            r.Cells[colDescripcion.Index].Value = categoria.Descripción;

            r.Tag = categoria;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmCategoriaAE frm = new frmCategoriaAE() { Text = "Agregar país" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            try
            {
                var categoria = frm.GetCategoria();
                if (!_servicio.Existe(categoria))
                {
                    _servicio.Guardar(categoria);
                    DataGridViewRow r = ConstruirFila();
                    SetearFila(r, categoria);
                    AgregarFila(r);
                    lblCantidad.Text = _servicio.GetCantidad().ToString();
                    MessageBox.Show("Registro agregado",
                        "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Registro existente",
                        "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,
                    "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            Categoria categoria = (Categoria)r.Tag;
            try
            {
                //Se debe controlar que no este relacionado
                _servicio.Borrar(categoria.CategoriaId);
                QuitarFila(r);
                lblCantidad.Text = _servicio.GetCantidad().ToString();
                MessageBox.Show("Registro borrado", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void QuitarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Remove(r);
        }

    }
}
