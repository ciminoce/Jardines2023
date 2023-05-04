using Jardines2023.Datos.Repositorios;
using Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;

namespace Jardines2023.Servicios.Servicios
{
    public class ServiciosPaises
    {
        private readonly RepositorioPaises _repositorio;
        public ServiciosPaises()
        {
            _repositorio = new RepositorioPaises();
        }
        public void Borrar(int paisId)
        {
            try
            {
                _repositorio.Borrar(paisId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Pais> GetPaises()
        {
            try
            {
                return _repositorio.GetPaises();
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
                return _repositorio.GetCantidad();
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
                return _repositorio.Existe(pais);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Pais pais)
        {
            try
            {
                _repositorio.Agregar(pais);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
