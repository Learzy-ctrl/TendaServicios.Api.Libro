namespace TendaServicios.Api.Libro.Aplicacion
{
    public class LibroMaterialDto
    {
        public Guid? LibreriaMaterialId { get; set; }
        public string Titulo { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public double Precio { get; set; }
        public string Descripcion {  get; set; }
        public byte[]? Img { get; set; }
        public int? CuponId { get; set; }
        public Guid? AutorLibro { get; set; }
    }
}
