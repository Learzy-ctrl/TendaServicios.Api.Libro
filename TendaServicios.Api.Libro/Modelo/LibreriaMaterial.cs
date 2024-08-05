using System.ComponentModel.DataAnnotations;

namespace TendaServicios.Api.Libro.Modelo
{
    public class LibreriaMaterial
    {
        [Key]
        public Guid? LibreriaMaterialId { get; set; }
        public string Titulo {  get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public string Descripcion { get; set; }
        public double Precio {  get; set; }
        public byte[]? Img {  get; set; }
        public int? CuponId {  get; set; }
        public Guid? AutorLibro { get; set;}

    }
}
