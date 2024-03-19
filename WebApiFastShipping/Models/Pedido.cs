namespace WebApiFastShipping.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string productos {  get; set; }
        public string dirrec {  get; set; }
        public string direnvio { get; set;}
        public string estadopedido { get; set; }

    }
}
