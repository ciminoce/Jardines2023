using Jardines2023.Entidades.Entidades;
using Jardines2023.Servicios.Servicios;
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
    public partial class frmPaises : Form
    {
        public frmPaises()
        {
            InitializeComponent();
            _servicio = new ServiciosPaises();
        }
        private readonly ServiciosPaises _servicio;
        private List<Pais> lista;

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmPaises_Load(object sender, EventArgs e)
        {
            try
            {
                lista = _servicio.GetPaises();
                lblCantidad.Text=_servicio.GetCantidad().ToString();
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
            foreach (var pais in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, pais);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Pais pais)
        {
            r.Cells[colPais.Index].Value = pais.NombrePais;

            r.Tag = pais;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r=new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmPaisAE frm = new frmPaisAE() { Text = "Agregar país" };
            DialogResult dr = frm.ShowDialog(this);
            if(dr==DialogResult.Cancel) return;
            try
            {
                var pais = frm.GetPais();
                if (!_servicio.Existe(pais))
                {
                    _servicio.Guardar(pais);
                    DataGridViewRow r = ConstruirFila();
                    SetearFila(r,pais);
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
            if (dgvDatos.SelectedRows.Count==0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            Pais pais = (Pais)r.Tag;
            try
            {
                //Se debe controlar que no este relacionado
                _servicio.Borrar(pais.PaisId);
                QuitarFila(r);
                lblCantidad.Text = _servicio.GetCantidad().ToString();
                MessageBox.Show("Registro borrado","Mensaje",
                    MessageBoxButtons.OK,MessageBoxIcon.Information);
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
