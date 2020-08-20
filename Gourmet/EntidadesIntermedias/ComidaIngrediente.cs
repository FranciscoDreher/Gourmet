using System;

namespace Gourmet
{
    public class ComidaIngrediente
    {
        public int IngredienteId { get; set; }
        public Ingrediente Ingrediente { get; set; }

        public int ComidaId { get; set; }
        public Comida Comida { get; set; }

        public ComidaIngrediente()
        {

        }

        public ComidaIngrediente(Comida comida, Ingrediente ingrediente)
        {
            this.Comida = comida;
            this.Ingrediente = ingrediente;
        }
    }
}