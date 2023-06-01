using Jardines2023.Datos.Interfaces;
using Jardines2023.Entidades.Dtos.Cliente;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2023.Datos.Repositorios
{
    public class RepositorioClientes : IRepositorioClientes
    {
        private string cadenaConexion;
        public RepositorioClientes()
        {
            cadenaConexion=ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }
        public List<ClienteListDto> GetClientes()
        {
            List<ClienteListDto> lista = new List<ClienteListDto>();
            using (var con=new SqlConnection(cadenaConexion))
            {
                con.Open();
                string selectQuery = @"SELECT ClienteId, Nombres, Apellido, PaisId, CiudadId 
                        FROM Clientes ORDER BY Apellido, Nombres";
                using (var cmd=new SqlCommand(selectQuery,con))
                {
                    using (var reader=cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var clienteDto = ConstruirClienteDto(reader);
                            lista.Add(clienteDto);
                        }
                    }
                }
            }
            return lista;
        }

        private ClienteListDto ConstruirClienteDto(SqlDataReader reader)
        {
            return new ClienteListDto()
            {
                ClienteId = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                Apellido = reader.GetString(2),
                PaisId = reader.GetInt32(3),
                CiudadId = reader.GetInt32(4)
            };
        }
    }
}
