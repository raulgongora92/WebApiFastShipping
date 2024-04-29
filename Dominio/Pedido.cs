namespace Dominio.Entities
{
    public class Pedido
    {
        public required int Id { get; set; }
        public string Descripcion { get; set; }
        public string IdProductos { get; set; }
        public string Dirrec { get; set; }
        public string direnvio { get; set; }
        public string Estado { get; set; }

    }
}
