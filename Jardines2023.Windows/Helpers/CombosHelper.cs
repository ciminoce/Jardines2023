﻿using Jardines2023.Entidades.Entidades;
using Jardines2023.Servicios.Interfaces;
using Jardines2023.Servicios.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jardines2023.Windows.Helpers
{
    public static class CombosHelper
    {
        public static void CargarComboPaises(ref ComboBox combo)
        {
            IServiciosPaises serviciosPaises = new ServiciosPaises();
            var lista = serviciosPaises.GetPaises();
            var defaultPais = new Pais()
            {
                PaisId = 0,
                NombrePais = "Seleccione País"
            };
            lista.Insert(0,defaultPais);
            combo.DataSource=lista;
            combo.DisplayMember = "NombrePais";
            combo.ValueMember = "PaisId";
            combo.SelectedIndex=0;
        }
    }
}
