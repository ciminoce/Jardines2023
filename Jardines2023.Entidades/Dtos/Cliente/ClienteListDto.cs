using Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2023.Entidades.Dtos.Cliente
{
    public class ClienteListDto
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int PaisId { get; set; }
        public int CiudadId { get; set; }
        public string NombrePais { get; set; }
        public string NombreCiudad { get; set; }

    }
}
