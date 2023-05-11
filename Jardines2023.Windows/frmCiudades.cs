using Jardines2023.Entidades.Entidades;
using Jardines2023.Servicios.Interfaces;
using Jardines2023.Servicios.Servicios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Jardines2023.Windows
{
    public partial class frmCiudades : Form
    {
        private readonly IServiciosCiudades _servicio;
        private List<Ciudad> lista;
        int cantidad = 0;
        public frmCiudades()
        {
            InitializeComponent();
            _servicio = new ServiciosCiudades();
        }

        private void frmCiudades_Load(object sender, EventArgs e)
        {
            try
            {
                cantidad = _servicio.GetCantidad();
                lblCantidad.Text = cantidad.ToString();
                lista = _servicio.GetCiudades();
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
            foreach (var ciudad in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, ciudad);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Ciudad ciudad)
        {
            r.Cells[colCiudad.Index].Value = ciudad.NombreCiudad;
            r.Cells[colPais.Index].Value = ciudad.Pais.NombrePais;

            r.Tag = ciudad;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
