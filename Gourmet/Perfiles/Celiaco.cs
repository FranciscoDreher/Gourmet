using System;
using System.Linq;

namespace Gourmet
{
    public class Celiaco : IPerfil
    {
        public bool EsApto(Comida comida)
        {
            bool existeCereal = comida.ComidaIngredientes.Any(ci => ci.Ingrediente.Alimento.BelongsToGrupoAlimenticio(GrupoAlimenticio.Cereal));

            return !existeCereal;
        }
        
    }
}