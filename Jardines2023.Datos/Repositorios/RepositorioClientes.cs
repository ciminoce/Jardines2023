using Jardines2023.Datos.Interfaces;
using Jardines2023.Entidades.Dtos.Cliente;
using Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Jardines2023.Datos.Repositorios
{
    public class RepositorioClientes : IRepositorioClientes
    {
        private string cadenaConexion;
        public RepositorioClientes()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }

        public void Borrar(int clienteId)
        {
            try
            {
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM Clientes WHERE ClienteId=@ClienteId";
                    using (var comando = new SqlCommand(deleteQuery, conn))
                    {
                        comando.Parameters.Add("@ClienteId", SqlDbType.Int);
                        comando.Parameters["@ClienteId"].Value = clienteId;

                        comando.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {

                if (ex.Message.Contains("REFERENCE"))
                {
                    throw new Exception("Registro relacionado... Baja denegada");
                }
            }
        }

        public void Editar(Cliente cliente)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string updateQuery = @"UPDATE Clientes SET Nombres=@Nombres,
                                Apellido=@Apellido, Direccion=@Direccion, 
                                CodPostal=@CodPostal, PaisId=@PaisId, 
                                CiudadId=@CiudadId, Email=@Email, 
                                TelefonoFijo=@TelefonoFijo, TelefonoMovil=@TelefonoMovil 
                                WHERE ClienteId=@ClienteId";
                using (var cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.Add("@Nombres", SqlDbType.NVarChar);
                    cmd.Parameters["@Nombres"].Value = cliente.Nombre;

                    cmd.Parameters.Add("@Apellido", SqlDbType.NVarChar);
                    cmd.Parameters["@Apellido"].Value = cliente.Apellido;

                    cmd.Parameters.Add("@Direccion", SqlDbType.NVarChar);
                    cmd.Parameters["@Direccion"].Value = cliente.Direccion;
                    
                    cmd.Parameters.Add("@CodPostal", SqlDbType.NVarChar);
                    cmd.Parameters["@CodPostal"].Value = cliente.CodigoPostal;

                    cmd.Parameters.Add("@PaisId", SqlDbType.Int);
                    cmd.Parameters["@PaisId"].Value = cliente.PaisId;

                    cmd.Parameters.Add("@CiudadId", SqlDbType.Int);
                    cmd.Parameters["@CiudadId"].Value = cliente.CiudadId;

                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar);
                    cmd.Parameters["@Email"].Value = cliente.Email;

                    cmd.Parameters.Add("@TelefonoFijo", SqlDbType.NVarChar);
                    cmd.Parameters["@TelefonoFijo"].Value = cliente.TelefonoFijo;
                    
                    cmd.Parameters.Add("@TelefonoMovil", SqlDbType.NVarChar);
                    cmd.Parameters["@TelefonoMovil"].Value = cliente.TelefonoMovil;
                    
                    cmd.Parameters.Add("@ClienteId", SqlDbType.Int);
                    cmd.Parameters["@ClienteId"].Value = cliente.ClienteId;

                    cmd.ExecuteNonQuery();
                }
            }

        }

        public bool Existe(Cliente cliente)
        {
            try
            {
                var cantidad = 0;
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string selectQuery;
                    if (cliente.ClienteId == 0)
                    {
                        selectQuery = "SELECT COUNT(*) FROM Clientes WHERE Nombre=@Nombre AND Apellido=@Apellido";

                    }
                    else
                    {
                        selectQuery = "SELECT COUNT(*) FROM Clientes WHERE Nombre=@Nombre AND Apellido=@Apellido AND ClienteId=@ClienteId";

                    }
                    using (var comando = new SqlCommand(selectQuery, conn))
                    {
                        comando.Parameters.Add("@Nombre", SqlDbType.NVarChar);
                        comando.Parameters["@Nombre"].Value = cliente.Nombre;

                        comando.Parameters.Add("@Apellido", SqlDbType.NVarChar);
                        comando.Parameters["@Apellido"].Value = cliente.Apellido;

                        if (cliente.ClienteId == 0)
                        {
                            comando.Parameters.Add("@ClienteId", SqlDbType.Int);
                            comando.Parameters["@ClienteId"].Value = cliente.ClienteId;

                        }

                        cantidad = (int)comando.ExecuteScalar();
                    }
                }
                return cantidad > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ClienteListDto> Filtrar(Pais pais)
        {
            throw new NotImplementedException();
        }

        public int GetCantidad()
        {
            try
            {
                int cantidad = 0;
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string selectQuery = "SELECT COUNT(*) FROM Clientes";
                    using (var comando = new SqlCommand(selectQuery, conn))
                    {
                        cantidad = (int)comando.ExecuteScalar();
                    }
                }
                return cantidad;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<ClienteListDto> GetClientes()
        {
            List<ClienteListDto> lista = new List<ClienteListDto>();
            using (var con = new SqlConnection(cadenaConexion))
            {
                con.Open();
                string selectQuery = @"SELECT ClienteId, Nombres, Apellido, PaisId, CiudadId 
                        FROM Clientes ORDER BY Apellido, Nombres";
                using (var cmd = new SqlCommand(selectQuery, con))
                {
                    using (var reader = cmd.ExecuteReader())
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

        public List<ClienteListDto> GetClientesPorPagina(int cantidad, int pagina)
        {
            List<ClienteListDto> lista = new List<ClienteListDto>();
            try
            {
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string selectQuery = @"SELECT ClienteId, Nombres, Apellido, PaisId, CiudadId FROM Clientes
                        ORDER BY Apellido, Nombres
                        OFFSET @cantidadRegistros ROWS 
                        FETCH NEXT @cantidadPorPagina ROWS ONLY";
                    using (var comando = new SqlCommand(selectQuery, conn))
                    {
                        comando.Parameters.Add("@cantidadRegistros", SqlDbType.Int);
                        comando.Parameters["@cantidadRegistros"].Value = cantidad * (pagina - 1);

                        comando.Parameters.Add("@cantidadPorPagina", SqlDbType.Int);
                        comando.Parameters["@cantidadPorPagina"].Value = cantidad;
                        using (var reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var cliente = ConstruirClienteDto(reader);
                                lista.Add(cliente);
                            }
                        }
                    }
                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Agregar(Cliente cliente)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string addQuery = @"INSERT INTO Clientes (Nombres, Apellido,                               Apellido=@Apellido, Direccion=@Direccion, 
                                Direccion, CodigoPostal, PaisId, CiudadId,
                                Email, TelefonoFijo, TelefonoMovil)
                                VALUES (@Nombres, @Apellido, @Direccion,
                                @CodPostal, @PaisId, @CiudadId, @Email,
                                @TelefonoFijo, @TelefonoMovil), SELECT SCOPE_IDENTITY()";
                using (var cmd = new SqlCommand(addQuery, conn))
                {
                    cmd.Parameters.Add("@Nombres", SqlDbType.NVarChar);
                    cmd.Parameters["@Nombres"].Value = cliente.Nombre;

                    cmd.Parameters.Add("@Apellido", SqlDbType.NVarChar);
                    cmd.Parameters["@Apellido"].Value = cliente.Apellido;

                    cmd.Parameters.Add("@Direccion", SqlDbType.NVarChar);
                    cmd.Parameters["@Direccion"].Value = cliente.Direccion;

                    cmd.Parameters.Add("@CodPostal", SqlDbType.NVarChar);
                    cmd.Parameters["@CodPostal"].Value = cliente.CodigoPostal;

                    cmd.Parameters.Add("@PaisId", SqlDbType.Int);
                    cmd.Parameters["@PaisId"].Value = cliente.PaisId;

                    cmd.Parameters.Add("@CiudadId", SqlDbType.Int);
                    cmd.Parameters["@CiudadId"].Value = cliente.CiudadId;

                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar);
                    cmd.Parameters["@Email"].Value = cliente.Email;

                    cmd.Parameters.Add("@TelefonoFijo", SqlDbType.NVarChar);
                    cmd.Parameters["@TelefonoFijo"].Value = cliente.TelefonoFijo;

                    cmd.Parameters.Add("@TelefonoMovil", SqlDbType.NVarChar);
                    cmd.Parameters["@TelefonoMovil"].Value = cliente.TelefonoMovil;


                    int id = Convert.ToInt32(cmd.ExecuteScalar());
                    cliente.ClienteId = id;
                }
            }

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
