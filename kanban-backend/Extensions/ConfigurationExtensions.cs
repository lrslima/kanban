using System;
namespace kanban_backend.Extensions
{
	public static class ConfigurationExtensions
	{
        public static IConfiguration LoadConfiguration(this WebApplicationBuilder builder)
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: false)
                .Build();
        }
    }
}

