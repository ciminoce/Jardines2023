﻿using Jardines2023.Entidades.Entidades;
using System;
using System.Windows.Forms;

namespace Jardines2023.Windows
{
    public partial class frmCategoriaAE : Form
    {
        public frmCategoriaAE()
        {
            InitializeComponent();
        }

        public Categoria GetCategoria()
        {
            return categoria;
        }
        private Categoria categoria;

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                categoria = new Categoria();
                categoria.NombreCategoria = txtCategoria.Text;
                categoria.Descripción = txtDescripcion.Text;
                DialogResult = DialogResult.OK;
            }

        }

        private bool ValidarDatos()
        {
            bool valido = true;
            if (string.IsNullOrEmpty(txtCategoria.Text))
            {
                valido = false;
                errorProvider1.SetError(txtCategoria, "Debe ingresar un nombre de país");

            }
            return valido;
        }

    }
}