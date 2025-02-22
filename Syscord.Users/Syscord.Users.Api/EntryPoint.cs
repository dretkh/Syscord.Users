using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Syscord.Users.Api;

public static class EntryPoint
{
    public static void Main(string[] args)
    {
        var applicationBuilder = WebApplication.CreateBuilder(args);

        ConfigureContainer(applicationBuilder);
        applicationBuilder.Services.AddControllers()
        applicationBuilder.Services.AddProblemDetails();
        AddHealthChecks(applicationBuilder);
        
        
        var app = applicationBuilder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.MapHealthChecks("/alive", new HealthCheckOptions
            {
                Predicate = r => r.Tags.Contains("live")
            });
            app.UseSwagger();
            app.UseSwaggerUI();
        }

    }

    //TODO by dretkh: add application /health check
    private static void AddHealthChecks(WebApplicationBuilder builder)
    {
        builder.Services.AddHealthChecks()
            .AddCheck("liveHealthCheck", () => HealthCheckResult.Healthy(), ["live"]);
    }

    private static void ConfigureContainer(WebApplicationBuilder builder)
    {
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        
    }
}