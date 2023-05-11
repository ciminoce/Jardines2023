using Jardines2023.Datos.Interfaces;
using Jardines2023.Datos.Repositorios;
using Jardines2023.Entidades.Entidades;
using Jardines2023.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2023.Servicios.Servicios
{
    public class ServiciosCiudades : IServiciosCiudades
    {
        private readonly IRepositorioCiudades _repositorio;
        private readonly IRepositorioPaises _repoPaises;
        public ServiciosCiudades()
        {
            _repositorio = new RepositorioCiudades();
            _repoPaises = new RepositorioPaises();
        }
        public void Borrar(int ciudadId)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Ciudad ciudad)
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

        public List<Ciudad> GetCiudades()
        {
            try
            {
                var lista= _repositorio.GetCiudades();
                foreach (var item in lista)
                {
                    item.Pais = _repoPaises.GetPaisPorId(item.PaisId);
                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Ciudad ciudad)
        {
            throw new NotImplementedException();
        }
    }
}
