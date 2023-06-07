using Jardines2023.Datos.Interfaces;
using Jardines2023.Datos.Repositorios;
using Jardines2023.Entidades.Dtos.Cliente;
using Jardines2023.Entidades.Entidades;
using Jardines2023.Servicios.Interfaces;
using System;
using System.Collections.Generic;

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

        public void Borrar(int clienteId)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public List<ClienteListDto> Filtrar(Pais pais)
        {
            throw new NotImplementedException();
        }

        public int GetCantidad()
        {
            try
            {
                return _repositorio.GetCantidad();
            }
            catch (Exception)
            {

                throw;
            }
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

        public List<ClienteListDto> GetClientesPorPagina(int cantidad, int pagina)
        {
            try
            {
                var listaClientes = _repositorio.GetClientesPorPagina(cantidad,pagina);
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

        public void Guardar(Cliente cliente)
        {
            try
            {
                if (cliente.ClienteId==0)
                {
                    _repositorio.Agregar(cliente);
                }
                else
                {
                    _repositorio.Editar(cliente);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
