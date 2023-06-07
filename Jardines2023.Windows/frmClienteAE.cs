using Jardines2023.Entidades.Entidades;
using Jardines2023.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jardines2023.Windows
{
    public partial class frmClienteAE : Form
    {
        private readonly IServiciosClientes _servicios;
        private bool esEdicion = false;
        public frmClienteAE(IServiciosClientes servicios)
        {
            InitializeComponent();
            _servicios = servicios;
        }
        private Cliente cliente;
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (cliente == null)
                {
                    cliente = new Cliente();
                }
                cliente.Nombre = txtNombres.Text;
                cliente.Apellido = txtApellido.Text;
                cliente.Direccion = txtDireccion.Text;
                cliente.CodigoPostal = txtCodPostal.Text;
                cliente.TelefonoFijo = txtFijo.Text;
                cliente.TelefonoMovil = txtCelular.Text;
                cliente.Pais = (Pais)cboPaises.SelectedItem;
                cliente.PaisId = (int)cboPaises.SelectedValue;
                cliente.Ciudad = (Ciudad)cboCiudades.SelectedItem;
                cliente.CiudadId = (int)cboCiudades.SelectedValue;
                cliente.Email=txtEmail.Text;

                try
                {

                    if (!_servicios.Existe(cliente))
                    {
                        _servicios.Guardar(cliente);

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
                            cliente = null;
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
                        cliente = null;
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
            txtCelular.Clear();
            txtFijo.Clear();
            txtNombres.Clear();
            txtApellido.Clear();
            txtCodPostal.Clear();
            txtDireccion.Clear();
            txtEmail.Clear();
            cboCiudades.Items.Clear();
            cboPaises.SelectedIndex = 0;
            txtNombres.Focus();
        }

        private bool ValidarDatos()
        {
            return true;
        }

        public void SetCliente(Cliente cliente)
        {
            this.cliente=cliente;
        }

        public Cliente GetCliente()
        {
            return cliente;
        }
    }
}
