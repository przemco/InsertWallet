using Microsoft.EntityFrameworkCore;
using Modules.Cantor.Application;
using Modules.Cantor.Application.Abstractions.Data;
using Modules.Cantor.Application.Abstractions.Services;
using Modules.Cantor.Infrastructure;
using Modules.Cantor.Infrastructure.Repositories;
using Modules.Cantor.Infrastructure.Services;
using Modules.Cantor.Presentation.Endpoints;
using Modules.Wallet.Infrastructure;
using Serilog;

namespace Modules.Cantor.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services
                .Scan(selector => selector
                    .FromAssemblies(AssemblyReference.Assembly)
                    .AddClasses()
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services
                .AddApplication();

            builder.Services.AddDbContext<CantorAppDbContext>()
                .AddScoped<ICurrencyService, CurrencyService>()
                .AddScoped<ICantorRepository, CantorRepository>()
                .AddHealthChecks();

            builder.Host.UseSerilog((ctx, cfg) => cfg.ReadFrom.Configuration(ctx.Configuration));

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<CantorAppDbContext>();
                context.Database.Migrate();
            }

            app.UseSerilogRequestLogging();

            app.MapCantorEndpoints();

            app.UseHttpsRedirection();

            app.Run();
        }
    }
}
