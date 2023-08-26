namespace PruebaCapas.Modelos
{
    public class ColorPiel
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public virtual List<Persona> Personas { get; set; } = new List<Persona>();
    }
}
