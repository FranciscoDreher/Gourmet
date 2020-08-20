using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Gourmet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GourmetApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<GourmetContext>();

                InitializeDB(services);
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static void InitializeDB(IServiceProvider serviceProvider)
        {
            using (var context = new GourmetContext(
                serviceProvider.GetRequiredService<DbContextOptions<GourmetContext>>()))
            {
                if (context.Recetarios.Any())
                {
                    return;
                }

                var recetario1 = new Recetario("Recetario 1");
                var recetario2 = new Recetario("Recetario 2");
                var comida1 = new Comida("Comida 1");
                var comida2 = new Comida("Comida 2");
                var comida3 = new Comida("Comida 3");
                var ingrediente1 = new Ingrediente();
                var ingrediente2 = new Ingrediente();
                var ingrediente3 = new Ingrediente();
                var alimento1 = new Alimento("Alimento 1", 250, GrupoAlimenticio.Carne);
                var alimento2 = new Alimento("Alimento 2", 500, GrupoAlimenticio.Lacteo);
                var alimento3 = new Alimento("Alimento 3", 320, GrupoAlimenticio.Carne);

                ingrediente1.SetAlimento(alimento1);
                ingrediente2.SetAlimento(alimento2);
                ingrediente3.SetAlimento(alimento3);
                comida1.AddIngrediente(ingrediente1);
                comida1.AddIngrediente(ingrediente2);
                comida2.AddIngrediente(ingrediente2);
                comida3.AddIngrediente(ingrediente3);
                comida3.AddIngrediente(ingrediente1);
                recetario1.AddComida(comida1);
                recetario1.AddComida(comida2);
                recetario2.AddComida(comida3);

                context.Recetarios.Add(recetario1);
                context.Recetarios.Add(recetario2);

                context.SaveChanges();
            }
        }
    }
}
