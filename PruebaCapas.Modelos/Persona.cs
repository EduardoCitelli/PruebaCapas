namespace PruebaCapas.Modelos
{
    using System;

    public class Persona
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public int Dni { get; set; }

        public string? Nacionalidad { get; set; }
    }
}
