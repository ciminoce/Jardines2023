using Jardines2023.Entidades.Entidades;
using System.Collections.Generic;

namespace Jardines2023.Comun.Interfaces
{
    public interface IRepositorioProductos
    {
        void Agregar(Producto producto);
        void Borrar(int productoId);
        void Editar(Producto producto);
        bool Existe(Producto producto);
        int GetCantidad();
        List<Producto> GetProductos();
        List<Producto> GetProductosPorPagina(int cantidad, int pagina);

    }
}
