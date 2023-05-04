﻿using Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Jardines2023.Datos.Repositorios
{
    public class RepositorioPaises
    {
        private SqlConnection _conn;
        private readonly string cadenaConexion;
        public RepositorioPaises()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }


        public void Agregar(Pais pais)
        {
            try
            {
                using (var conn=new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string insertQuery = "INSERT INTO Paises (NombrePais) VALUES(@NombrePais); SELECT SCOPE_IDENTITY()";
                    using (var comando=new SqlCommand(insertQuery,conn))
                    {
                        comando.Parameters.Add("@NombrePais", SqlDbType.NVarChar);
                        comando.Parameters["@NombrePais"].Value = pais.NombrePais;

                        int id = Convert.ToInt32(comando.ExecuteScalar());
                        pais.PaisId = id;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Borrar(int paisId)
        {
            try
            {
                using (var conn=new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM Paises WHERE PaisId=@PaisId";
                    using (var comando=new SqlCommand(deleteQuery,conn))
                    {
                        comando.Parameters.Add("@PaisId", SqlDbType.Int);
                        comando.Parameters["@PaisId"].Value = paisId;

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Editar(Pais pais) { }
        public List<Pais> GetPaises()
        {
            try
            {
                List<Pais> lista=new List<Pais> ();
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string selectQuery = "SELECT PaisId, NombrePais FROM Paises";
                    using (var comando = new SqlCommand(selectQuery, conn))
                    {
                        using (var reader=comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var pais = new Pais()
                                {
                                    PaisId = reader.GetInt32(0),
                                    NombrePais = reader.GetString(1)
                                };
                                lista.Add(pais);
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

        public int GetCantidad()
        {
            try
            {
                int cantidad = 0;
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string selectQuery = "SELECT COUNT(*) FROM Paises";
                    using (var comando=new SqlCommand(selectQuery,conn))
                    {
                        cantidad =(int) comando.ExecuteScalar();
                    }
                }  
                return cantidad;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Pais pais)
        {
            try
            {
                var cantidad = 0;
                using (var conn=new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string selectQuery = "SELECT COUNT(*) FROM Paises WHERE NombrePais=@NombrePais";
                    using (var comando=new SqlCommand(selectQuery,conn))
                    {
                        comando.Parameters.Add("@NombrePais",SqlDbType.NVarChar);
                        comando.Parameters["@NombrePais"].Value = pais.NombrePais;

                        cantidad=(int) comando.ExecuteScalar();
                    }
                }
                return cantidad > 0;
            }
            catch (Exception)
            {

                throw;
            }    
        }
    }
}
