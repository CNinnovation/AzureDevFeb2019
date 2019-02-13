using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.IO;
using System.Threading.Tasks;

namespace TableStorageSample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            DefineConfiguration(args);
            var account = CloudStorageAccount.Parse(Configuration["MyTableConnection"]);
            var tableClient = account.CreateCloudTableClient();
            var sampletable = tableClient.GetTableReference("mysampletable");
            bool created = await sampletable.CreateIfNotExistsAsync();

            var entity = new Book()
            {
                 PartitionKey = "BestBooksInTown",
                 RowKey = Guid.NewGuid().ToString(),
                 Title = "Professional C# 7",
                 Publisher = "Wrox Press"
            };
            var operation = TableOperation.Insert(entity);
            var result = await sampletable.ExecuteAsync(operation);
           
        }

        public static IConfiguration Configuration { get; set; }

        private static void DefineConfiguration(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddUserSecrets("MyTableStorageSample")
                .AddCommandLine(args)
                .Build();
            Configuration = config;
        }
    }
}
