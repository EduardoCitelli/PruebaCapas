namespace PruebaCapas.Vista
{
    using Microsoft.EntityFrameworkCore;
    using PruebaCapas.AccesoDatos;
    using PruebaCapas.Controladora;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            // Aca configuramos la base de datos
            builder.Services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });

            //vamos a configurar los servicios de la aplicación para inyectar
            //por dependencia
            builder.Services.AddScoped<IPersonasService, PersonasService>();
            builder.Services.AddScoped<IColorPielService, ColorPielService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}