using System;
using System.Linq;

namespace Gourmet
{
    public class Vegetariano : IPerfil
    {
        public bool EsApto(Comida comida)
        {
            bool existeCarne = comida.ComidaIngredientes.Any(ci => ci.Ingrediente.Alimento.BelongsToGrupoAlimenticio(GrupoAlimenticio.Carne));

            return !existeCarne;
        }
    }
}