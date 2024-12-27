using MemeTokenHub.Backoffce.Services;
using MemeTokenHub.Backoffce.Services.Interfaces;
using StackExchange.Redis;

namespace MemeTokenHub.Service.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSingleton<ITokenService,TokenService>();
            builder.Services.AddSingleton<IReadonlyCacheService, RedisCacheService>();

            string connectionString = builder.Configuration.GetConnectionString("Redis");
            var multiplexer = ConnectionMultiplexer.Connect(connectionString!);
            builder.Services.AddSingleton<IConnectionMultiplexer>(multiplexer);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
