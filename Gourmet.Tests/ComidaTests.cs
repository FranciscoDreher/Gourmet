using System;
using Xunit;
using Gourmet;

namespace Gourmet.Tests
{
    public class ComidaTests
    {
        [Fact]
        public void Ingredientes_Count_WithEmptyList_Should()
        {
            var comida = FixtureTests.GetEmptyComida();

            int result = comida.ComidaIngredientes.Count;

            Assert.Equal(0, result);
        }

        [Fact]
        public void Ingredientes_Count_WithOneElement_Should()
        {
            var comida = FixtureTests.GetEmptyComida();
            comida.AddIngrediente(FixtureTests.GetIngrediente_WithTwoAlimento1());

            int result = comida.ComidaIngredientes.Count;

            Assert.Equal(1, result);
        }

        [Fact]
        public void CalculaCalorias_WithEmptyList_Should()
        {
            var comida = FixtureTests.GetEmptyComida();

            int result = comida.CalculaCalorias();

            Assert.Equal(0, result);
        }

        [Fact]
        public void CalculaCalorias_WithOneElement_Should()
        {
            var comida = FixtureTests.GetEmptyComida();
            comida.AddIngrediente(FixtureTests.GetIngrediente_WithTwoAlimento1());

            int result = comida.CalculaCalorias();

            Assert.Equal(300, result);
        }

        [Fact]
        public void CalculaCalorias_WithOneElementAddedTwoTimes_Should()
        {
            var comida = FixtureTests.GetEmptyComida();
            comida.AddIngrediente(FixtureTests.GetIngrediente_WithTwoAlimento1());
            comida.AddIngrediente(FixtureTests.GetIngrediente_WithOneAlimento1());

            int result = comida.CalculaCalorias();

            Assert.Equal(450, result);
        }

        [Fact]
        public void CalculaCalorias_WithTwoElements_Should()
        {
            var comida = FixtureTests.GetEmptyComida();
            comida.AddIngrediente(FixtureTests.GetIngrediente_WithTwoAlimento1());
            comida.AddIngrediente(FixtureTests.GetIngrediente_WithOneAlimento2());
            
            int result = comida.CalculaCalorias();

            Assert.Equal(400, result);
        }

        [Fact]
        public void ExistsAlimento_WrongAlimento_ReturnFalse()
        {
        
            var comida = FixtureTests.GetEmptyComida();
            comida.AddIngrediente(FixtureTests.GetIngrediente_WithOneAlimento1());
            var alimento = new Alimento("alimento3", 300, GrupoAlimenticio.Fruta);
        
            bool result = comida.ExistsAlimento(alimento);

            Assert.False(result, $"The result should be False. Actual result: {result}");
        }

        [Fact]
        public void ExistsGrupoAlimenticio_NotInComidaInstance_ReturnFalse_Should()
        {
            var comida = FixtureTests.GetEmptyComida();
            comida.AddIngrediente(FixtureTests.GetIngrediente_WithOneAlimento1());

            bool result = comida.ExistsGrupoAlimenticio(GrupoAlimenticio.Carne);

            Assert.False(result, $"The result should be False. Actual result: {result}");
        }
    }
}