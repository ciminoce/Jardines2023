using Jardines2023.Datos.Interfaces;
using Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Jardines2023.Datos.Repositorios
{
    public class RepositorioCiudades : IRepositorioCiudades
    {

        private readonly string cadenaConexion;
        public RepositorioCiudades()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }


        public void Agregar(Ciudad ciudad)
        {
            throw new NotImplementedException();
        }

        public void Borrar(int ciudadId)
        {
            throw new NotImplementedException();
        }

        public void Editar(Ciudad ciudad)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Ciudad ciudad)
        {
            throw new NotImplementedException();
        }

        public int GetCantidad()
        {
            int cantidad = 0;
            using (var con=new SqlConnection(cadenaConexion))
            {
                con.Open();
                string selectQuery = "SELECT COUNT(*) FROM Ciudades";
                using (var cmd=new SqlCommand(selectQuery,con))
                {
                    cantidad=Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return cantidad;
        }

        public List<Ciudad> GetCiudades()
        {
            List<Ciudad> lista = new List<Ciudad>();
            try
            {
                using(var conn=new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string selectQuery = "SELECT CiudadId, NombreCiudad, PaisId FROM Ciudades ORDER BY PaisId, NombreCiudad";
                    using (var cmd = new SqlCommand(selectQuery, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var ciudad = new Ciudad()
                                {
                                    CiudadId = reader.GetInt32(0),
                                    NombreCiudad = reader.GetString(1),
                                    PaisId = reader.GetInt32(2)
                                };
                                lista.Add(ciudad);
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
    }
}
