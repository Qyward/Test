using Microsoft.AspNetCore.HttpLogging;
using System.Security.Cryptography.X509Certificates;

namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Account> accounts = new List<Account>();
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddHttpLogging(opts => opts.LoggingFields = HttpLoggingFields.RequestProperties);

            builder.Logging.AddFilter("Microsoft.AspNetCore.HttpLogging", LogLevel.Information);
            
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseHttpLogging();
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.MapGet("/reg", (string email, string password) =>
            {
                accounts.Add(new Account(email, password));
            });
            app.MapGet("/reg/list", () =>
            {
                return accounts;
            });
            app.Run();
        }
    }
    public class Account
    {
        public string Email {  get; set; }
        public string Password {  get; set; }
        public Account(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
