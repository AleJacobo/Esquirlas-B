using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esquirlas.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /* cambiado por app.UseExceptionHandler que nos recomendo sebas
            //Configuracion de tratamiento de errores basica
            try
            {
                Log.Information("Starting Web Host");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
            */
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)

                //Configuracion Personalizada de la Connection
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var settings = config.Build();
                    Serilog.Log.Logger = new LoggerConfiguration()
                        .Enrich.FromLogContext()
                        .WriteTo.MSSqlServer(
                            connectionString: settings.GetConnectionString("Sql"),
                            sinkOptions: new MSSqlServerSinkOptions()
                            {
                                AutoCreateSqlTable = true,
                                TableName = "Logs"
                            })
                        .WriteTo.Console()
                        .CreateLogger();
                })
                .UseSerilog()

                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
