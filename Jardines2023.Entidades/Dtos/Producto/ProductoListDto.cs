namespace Jardines2023.Entidades.Dtos.Producto
{
    public class ProductoListDto
    {
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public string Categoria { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int UnidadesEnStock { get; set; }
        public bool Suspendido { get; set; }

    }
}
