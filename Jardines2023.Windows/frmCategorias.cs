using Jardines2023.Entidades.Entidades;
using Jardines2023.Servicios.Servicios;
using System.Collections.Generic;
using System;
using System.Windows.Forms;
using Jardines2023.Windows.Helpers;

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
                //lblCantidad.Text = _servicio.GetCantidad().ToString();
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            foreach (var categoria in lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, categoria);
                GridHelper.AgregarFila(dgvDatos,r);
            }
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
                    DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                    GridHelper.SetearFila(r, categoria);
                    GridHelper.AgregarFila(dgvDatos, r);
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
                GridHelper.QuitarFila(dgvDatos,r);
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

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            Categoria categoria = (Categoria)r.Tag;
            Categoria categoriaCopia = (Categoria)categoria.Clone();
            try
            {
                frmCategoriaAE frm = new frmCategoriaAE() { Text = "Editar Categoria" };
                frm.SetCategoria(categoria);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }
                categoria = frm.GetCategoria();
                if (!_servicio.Existe(categoria))
                {
                    _servicio.Guardar(categoria);
                    GridHelper.SetearFila(r, categoria);
                    MessageBox.Show("Registro editado", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    GridHelper.SetearFila(r, categoriaCopia);
                    MessageBox.Show("Registro duplicado!!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                GridHelper.SetearFila(r, categoriaCopia);
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
    }
}
