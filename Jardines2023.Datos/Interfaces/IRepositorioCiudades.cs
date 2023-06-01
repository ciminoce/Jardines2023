using Jardines2023.Entidades.Entidades;
using System.Collections.Generic;

namespace Jardines2023.Datos.Interfaces
{
    public interface IRepositorioCiudades
    {
        void Agregar(Ciudad ciudad);
        void Borrar(int ciudadId);
        void Editar(Ciudad ciudad);
        bool Existe(Ciudad ciudad);
        List<Ciudad> Filtrar(Pais pais);
        int GetCantidad();
        List<Ciudad> GetCiudades();
        List<Ciudad> GetCiudadesPorPagina(int registrosPorPagina, int paginaActual);
        Ciudad GetCiudadPorId(int ciudadId);
    }
}
