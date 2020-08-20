using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gourmet
{
    public class Comida
    {
        [Key]
        public int ComidaId { get; set; }

        private string nombre;

        public string Nombre
        {
            private set { nombre = value; }
            get { return nombre; }
        }

        public List<RecetarioComida> RecetarioComidas { get; set; }
        public List<ComidaIngrediente> ComidaIngredientes { get; set; }

        public Comida()
        {
            nombre = String.Empty;
            ComidaIngredientes = new List<ComidaIngrediente>();
            RecetarioComidas = new List<RecetarioComida>();
        }

        public Comida(string nombre)
        {
            this.nombre = nombre;
            ComidaIngredientes = new List<ComidaIngrediente>();
            RecetarioComidas = new List<RecetarioComida>();
        }

        public Comida(List<ComidaIngrediente> comidaIngredientes, List<RecetarioComida> recetarioComidas, string nombre)
        {
            RecetarioComidas = recetarioComidas;
            ComidaIngredientes = comidaIngredientes;
            this.nombre = nombre;
        }

        public void SetNombre(String nombre = "")
        {
            this.nombre = nombre;
        }

        public void AddAlimento(Alimento alimento, int cantidad, UnidadDeMedida unidadDeMedida)
        {
            var comIngrediente = ComidaIngredientes.FirstOrDefault(ci => ci.Ingrediente.Alimento == alimento);
            
            if (comIngrediente != null)
            {
                comIngrediente.Ingrediente.AddCantidad(cantidad);
            }
            else
            {
                var newIngrediente = new Ingrediente(alimento, cantidad, unidadDeMedida);
                var newComidaIngrediente = new ComidaIngrediente(this, newIngrediente);
                newIngrediente.ComidaIngredientes.Add(newComidaIngrediente);

                ComidaIngredientes.Add(newComidaIngrediente);
            }
        }

        public void AddIngrediente(Ingrediente nuevoIngrediente)
        {
            var comIngrediente = ComidaIngredientes.FirstOrDefault(ci => ci.Ingrediente.Alimento == nuevoIngrediente.Alimento);

            if (comIngrediente != null)
            {
                comIngrediente.Ingrediente.AddCantidad(nuevoIngrediente.Cantidad);
            }
            else
            {
                var newComidaIngrediente = new ComidaIngrediente(this, nuevoIngrediente);
                nuevoIngrediente.ComidaIngredientes.Add(newComidaIngrediente);

                ComidaIngredientes.Add(newComidaIngrediente);
            }
        }

        public int CalculaCalorias()
        {
            var calorias = ComidaIngredientes.Select(ci => ci.Ingrediente.CalculaCalorias()).Sum();
            
            return calorias;
        }

        public bool ExistsAlimento(Alimento alimento)
        {
            bool existeAlimento = ComidaIngredientes.Any(ci => ci.Ingrediente.Alimento.Nombre == alimento.Nombre);

            return existeAlimento;
        }

        public bool ExistsGrupoAlimenticio(GrupoAlimenticio grupoAlimenticio)
        {
            return ComidaIngredientes.Any(ci => ci.Ingrediente.Alimento.BelongsToGrupoAlimenticio(grupoAlimenticio));
        }
    }
}