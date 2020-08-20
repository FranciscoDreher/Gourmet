using System;

namespace Gourmet
{
    public class RegistroRanking
    {
        private Comida comida;

        public Comida Comida
        {
            private set { comida = value; }
            get { return comida; }
        }

        private int puntaje;

        public int Puntaje
        {
            private set { puntaje = value; }
            get { return puntaje; }
        }

        public RegistroRanking()
        {
            comida = new Comida();
            puntaje = 0;
        }

        public RegistroRanking(Comida comida, int puntaje)
        {
            this.comida = comida;
            this.puntaje = puntaje;
        }

        public void AddPuntaje(int puntaje)
        {
            if (puntaje < 0)
            {
                throw new ArgumentOutOfRangeException("puntaje deberia ser mayor a 0.");
            }

            this.puntaje += puntaje;
        }
    }
}