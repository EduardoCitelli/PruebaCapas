namespace PruebaCapas.Controladora
{
    using Microsoft.EntityFrameworkCore;
    using PruebaCapas.AccesoDatos;
    using PruebaCapas.Controladora.DTOs.ColoresPiel;
    using PruebaCapas.Controladora.DTOs.Personas;
    using PruebaCapas.Modelos;

    public class PersonasService : IPersonasService
    {
        private readonly ApplicationContext _context;

        public PersonasService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<PersonaDetalleDto> CrearPersona(PersonaCrearDto request)
        {
            ChequearSiExisteColorPiel(request.IdColorPiel);

            //Mapeamos del DTO a la Entidad
            var persona = new Persona
            {
                Nombre = request.Nombre,
                Apellido = request.Apellido,
                Dni = request.Dni,
                FechaNacimiento = request.FechaNacimiento,
                Nacionalidad = request.Nacionalidad,
                IdColorPiel = request.IdColorPiel,
            };

            //Agrego la entidad creada a la base de datos asincronamente
            await _context.AddAsync(persona);

            //Guardo los cambios
            await _context.SaveChangesAsync();

            //Mapeamos de la entidad al DTO de respuesta
            var respuesta = new PersonaDetalleDto
            {
                Id = persona.Id,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                Dni = persona.Dni,
                FechaNacimiento = persona.FechaNacimiento,
                Nacionalidad = persona.Nacionalidad,
                ColorPiel = new ColorPielDetalleDto
                {
                    Id = persona.IdColorPiel,
                    Nombre = persona.ColorPiel.Nombre,
                },
            };

            //Devolvemos la respuesta
            return respuesta;
        }

        

        public async Task<PersonaDetalleDto> ActualizarPersona(int id, PersonaCrearDto request)
        {
            ChequearSiExisteColorPiel(request.IdColorPiel);

            //Obtener a la persona por ID
            var persona = await _context.Personas.FindAsync(id);

            //Valido que esa persona con ese id exista
            if (persona == null)
                throw new Exception($"No se encontro la persona con el id: {id}");

            //Mapeamos del DTO a la Entidad
            persona.Nombre = request.Nombre;
            persona.Apellido = request.Apellido;
            persona.Dni = request.Dni;
            persona.FechaNacimiento = request.FechaNacimiento;
            persona.Nacionalidad = request.Nacionalidad;
            persona.IdColorPiel = request.IdColorPiel;

            //Actualizo la entidad en la base de datos sincronicamente
            _context.Update(persona);

            //Guardo los cambios
            await _context.SaveChangesAsync();

            //Mapeamos de la entidad al DTO de respuesta
            var respuesta = new PersonaDetalleDto
            {
                Id = persona.Id,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                Dni = persona.Dni,
                FechaNacimiento = persona.FechaNacimiento,
                Nacionalidad = persona.Nacionalidad,
                IdColorPiel = persona.IdColorPiel,
                ColorPiel = new ColorPielDetalleDto
                {
                    Id = persona.IdColorPiel,
                    Nombre = persona.ColorPiel.Nombre,
                },

            };

            //Devolvemos la respuesta
            return respuesta;
        }

        public async Task<PersonaDetalleDto> BorrarPersona(int id)
        {
            //Obtener a la persona por ID
            var persona = await _context.Personas.FindAsync(id);

            //Valido que esa persona con ese id exista
            if (persona == null)
                throw new Exception($"No se encontro la persona con el id: {id}");

            //Actualizo la entidad en la base de datos sincronicamente
            _context.Personas.Remove(persona);

            //Guardo los cambios
            await _context.SaveChangesAsync();

            //Mapeamos de la entidad al DTO de respuesta
            var respuesta = new PersonaDetalleDto
            {
                Id = persona.Id,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                Dni = persona.Dni,
                FechaNacimiento = persona.FechaNacimiento,
                Nacionalidad = persona.Nacionalidad,
                IdColorPiel= persona.IdColorPiel,
                ColorPiel = new ColorPielDetalleDto
                {
                    Id = persona.IdColorPiel,
                    Nombre = persona.ColorPiel.Nombre,
                },
            };

            //Devolvemos la respuesta
            return respuesta;
        }

        public async Task<PersonaDetalleDto> ObtenerPersonaPorId(int id)
        {
            //Obtener a la persona por ID
            var persona = await _context.Personas.Include(x => x.ColorPiel)
                                                 .SingleOrDefaultAsync(x => x.Id == id);        

            //Valido que esa persona con ese id exista
            if (persona == null)
                throw new Exception($"No se encontro la persona con el id: {id}");

            //Mapeamos de la entidad al DTO de respuesta
            var respuesta = new PersonaDetalleDto
            {
                Id = persona.Id,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                Dni = persona.Dni,
                FechaNacimiento = persona.FechaNacimiento,
                Nacionalidad = persona.Nacionalidad,
                IdColorPiel = persona.IdColorPiel,
                ColorPiel = new ColorPielDetalleDto
                {
                    Id = persona.IdColorPiel,
                    Nombre = persona.ColorPiel.Nombre,
                },
            };

            //Devolvemos la respuesta
            return respuesta;
        }

        public async Task<List<PersonaDetalleDto>> ObtenerTodos()
        {
            // obtenemos todos los registros de personas en la base de datos
            // pero en el select solo usamos los datos necesarios para crear
            // un dto
            var respuesta = await _context.Personas.Select(persona => new PersonaDetalleDto
            {
                Id = persona.Id,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                Dni = persona.Dni,
                FechaNacimiento = persona.FechaNacimiento,
                Nacionalidad = persona.Nacionalidad,
                IdColorPiel = persona.IdColorPiel,
                ColorPiel = new ColorPielDetalleDto
                {
                    Id = persona.IdColorPiel,
                    Nombre = persona.ColorPiel.Nombre,
                },
            }).ToListAsync();

            //Devolvemos la respuesta
            return respuesta;
        }

        private void ChequearSiExisteColorPiel(int idColorPiel)
        {
            bool existeColorPiel = _context.ColoresPiel.Any(x => x.Id == idColorPiel);

            if (!existeColorPiel)
            {
                throw new Exception($"El color de piel con id {idColorPiel} no existe");
            }
        }
    }
}
