using System;
using System.Linq;

namespace Gourmet
{
    public class Carnivoro : IPerfil
    {
        public bool EsApto(Comida comida)
        {
            bool existeCarne = comida.ComidaIngredientes.Any(ci => ci.Ingrediente.Alimento.BelongsToGrupoAlimenticio(GrupoAlimenticio.Carne));
            var calorias = comida.CalculaCalorias();

            return (existeCarne && (calorias >= 200));
        }
    }
}