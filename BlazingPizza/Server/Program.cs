using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazingPizza.Server.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BlazingPizza.Server {
    public class Program {
        public static void Main(string[] args) {
            var Host = CreateHostBuilder(args).Build();

            //Seeding Data
            var ScopeFactory = Host.Services.GetRequiredService<IServiceScopeFactory>();

            using (var scope = ScopeFactory.CreateScope()) {

                var context =
                    scope.ServiceProvider.GetRequiredService<PizzaStoreContext>();

                if (context.Specials.Count() == 0) {
                    SeedData.Initialize(context);
                }

            }
            //End of seeding. Tambien puedo hacerlo en OnModelCreating() del contexto
            
            Host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
