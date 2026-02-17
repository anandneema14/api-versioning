using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace api_versioning
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // API Versioning configuration
            builder.Services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.ReportApiVersions = true;
                x.ApiVersionReader = new Microsoft.AspNetCore.Mvc.Versioning.HeaderApiVersionReader("x-api-version");
            });

            // Versioned API Explorer (for Swagger grouping by version)
            builder.Services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV"; // e.g., v1, v2
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.SubstituteApiVersionInUrl = true;
            });

            // Swagger/OpenAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddOptions<SwaggerGenOptions>()
                .Configure<IApiVersionDescriptionProvider>((options, provider) =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerDoc(description.GroupName, new OpenApiInfo
                        {
                            Title = "api-versioning",
                            Version = description.GroupName,
                            Description = "API with header-based versioning (x-api-version)."
                        });
                    }
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            // Swagger middleware (enable in all environments, or restrict to Development as needed)
            var apiVersionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                // Add a Swagger endpoint per API version
                foreach (var description in apiVersionProvider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
