namespace PruebaCapas.Controladora
{
    using PruebaCapas.Controladora.DTOs.Personas;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPersonasService
    {
        Task<PersonaDetalleDto> ActualizarPersona(int id, PersonaCrearDto request);
        Task<PersonaDetalleDto> BorrarPersona(int id);
        Task<PersonaDetalleDto> CrearPersona(PersonaCrearDto request);
        Task<PersonaDetalleDto> ObtenerPersonaPorId(int id);
        Task<List<PersonaDetalleDto>> ObtenerTodos();
    }
}