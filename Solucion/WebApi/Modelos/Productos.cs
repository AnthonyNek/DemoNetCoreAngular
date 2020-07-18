using System.ComponentModel.DataAnnotations;

namespace WebApi.Modelos
{
    public class Productos
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal? Precio { get; set; }
        public string Tipo { get; set; }
    }
}
