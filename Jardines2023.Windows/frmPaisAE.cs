using Jardines2023.Entidades.Entidades;
using System;
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
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (pais!=null)
            {
                txtNombrePais.Text = pais.NombrePais;
            }
        }
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
                if (pais==null)
                {
                    pais=new Pais();

                }
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

        public void SetPais(Pais pais)
        {
            this.pais = pais;
        }
    }
}
