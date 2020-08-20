using System;
using Xunit;
using Gourmet;
using Moq;
using System.Linq;

namespace Gourmet.Tests
{
    public class ActualizadorRankingComidasTests
    {
        [Fact]
        public void EjecutarAccion_AddsElementToList_ShouldIncrementPuntaje()
        {
            var ranking = new RankingComidas();
            var actualizadorRanking = new ActualizadorRankingComidas(ranking);
            var comida = new Comida();
            var recetario = FixtureTests.GetEmptyRecetario();
            comida.AddIngrediente(FixtureTests.GetIngrediente_Carnivoro());
            actualizadorRanking.EjecutarAccion(comida, recetario);

            actualizadorRanking.EjecutarAccion(comida, recetario);
            var registo = ranking.Resgistros.First();
            var puntaje = registo.Puntaje;

            Assert.Equal(20, puntaje);
        }

        [Fact]
        public void EjecutarAccion_AddsElementToListWhenActivaIsFalse_ShouldNotIncrementPuntaje()
        {
            var ranking = new RankingComidas();
            var actualizadorRanking = new ActualizadorRankingComidas(ranking);
            var comida = new Comida();
            var recetario = FixtureTests.GetEmptyRecetario();
            comida.AddIngrediente(FixtureTests.GetIngrediente_Carnivoro());
            actualizadorRanking.EjecutarAccion(comida, recetario);
            actualizadorRanking.Desactivar();

            actualizadorRanking.EjecutarAccion(comida, recetario);
            var registo = ranking.Resgistros.First();
            var puntaje = registo.Puntaje;

            Assert.Equal(10, puntaje);
        }
    }
}