using System;
using System.Collections.Generic;
using System.Linq;

namespace Gourmet
{
    public class RankingComidas
    {
        private List<RegistroRanking> registros;

        public List<RegistroRanking> Resgistros
        {
            private set { registros = value; }
            get { return registros; }
        }
        
        public RankingComidas()
        {
            registros = new List<RegistroRanking>();
        }


        public RankingComidas(List<RegistroRanking> registros)
        {
            this.registros = registros;
        }

        public void AddComidaARanking(Comida comida)
        {
            var registro = Resgistros.FirstOrDefault(reg => reg.Comida.Nombre == comida.Nombre);

            if (registro != null)
            {   
                registro.AddPuntaje(10);
            }
            else
            {
                this.registros.Add(new RegistroRanking(comida, 10));
            }
        }
    }
}