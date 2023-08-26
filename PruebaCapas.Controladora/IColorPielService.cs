namespace PruebaCapas.Controladora
{
    using PruebaCapas.Controladora.DTOs.ColoresPiel;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IColorPielService
    {
        Task<ColorPielDetalleDto> Actualizar(int id, ColorPielCrearDto dto);
        Task<ColorPielDetalleDto> Crear(ColorPielCrearDto dto);
        Task<ColorPielDetalleDto> Eliminar(int id);
        Task<ColorPielDetalleDto> ObtenerPorId(int id);
        Task<List<ColorPielDetalleDto>> ObtenerTodos();
    }
}