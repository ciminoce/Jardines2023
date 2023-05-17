using Jardines2023.Entidades.Entidades;
using Jardines2023.Windows.Helpers;
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
    public partial class frmCiudadAE : Form
    {
        public frmCiudadAE()
        {
            InitializeComponent();
        }
        private Ciudad ciudad;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.CargarComboPaises(ref cboPaises);
            if (ciudad!=null)
            {
                txtNombreCiudad.Text = ciudad.NombreCiudad;
                cboPaises.SelectedValue = ciudad.PaisId;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (ciudad==null)
                {
                    ciudad=new Ciudad();
                }
                ciudad.NombreCiudad = txtNombreCiudad.Text;
                ciudad.Pais = (Pais)cboPaises.SelectedItem;
                ciudad.PaisId = (int)cboPaises.SelectedValue;

                DialogResult= DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (cboPaises.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(cboPaises, "Debe seleccionar un país");
            }
            if (string.IsNullOrEmpty(txtNombreCiudad.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNombreCiudad, "El nombre es requerido");
            }
            return valido;
        }

        public Ciudad GetCiudad()
        {
            return ciudad;
        }

        public void SetCiudad(Ciudad ciudad)
        {
            this.ciudad=ciudad;
        }
    }
}
