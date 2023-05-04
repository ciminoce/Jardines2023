using Jardines2023.Entidades.Entidades;
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
    public partial class frmPaisAE : Form
    {
        public frmPaisAE()
        {
            InitializeComponent();
        }
        private Pais pais;
        public Pais GetPais()
        {
            return pais;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                pais=new Pais();
                pais.NombrePais = txtNombrePais.Text;

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            if (string.IsNullOrEmpty(txtNombrePais.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNombrePais, "Debe ingresar un nombre de país");

            }
            return valido;
        }
    }
}
