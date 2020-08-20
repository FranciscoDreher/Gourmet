using System;
using System.Linq;

namespace Gourmet
{
    public class Vegano : IPerfil
    {
        public bool EsApto(Comida comida)
        {
            bool existeCarne = comida.ComidaIngredientes.Any(ci => ci.Ingrediente.Alimento.BelongsToGrupoAlimenticio(GrupoAlimenticio.Carne));
            bool existeLacteo = comida.ComidaIngredientes.Any(ci => ci.Ingrediente.Alimento.BelongsToGrupoAlimenticio(GrupoAlimenticio.Lacteo));

            return !(existeCarne || existeLacteo);
        }
    }
}