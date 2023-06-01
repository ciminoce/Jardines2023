using Jardines2023.Entidades.Dtos.Cliente;
using Jardines2023.Servicios.Interfaces;
using Jardines2023.Servicios.Servicios;
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
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
            _servicio = new ServiciosClientes();
        }
        private readonly IServiciosClientes _servicio;
        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        List<ClienteListDto> lista;
        private void frmClientes_Load(object sender, EventArgs e)
        {
            try
            {
                lista = _servicio.GetClientes();
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
            foreach (var cliente in lista)
            {
                var r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r,cliente);
                GridHelper.AgregarFila(dgvDatos, r);
            }
        }
    }
}
