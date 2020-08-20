using System;
using System.Collections.Generic;
using System.Linq;

namespace Gourmet
{
    public class ActualizadorRankingComidas : IAccion
    {
        private RankingComidas rankingComidas;

        public RankingComidas RankingComidas
        {
            private set { rankingComidas = value; }
            get { return rankingComidas; }
        }

        private bool activa;

        public bool Activa
        {
            set { activa = value; }
            get { return activa; }
        }

        public ActualizadorRankingComidas()
        {
            activa = true;
        }

        public ActualizadorRankingComidas(RankingComidas rankingComidas)
        {
            this.rankingComidas = rankingComidas;
            this.activa = true;
        }

        public void Activar()
        {
            this.activa = true;
        }

        public void Desactivar()
        {
            this.activa = false;
        }

        public void EjecutarAccion(Comida comida, Recetario recetario)
        {
            if(this.activa)
            {
                this.rankingComidas.AddComidaARanking(comida);
            }
        }
    }
}