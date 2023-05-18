using Jardines2023.Entidades.Entidades;
using System.Collections.Generic;

namespace Jardines2023.Servicios.Interfaces
{
    public interface IServiciosCategorias
    {
        void Borrar(int categoriaId);
        bool Existe(Categoria categoria);
        int GetCantidad();
        List<Categoria> GetCategorias();
        void Guardar(Categoria categoria);
    }
}