using System;

namespace Gourmet
{
    public interface IAccion
    {
        bool Activa
        {
            get;
            set;
        }

        void EjecutarAccion(Comida comida, Recetario recetario);

        void Activar();

        void Desactivar();
    }
}