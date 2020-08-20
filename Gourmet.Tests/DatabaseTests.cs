using System;
using Xunit;
using Gourmet;
using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Gourmet.Tests
{
    public class DatabaseTests
    {
        [Fact]
        public void CreateRecetario_ReturnsOneElement()
        {
            var conexion = new SqliteConnection("DataSource=:memory:");
            conexion.Open();

            try
            {
                var options = new DbContextOptionsBuilder<GourmetContext>()
                    .UseSqlite(conexion)
                    .Options;

                // Create the schema in the database
                using (var context = new GourmetContext(options))
                {
                    context.Database.EnsureCreated();
                }

                int result; 

                // Run the test against one instance of the context
                using (var context = new GourmetContext(options))
                {
                    // Arrange
                    var recetario = new Recetario();
                    var comida = new Comida();
                    var ingrediente = new Ingrediente();
                    recetario.SetTitulo("Mi Recetario");
                    recetario.AddComida(comida);
                    comida.AddIngrediente(ingrediente);
                    context.Add(recetario);
                    context.SaveChanges();

                    // Act
                    result = context.RecetarioComidas.Count();
                }

                Assert.Equal(1, result);
            }
            finally
            {
                conexion.Close();
            }
        }

        [Fact]
        public void ReadRecetario_ReturnsOneElement()
        {
            var conexion = new SqliteConnection("DataSource=:memory:");
            conexion.Open();

            try
            {
                var options = new DbContextOptionsBuilder<GourmetContext>()
                    .UseSqlite(conexion)
                    .Options;

                // Create the schema in the database
                using (var context = new GourmetContext(options))
                {
                    context.Database.EnsureCreated();
                }

                int result; 

                // Run the test against one instance of the context
                using (var context = new GourmetContext(options))
                {
                    // Arrange
                    var recetario = FixtureTests.GetEmptyRecetario();
                    var comida = FixtureTests.GetComida_WithIngredientes();
                    comida.SetNombre("Mi Comida 2");
                    recetario.SetTitulo("Recetario 2");
                    recetario.AddComida(comida);
                    context.Add(recetario);
                    context.SaveChanges();

                    // Act
                    var resultQuery = context.Comidas.Where(c => c.Nombre == "Mi Comida 2");
                    result = resultQuery.Count();
                }

                Assert.Equal(1, result);
            }
            finally
            {
                conexion.Close();
            }
        }

        [Fact]
        public void UpdateRecetario_ReturnsFalse()
        {
            var conexion = new SqliteConnection("DataSource=:memory:");
            conexion.Open();

            try
            {
                var options = new DbContextOptionsBuilder<GourmetContext>()
                    .UseSqlite(conexion)
                    .Options;

                // Create the schema in the database
                using (var context = new GourmetContext(options))
                {
                    context.Database.EnsureCreated();
                }

                bool result; 

                // Run the test against one instance of the context
                using (var context = new GourmetContext(options))
                {
                    // Arrange
                    var recetario = FixtureTests.GetEmptyRecetario();
                    recetario.SetTitulo("Mi Recetario");
                    context.Add(recetario);
                    context.SaveChanges();
                    var recetarioQuery = context.Recetarios.Where(r => r.Titulo == "Mi Recetario").First();
                    recetarioQuery.SetTitulo("Recetario modificado");
                    context.SaveChanges();

                    // Act
                    var resultQuery = context.Recetarios.First();
                    result = resultQuery.Titulo == "Mi Recetario";
                }

                Assert.False(result, $"The result should be False. Actual result: {result}");
            }
            finally
            {
                conexion.Close();
            }
        }

        [Fact]
        public void DeleteRecetario_ReturnsZeroElements()
        {
            var conexion = new SqliteConnection("DataSource=:memory:");
            conexion.Open();

            try
            {
                var options = new DbContextOptionsBuilder<GourmetContext>()
                    .UseSqlite(conexion)
                    .Options;

                // Create the schema in the database
                using (var context = new GourmetContext(options))
                {
                    context.Database.EnsureCreated();
                }

                int result; 

                // Run the test against one instance of the context
                using (var context = new GourmetContext(options))
                {
                    // Arrange
                    var recetario = FixtureTests.GetEmptyRecetario();
                    recetario.SetTitulo("Mi Recetario");
                    context.Add(recetario);
                    context.SaveChanges();
                    context.Remove(recetario);
                    context.SaveChanges();

                    // Act
                    result = context.Recetarios.Count();
                }

                Assert.Equal(0, result);
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}