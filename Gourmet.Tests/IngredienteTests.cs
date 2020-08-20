using System;
using Xunit;
using Gourmet;

namespace Gourmet.Tests
{
    public class IngredienteTests
    {
        private Ingrediente ingrediente = new Ingrediente();
        private Alimento alimento = new Alimento("Manzana", 150, GrupoAlimenticio.Fruta);

        [Fact]
        public void CalculaCalorias_DefaultAlimento_Should()
        {
            int result = ingrediente.CalculaCalorias();

            Assert.Equal(0, result);
        }

        [Fact]
        public void CalculaCalorias_OneElement_Should()
        {
            var ingrediente1 = new Ingrediente(alimento, 2, UnidadDeMedida.Cucharadas);
            
            int result = ingrediente1.CalculaCalorias();

            Assert.Equal(300, result);
        }
    }
}