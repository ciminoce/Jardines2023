﻿using Jardines2023.Datos.Interfaces;
using Jardines2023.Datos.Repositorios;
using Jardines2023.Entidades.Dtos.Cliente;
using Jardines2023.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2023.Servicios.Servicios
{
    public class ServiciosClientes : IServiciosClientes
    {
        private readonly IRepositorioClientes _repositorio;
        private readonly IRepositorioPaises _repoPais;
        private readonly IRepositorioCiudades _repoCiudades;
        public ServiciosClientes()
        {
            _repositorio=new RepositorioClientes();
            _repoPais=new RepositorioPaises();
            _repoCiudades=new RepositorioCiudades();
        }
        public List<ClienteListDto> GetClientes()
        {
            try
            {
                var listaClientes=_repositorio.GetClientes();
                foreach (var item in listaClientes)
                {
                    var pais = _repoPais.GetPaisPorId(item.PaisId);
                    var ciudad = _repoCiudades.GetCiudadPorId(item.CiudadId);
                    item.NombrePais = pais.NombrePais;
                    item.NombreCiudad = ciudad.NombreCiudad;
                }
                return listaClientes;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}