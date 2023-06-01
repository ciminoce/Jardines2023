using Jardines2023.Entidades.Dtos.Cliente;
using Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2023.Datos.Interfaces
{
    public interface IRepositorioClientes
    {
        List<ClienteListDto> GetClientes();
    }
}
