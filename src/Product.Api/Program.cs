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
                        ('Toothbrush', 'ACTIVE', '2023-05-01', '2023-06-30', 1001, 'Oral B', '43211234'),
                        ('Toothpaste', 'ACTIVE', '2023-04-01', '2023-06-30', 1001, 'Oral B', '43211234'),
                        ('Soap', 'ACTIVE', '2023-03-01', '2023-05-31', 1002, 'Dove', '56789012'),
                        ('Shampoo', 'ACTIVE', '2023-02-01', '2023-05-31', 1002, 'Dove', '56789012'),
                        ('Conditioner', 'ACTIVE', '2023-01-01', '2023-05-31', 1002, 'Dove', '56789012'),
                        ('Lotion', 'ACTIVE', '2023-06-01', '2023-07-30', 1003, 'Nivea', '67890123'),
                        ('Hand Wash', 'ACTIVE', '2023-06-01', '2023-07-30', 1003, 'Nivea', '67890123'),
                        ('Body Cream', 'ACTIVE', '2023-07-01', '2023-08-31', 1004, 'Palmolive', '78901234'),
                        ('Shaving Cream', 'ACTIVE', '2023-07-01', '2023-08-31', 1004, 'Palmolive', '78901234'),
                        ('Razor', 'ACTIVE', '2023-08-01', '2023-09-30', 1005, 'Gillette', '89012345'),
                        ('Tissues', 'ACTIVE', '2023-08-01', '2023-09-30', 1006, 'Kleenex', '90123456'),
                        ('Toilet Paper', 'ACTIVE', '2023-09-01', '2023-10-31', 1006, 'Kleenex', '90123456'),
                        ('Paper Towels', 'ACTIVE', '2023-09-01', '2023-10-31', 1006, 'Kleenex', '90123456'),
                        ('Cleaning Spray', 'ACTIVE', '2023-10-01', '2023-11-30', 1007, 'Lysol', '01234567'),
                        ('Air Freshener', 'ACTIVE', '2023-10-01', '2023-11-30', 1007, 'Lysol', '01234567'),
                        ('Light Bulbs', 'ACTIVE', '2023-11-01', '2023-12-31', 1008, 'GE', '23456789');";
                insertDataCommand.ExecuteNonQuery();
            }

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
    }
}
