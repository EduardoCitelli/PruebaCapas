namespace PruebaCapas.Controladora
{
    using Microsoft.EntityFrameworkCore;
    using PruebaCapas.AccesoDatos;
    using PruebaCapas.Controladora.DTOs.ColoresPiel;
    using PruebaCapas.Modelos;

    public class ColorPielService : IColorPielService
    {
        private readonly ApplicationContext _context;

        public ColorPielService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<ColorPielDetalleDto>> ObtenerTodos()
        {
            var coloresPiel = await _context.ColoresPiel.Select(cp => new ColorPielDetalleDto
            {
                Id = cp.Id,
                Nombre = cp.Nombre,
            }).ToListAsync();

            return coloresPiel;
        }

        public async Task<ColorPielDetalleDto> ObtenerPorId(int id)
        {
            var colorPiel = await _context.ColoresPiel.FindAsync(id);

            if (colorPiel == null)
            {
                throw new Exception($"El color de piel con el id {id} no existe");
            }

            return new ColorPielDetalleDto
            {
                Id = colorPiel.Id,
                Nombre = colorPiel.Nombre,
            };
        }

        public async Task<ColorPielDetalleDto> Crear(ColorPielCrearDto dto)
        {
            var entidad = new ColorPiel
            {
                Nombre = dto.Nombre,
            };

            var existeNombre = await _context.ColoresPiel
                                             .AnyAsync(x => x.Nombre.ToLower() == dto.Nombre.ToLower());

            if (existeNombre)
                throw new Exception($"El nombre {dto.Nombre} ya existe usa otro chabon");

            await _context.AddAsync(entidad);
            await _context.SaveChangesAsync();

            return new ColorPielDetalleDto
            {
                Id = entidad.Id,
                Nombre = entidad.Nombre,
            };
        }

        public async Task<ColorPielDetalleDto> Actualizar(int id, ColorPielCrearDto dto)
        {
            var entidad = await IntentarObtenerPorId(id);

            entidad.Nombre = dto.Nombre;

            _context.Update(entidad);
            await _context.SaveChangesAsync();

            return new ColorPielDetalleDto
            {
                Id = entidad.Id,
                Nombre = entidad.Nombre
            };
        }

        public async Task<ColorPielDetalleDto> Eliminar(int id)
        {
            var entidad = await IntentarObtenerPorId(id);

            _context.Remove(entidad);
            await _context.SaveChangesAsync();

            return new ColorPielDetalleDto
            {
                Id = entidad.Id,
                Nombre = entidad.Nombre
            };
        }

        private async Task<ColorPiel> IntentarObtenerPorId(int id)
        {
            var colorPiel = await _context.ColoresPiel.FindAsync(id);

            if (colorPiel == null)
            {
                throw new Exception($"El color de piel con el id {id} no existe");
            }

            return colorPiel;
        }
    }
}
