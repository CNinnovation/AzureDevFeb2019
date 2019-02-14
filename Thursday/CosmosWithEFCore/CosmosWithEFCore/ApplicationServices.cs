using CosmosWithEFCore.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CosmosWithEFCore.Services;

namespace CosmosWithEFCore
{
    public class ApplicationServices
    {
        public ApplicationServices(IConfiguration configuration)
        {
            Container = RegisterServices(configuration);
        }

        public IServiceProvider Container { get; }


        public ServiceProvider RegisterServices(IConfiguration configuration)
        {
            var services = new ServiceCollection();
            services.AddDbContext<BooksContext>(options =>
            {
                string endpoint = configuration["ServiceEndpoint"];
                string authKey = configuration["AuthKey"];
                string databaseName = configuration["DatabaseName"];

                options.UseCosmos(endpoint, authKey, databaseName);
            });
            services.AddTransient<BooksSampleService>();

            return services.BuildServiceProvider();
        }
    }
}
