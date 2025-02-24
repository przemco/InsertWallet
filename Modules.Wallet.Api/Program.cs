using Microsoft.EntityFrameworkCore;
using Modules.Wallet.Api.Endpoints;
using Modules.Wallet.Application;
using Modules.Wallet.Application.Abstractions.Data;
using Modules.Wallet.Domain;
using Modules.Wallet.Infrastructure;
using Modules.Wallet.Infrastructure.Repositories;
using Serilog;

namespace Modules.Wallet.Api
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

            builder.Services.AddDbContext<WalletAppDbContext>()
                .AddScoped<IWalletRepository, WalletRepository>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
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
                var context = scope.ServiceProvider.GetRequiredService<WalletAppDbContext>();
                context.Database.Migrate();
            }

            app.UseSerilogRequestLogging();

            app.MapWalletEndpoints();

            app.UseHttpsRedirection();

            app.Run();
        }
    }
}
