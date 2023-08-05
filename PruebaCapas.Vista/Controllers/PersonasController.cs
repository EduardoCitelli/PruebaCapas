namespace PruebaCapas.Vista.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PruebaCapas.Controladora;
    using PruebaCapas.Controladora.DTOs.Personas;

    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        // uso la interfaz del servicio de personas
        private readonly IPersonasService _personasService;

        //creo el constructor al que le inyecto el servicio de personas
        public PersonasController(IPersonasService personasService)
        {
            _personasService = personasService;
        }

        // GET: api/<PersonasController>
        [HttpGet]
        public async Task<List<PersonaDetalleDto>> Get()
        {
            //llamo al servicio que tiene el metodo para obtener todas las personas
            var respuesta = await _personasService.ObtenerTodos();
            return respuesta;
        }

        // GET api/<PersonasController>/5
        [HttpGet("{id}")]
        public async Task<PersonaDetalleDto> Get(int id)
        {
            //llamo al servicio que tiene el metodo para obtener una persona por id
            var respuesta = await _personasService.ObtenerPersonaPorId(id);
            return respuesta;
        }

        // POST api/<PersonasController>
        [HttpPost]
        public async Task<PersonaDetalleDto> Post([FromBody] PersonaCrearDto dto)
        {
            //llamo al servicio que tiene el metodo para crear una persona
            var respuesta = await _personasService.CrearPersona(dto);
            return respuesta;
        }

        // PUT api/<PersonasController>/5
        [HttpPut("{id}")]
        public async Task<PersonaDetalleDto> Put(int id, [FromBody] PersonaCrearDto dto)
        {
            //llamo al servicio que tiene el metodo para actualizar una persona
            var respuesta = await _personasService.ActualizarPersona(id, dto);
            return respuesta;
        }

        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public async Task<PersonaDetalleDto> Delete(int id)
        {
            //llamo al servicio que tiene el metodo para borrar una persona
            var respuesta = await _personasService.BorrarPersona(id);
            return respuesta;
        }
    }
}
