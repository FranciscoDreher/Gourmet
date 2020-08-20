using System;
using Gourmet;

namespace Gourmet.Tests
{
    public class FixtureTests
    {
        public static Alimento alimento1 = new Alimento("alimento1", 150, GrupoAlimenticio.Lacteo);
        public static Alimento alimento2 = new Alimento("alimento2", 100, GrupoAlimenticio.Carne);
        public static Alimento celiaco1 = new Alimento("celiaco", 100, GrupoAlimenticio.Lacteo);
        public static Alimento vegetariano1 = new Alimento("vegetariano", 50, GrupoAlimenticio.Fruta);
        public static Alimento vegano1 = new Alimento("vegano", 75, GrupoAlimenticio.Vegetal);
        public static Alimento carnivoro1 = new Alimento("carnivoro1", 275, GrupoAlimenticio.Carne);
        public static Alimento carnivoro2 = new Alimento("carnivoro2", 150, GrupoAlimenticio.Carne);
        public static Alimento cereal = new Alimento("celiaco", 100, GrupoAlimenticio.Cereal);

        public static Recetario GetEmptyRecetario()
        {
            return new Recetario();
        }

        public static Comida GetEmptyComida()
        {
            return new Comida();
        }

        public static Ingrediente GetIngrediente_WithTwoAlimento1()
        {   
            return new Ingrediente(alimento1, 2, UnidadDeMedida.Cucharadas);
        }

        public static Ingrediente GetIngrediente_WithOneAlimento1()
        {   
            return new Ingrediente(alimento1, 1, UnidadDeMedida.Gramos);
        }

        public static Ingrediente GetIngrediente_WithOneAlimento2()
        {   
            return new Ingrediente(alimento2, 1, UnidadDeMedida.Litros);
        }

        public static Ingrediente GetIngrediente_Celiaco()
        {   
            return new Ingrediente(celiaco1, 1, UnidadDeMedida.Gramos);
        }

        public static Ingrediente GetIngrediente_Vegetariano()
        {   
            return new Ingrediente(vegetariano1, 1, UnidadDeMedida.Cucharadas);
        }

        public static Ingrediente GetIngrediente_Vegano()
        {   
            return new Ingrediente(vegano1, 1, UnidadDeMedida.Gramos);
        }

        public static Ingrediente GetIngrediente_Carnivoro()
        {   
            return new Ingrediente(carnivoro1, 1, UnidadDeMedida.Unidades);
        }

        public static Ingrediente GetIngrediente_Carnivoro_CaloriasMenorA200()
        {   
            return new Ingrediente(carnivoro2, 1, UnidadDeMedida.Gramos);
        }

        public static Ingrediente GetIngrediente_ConCereal()
        {   
            return new Ingrediente(cereal, 1, UnidadDeMedida.Cucharadas);
        }

        public static Comensal GetComensalCarnivoro()
        {
            return new Comensal("Comensal", new Carnivoro());
        }

        public static Comensal GetComensalCeliaco()
        {
            return new Comensal("Comensal", new Celiaco());
        }

        public static Comensal GetComensalVegano()
        {
            return new Comensal("Comensal", new Vegano());
        }

        public static Comensal GetComensalVegetariano()
        {
            return new Comensal("Comensal", new Vegetariano());
        }

        public static Comida GetComida_WithIngredientes()
        {
            var comida = new Comida();
            comida.AddIngrediente(GetIngrediente_Vegetariano());
            comida.AddIngrediente(GetIngrediente_WithOneAlimento2());

            return comida;
        }
    }
}