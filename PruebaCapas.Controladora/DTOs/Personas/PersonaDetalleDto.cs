namespace PruebaCapas.Controladora.DTOs.Personas
{
    using PruebaCapas.Controladora.DTOs.ColoresPiel;

    public class PersonaDetalleDto : PersonaCrearDto
    {
        public int Id { get; set; }

        public ColorPielDetalleDto ColorPiel { get; set; }
    }
}
