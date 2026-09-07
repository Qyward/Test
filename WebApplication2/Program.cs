using Microsoft.AspNetCore.HttpLogging;

namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddHttpLogging(opts => opts.LoggingFields = HttpLoggingFields.RequestProperties);

            builder.Logging.AddFilter("Microsoft.AspNetCore.HttpLogging", LogLevel.Information);
            
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseHttpLogging();
            }
            app.UseStaticFiles();

            app.MapGet("/", () =>
            {
                Results.BadRequest();
            });

            app.Run();
        }
    }
}
