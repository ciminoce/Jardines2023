using Jardines2023.Entidades.Entidades;
using System.Collections.Generic;

namespace Jardines2023.Servicios.Interfaces
{
    public interface IServiciosProductos
    {
        void Guardar(Producto producto);
        void Borrar(int productoId);
        bool Existe(Producto producto);
        int GetCantidad();
        List<Producto> GetProductos();
        List<Producto> GetProductosPorPagina(int cantidad, int pagina);

    }
}
