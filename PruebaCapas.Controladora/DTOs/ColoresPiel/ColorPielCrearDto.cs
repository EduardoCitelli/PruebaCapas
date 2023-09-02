namespace PruebaCapas.Controladora.DTOs.ColoresPiel
{
    using System.ComponentModel.DataAnnotations;

    public class ColorPielCrearDto
    {
        [Required(AllowEmptyStrings = false)]
        public string Nombre { get; set; }
    }
}
