﻿namespace PruebaCapas.Controladora.DTOs.Personas
{
    using System;

    public class PersonaCrearDto
    {
        public int IdColorPiel { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public int Dni { get; set; }

        public string? Nacionalidad { get; set; }
    }
}
