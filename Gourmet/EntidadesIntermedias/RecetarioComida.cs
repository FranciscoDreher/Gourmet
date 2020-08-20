using System;

namespace Gourmet
{
    public class RecetarioComida
    {
        public int RecetarioId { get; set; }
        public Recetario Recetario { get; set; }

        public int ComidaId { get; set; }
        public Comida Comida { get; set; }

        public RecetarioComida()
        {

        }

        public RecetarioComida(Recetario recetario, Comida comida)
        {
            this.Recetario = recetario;
            this.Comida = comida;
        }
    }
}