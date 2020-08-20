using System;
using Xunit;
using Gourmet;

namespace Gourmet.Tests
{
    public class ComensalTests
    {
        [Fact]
        public void EsApto_PerfilCeliaco_WrongInput_ReturnFalse_Should()
        {
            var comida = FixtureTests.GetEmptyComida();
            comida.AddIngrediente(FixtureTests.GetIngrediente_ConCereal());
            var comensal = FixtureTests.GetComensalCeliaco();

            var result = comensal.EsApto(comida);

            Assert.False(result, $"The result should be False. Actual result: {result}");
        }

        [Fact]
        public void EsApto_PerfilCeliaco_RightInput_ReturnTrue_Should()
        {
            var comida = FixtureTests.GetEmptyComida();
            comida.AddIngrediente(FixtureTests.GetIngrediente_Celiaco());
            var comensal = FixtureTests.GetComensalCeliaco();

            var result = comensal.EsApto(comida);

            Assert.True(result, $"The result should be True. Actual result: {result}");
        }
        
        [Fact]
        public void EsApto_PerfilVegetariano_WrongInput_ReturnFalse_Should()
        {
            var comida = FixtureTests.GetEmptyComida();
            comida.AddIngrediente(FixtureTests.GetIngrediente_Carnivoro());
            var comensal = FixtureTests.GetComensalVegetariano();

            var result = comensal.EsApto(comida);

            Assert.False(result, $"The result should be False. Actual result: {result}");
        }

        [Fact]
        public void EsApto_PerfilVegetariano_RightInput_ReturnTrue_Should()
        {
            var comida = FixtureTests.GetEmptyComida();
            comida.AddIngrediente(FixtureTests.GetIngrediente_Vegetariano());
            var comensal = FixtureTests.GetComensalVegetariano();

            var result = comensal.EsApto(comida);

            Assert.True(result, $"The result should be True. Actual result: {result}");
        }
        
        [Fact]
        public void EsApto_PerfilVegano_WrongInput_ReturnFalse_Should()
        {
            var comida = FixtureTests.GetEmptyComida();
            comida.AddIngrediente(FixtureTests.GetIngrediente_Carnivoro());
            comida.AddIngrediente(FixtureTests.GetIngrediente_WithOneAlimento1());
            var comensal = FixtureTests.GetComensalVegano();

            var result = comensal.EsApto(comida);

            Assert.False(result, $"The result should be False. Actual result: {result}");
        }

        [Fact]
        public void EsApto_PerfilVegano_RightInput_ReturnTrue_Should()
        {
            var comida = FixtureTests.GetEmptyComida();
            comida.AddIngrediente(FixtureTests.GetIngrediente_Vegano());
            var comensal = FixtureTests.GetComensalVegano();

            var result = comensal.EsApto(comida);

            Assert.True(result, $"The result should be True. Actual result: {result}");
        }
        
        [Fact]
        public void EsApto_PerfilCarnivoro_WrongInput_ReturnFalse_Should()
        {
            var comida = FixtureTests.GetEmptyComida();
            comida.AddIngrediente(FixtureTests.GetIngrediente_Carnivoro_CaloriasMenorA200());
            var comensal = FixtureTests.GetComensalCarnivoro();

            var result = comensal.EsApto(comida);

            Assert.False(result, $"The result should be False. Actual result: {result}");
        }

        [Fact]
        public void EsApto_PerfilCarnivoro_RightInput_ReturnTrue_Should()
        {
            var comida = FixtureTests.GetEmptyComida();
            comida.AddIngrediente(FixtureTests.GetIngrediente_Carnivoro());
            var comensal = FixtureTests.GetComensalCarnivoro();

            var result = comensal.EsApto(comida);

            Assert.True(result, $"The result should be True. Actual result: {result}");
        }
    }
}