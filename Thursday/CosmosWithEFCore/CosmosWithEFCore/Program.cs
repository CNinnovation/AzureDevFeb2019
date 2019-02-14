using Microsoft.Extensions.Configuration;
using System;
using Microsoft.Extensions.DependencyInjection;
using CosmosWithEFCore.Services;
using System.Threading.Tasks;

namespace CosmosWithEFCore
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IConfiguration configuration = SetupConfiguration();
            var services = new ApplicationServices(configuration);
            var booksService = services.Container.GetRequiredService<BooksSampleService>();
            await booksService.CreateDatabaseAsync();
            await booksService.CreateSampleBookAsync();

        }

        private static IConfiguration SetupConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets("94c9ad3a-fade-4ba0-9be8-67fdc0709d20")
                .Build();
            return config;
        }
    }
}
