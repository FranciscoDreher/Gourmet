using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gourmet
{
    public class Recetario
    {
        [Key]
        public int RecetarioId { get; set; }

        private string titulo;

        public string Titulo 
        {
            private set { titulo = value; }
            get { return titulo; }
        } 

        public List<RecetarioComida> RecetarioComidas { get; set; }

        private List<IAccion> acciones;

        [NotMapped]
        public List<IAccion> Acciones
        {
            private set { acciones = value; }
            get { return acciones; }
        }

        public Recetario()
        {
            RecetarioComidas = new List<RecetarioComida>();
            titulo = String.Empty;
            acciones = new List<IAccion>();
        }

        public Recetario(string titulo)
        {
            RecetarioComidas = new List<RecetarioComida>();
            this.titulo = titulo;
            acciones = new List<IAccion>();
        }

        public Recetario(List<RecetarioComida> recetarioComidas, string titulo)
        {
            this.RecetarioComidas = recetarioComidas;
            this.titulo = titulo;
            this.acciones = new List<IAccion>();
        }

        public void SetTitulo(string titulo = "")
        {
            this.titulo = titulo;
        }

        public void AddComida(Comida comida)
        {
            var existeComida = RecetarioComidas.Any(rc => rc.Comida.Nombre == comida.Nombre);

            if(!existeComida)
            {
                var newRecetarioComida = new RecetarioComida(this, comida);
                this.RecetarioComidas.Add(newRecetarioComida);
                comida.RecetarioComidas.Add(newRecetarioComida);

                EjecutarAcciones(comida);
            }
        }

        public void SuscribirAccion(IAccion accion)
        {
            this.acciones.Add(accion);
        }

        public void DesuscribirAccion(IAccion accion)
        {
            this.acciones.Remove(accion);
        }

        private void EjecutarAcciones(Comida comida)
        {
            foreach (var accion in acciones)
            {
                if(accion.Activa)
                {
                    accion.EjecutarAccion(comida, this);
                }
            }
        }
    }
}