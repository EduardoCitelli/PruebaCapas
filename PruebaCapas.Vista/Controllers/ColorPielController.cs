namespace PruebaCapas.Vista.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PruebaCapas.Controladora;
    using PruebaCapas.Controladora.DTOs.ColoresPiel;

    [ApiController]
    [Route("api/[controller]")]
    public class ColorPielController : ControllerBase
    {
        private readonly IColorPielService _colorPielService;

        public ColorPielController(IColorPielService colorPielService)
        {
            _colorPielService = colorPielService;
        }

        [HttpGet]
        public async Task<List<ColorPielDetalleDto>> Get()
        {
            var respuesta = await _colorPielService.ObtenerTodos();
            return respuesta;
        }

        [HttpGet("{id}")]
        public async Task<ColorPielDetalleDto> GetById([FromRoute] int id)
        {
            var respuesta = await _colorPielService.ObtenerPorId(id);
            return respuesta;
        }

        [HttpPost]
        public async Task<ColorPielDetalleDto> Post([FromBody] ColorPielCrearDto dto)
        {
            var respuesta = await _colorPielService.Crear(dto);
            return respuesta;
        }

        [HttpPut("{id}")]
        public async Task<ColorPielDetalleDto> Put([FromRoute] int id, 
                                                   [FromBody] ColorPielCrearDto dto)
        {
            var respuesta = await _colorPielService.Actualizar(id, dto);
            return respuesta;
        }

        [HttpDelete("{id}")]
        public async Task<ColorPielDetalleDto> Delete([FromRoute] int id)
        {
            var respuesta = await _colorPielService.Eliminar(id);
            return respuesta;
        }
    }
}
