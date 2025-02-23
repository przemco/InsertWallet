using Microsoft.EntityFrameworkCore;
using Modules.Wallet.Application;
using Modules.Wallet.Infrastructure;
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

            builder.Services.AddDbContext<WalletAppDbContext>();

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

            app.UseHttpsRedirection();

            app.Run();
        }
    }
}
