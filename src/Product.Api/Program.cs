using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Product.Domain;

namespace Product.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder
            {
                DataSource = "../../Product.db"
            };

            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();

                var createTableCommand = connection.CreateCommand();
                createTableCommand.CommandText = @"
                    CREATE TABLE IF NOT EXISTS product_items (
						id INTEGER PRIMARY KEY AUTOINCREMENT,
                        description TEXT NOT NULL,
                        status TEXT NOT NULL,
                        manufacturing_date DATETIME,
                        expiration_date DATETIME,
                        supplier_code INTEGER,
                        supplier_description TEXT,
                        supplier_company_document TEXT
                );";
                createTableCommand.ExecuteNonQuery();

                var insertDataCommand = connection.CreateCommand();
                insertDataCommand.CommandText = @"
                    INSERT INTO product_items (description, status, manufacturing_date, expiration_date, supplier_code, supplier_description, supplier_company_document)
                    VALUES
                        ('Product A', 'ACTIVE', '2020-01-01', '2021-01-01', 1, 'Supplier A', '51930618000191'),
                        ('Product B', 'ACTIVE', '2020-02-01', '2022-02-01', 2, 'Supplier B', '58983267000126'),
                        ('Product C', 'ACTIVE', '2020-03-01', '2023-03-01', 3, 'Supplier C', '71162327000108'),
                        ('Product D', 'ACTIVE', '2020-04-01', '2024-04-01', 4, 'Supplier D', '22525433000101');";
                insertDataCommand.ExecuteNonQuery();
            }

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
    }
}
