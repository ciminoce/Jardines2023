using Jardines2023.Entidades.Entidades;
using Jardines2023.Servicios.Interfaces;
using System;
using System.Windows.Forms;

namespace Jardines2023.Windows
{
    public partial class frmProductoAE : Form
    {
        private readonly IServiciosProductos _servicio;
        public frmProductoAE(IServiciosProductos servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }
        private Producto producto;
        private bool esEdicion = false;
        public Producto GetProducto()
        {
            return producto;
        }

        public void SetProducto(Producto producto)
        {
            this.producto = producto;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (producto == null)
                {
                    producto = new Producto();

                }
                producto.NombreProducto = txtProducto.Text;
                producto.NombreLatin = txtLatin.Text;
                producto.Suspendido=chkSuspendido.Checked;
                producto.CategoriaId = (int)cboCategorias.SelectedValue;
                producto.ProveedorId = (int)cboProveedores.SelectedValue;
                producto.PrecioUnitario=decimal.Parse(txtPrecioVta.Text);
                producto.UnidadesEnStock = (int)nudStock.Value;
                producto.NivelDeReposicion = (int)nudMinimo.Value;

                try
                {

                    if (!_servicio.Existe(producto))
                    {
                        _servicio.Guardar(producto);

                        if (!esEdicion)
                        {
                            MessageBox.Show("Registro agregado",
                        "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult dr = MessageBox.Show("¿Desea agregar otro registro?",
                                "Pregunta",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2);
                            if (dr == DialogResult.No)
                            {
                                DialogResult = DialogResult.OK;

                            }
                            producto = null;
                            InicializarControles();

                        }
                        else
                        {
                            MessageBox.Show("Registro editado", "Mensaje",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult = DialogResult.OK;

                        }
                    }
                    else
                    {
                        MessageBox.Show("Registro duplicado",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        producto = null;
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message,
        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }

        }

        private void InicializarControles()
        {
            txtProducto.Clear();
            txtLatin.Clear();
            txtPrecioVta.Clear();
            nudMinimo.Value = 1;
            nudMinimo.Value = 1;
            cboCategorias.SelectedIndex = 0;
            cboProveedores.SelectedIndex = 0;
            chkSuspendido.Checked = false;
            txtProducto.Focus();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            return valido;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (producto != null)
            {
                esEdicion = true;
                txtProducto.Text = producto.NombreProducto;
                txtLatin.Text = producto.NombreLatin;
                txtPrecioVta.Text=producto.PrecioUnitario.ToString();
                nudMinimo.Value = producto.NivelDeReposicion;
                nudStock.Value = producto.UnidadesEnStock;
                cboCategorias.SelectedValue = producto.CategoriaId;
                cboProveedores.SelectedValue = producto.ProveedorId;
            }
        }

    }
}
