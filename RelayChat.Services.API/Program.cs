using RelayChat.Services.Infrastructure.RealTime;
using RelayChat.Services.Infrastructure.Services;

namespace RelayChat.Services.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSignalR();

            builder.Services.AddCors(o =>
            {
                o.AddPolicy("AllowAnyOrigin", p => p
                    .WithOrigins("null") 
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapControllers();

            app.UseRouting();

            app.MapControllers();

            app.MapHub<RealTimeHub>("/realtimehub");

            app.UseAuthorization();

            app.UseCors("AllowAnyOrigin");

            app.Run();
        }
    }
}