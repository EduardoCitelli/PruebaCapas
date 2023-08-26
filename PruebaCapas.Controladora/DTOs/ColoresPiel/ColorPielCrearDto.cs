namespace PruebaCapas.Controladora.DTOs.ColoresPiel
{
    using System.ComponentModel.DataAnnotations;

    public class ColorPielCrearDto
    {
        [Required]
        [MinLength(3)]
        public string Nombre { get; set; }
    }
}
