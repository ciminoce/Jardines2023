using Jardines2023.Entidades.Dtos.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2023.Servicios.Interfaces
{
    public interface IServiciosClientes
    {
        List<ClienteListDto> GetClientes();
    }
}
