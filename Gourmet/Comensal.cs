using System;

namespace Gourmet
{
    public class Comensal
    {
        private IPerfil perfil;

        public IPerfil Perfil
        {
            private set { perfil = value; }
            get { return perfil; }
        }

        private string nombre;

        public string Nombre
        {
            private set { nombre = value; }
            get { return nombre; }
        }

        public Comensal()
        {
            this.nombre = String.Empty;
            this.perfil = null;
        }

        public Comensal(string nombre, IPerfil perfil)
        {
            this.nombre = nombre;
            this.perfil = perfil;
        }

        public bool EsApto(Comida comida)
        {
            return this.perfil.EsApto(comida);
        }
    }
}