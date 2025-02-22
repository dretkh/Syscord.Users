using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Syscord.Users.Api;

public static class EntryPoint
{
    public static void Main(string[] args)
    {
        var applicationBuilder = WebApplication.CreateBuilder(args);

        applicationBuilder.Services.AddProblemDetails();
        AddHealthChecks(applicationBuilder);

        var app = applicationBuilder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapHealthChecks("/alive", new HealthCheckOptions
            {
                Predicate = r => r.Tags.Contains("live")
            });
        }

    }

    //TODO by dretkh: add application /health check
    private static void AddHealthChecks(WebApplicationBuilder builder)
    {
        builder.Services.AddHealthChecks()
            .AddCheck("liveHealthCheck", () => HealthCheckResult.Healthy(), ["live"]);
    }
}