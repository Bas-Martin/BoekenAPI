using BoekenAPI2025.Application.Interfaces;
using BoekenAPI2025.Application.Repositories;
using BoekenAPI2025.Application.Services;
using BoekenAPI2025.Domain;

namespace BoekenAPI2025.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var connectionString = "Data Source=Boeken.db";
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            ServicesConfiguration.RegisterServices(builder.Services, builder.Configuration.GetConnectionString("DefaultConnection"));

            builder.Services.AddScoped<IBoekenService, BoekenService>();
            builder.Services.AddScoped<ISchrijverService, SchrijverService>();

            builder.Services.AddScoped<IBoekenRepository, BoekenRepository>();
            builder.Services.AddScoped<ISchrijverRepository, SchrijverRepository>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("StaAlleAanvragenToe",
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("StaAlleAanvragenToe");

            app.MapControllers();

            app.Run();
        }
    }
}
