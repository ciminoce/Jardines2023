using System;
using System.Windows.Forms;

namespace Jardines2023.Windows
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void PaisesButton_Click(object sender, EventArgs e)
        {
            frmPaises frm=new frmPaises();
            frm.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CategoriasButton_Click(object sender, EventArgs e)
        {
            frmCategorias frm=new frmCategorias();
            frm.ShowDialog();
        }

        private void CiudadesButton_Click(object sender, EventArgs e)
        {
            frmCiudades frm=new frmCiudades();
            frm.ShowDialog();
        }
    }
}
