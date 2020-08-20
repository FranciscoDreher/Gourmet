using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gourmet
{
    public class Ingrediente
    {
        [Key]
        public int IngredienteId { get; set; }

        private Alimento alimento;

        public int AlimentoId { get; set; }
        public Alimento Alimento
        {
            private set { alimento = value; }
            get { return alimento; }
        }

        private int cantidad;

        public int Cantidad
        {
            
            private set { cantidad = value; }
            get { return cantidad; }
        }

        private UnidadDeMedida unidadDeMedida;

        public UnidadDeMedida UnidadDeMedida
        {
            private set { unidadDeMedida = value; }
            get { return unidadDeMedida; }
        }

        public List<ComidaIngrediente> ComidaIngredientes { get; set; }

        public Ingrediente()
        {
            this.alimento = new Alimento();
            ComidaIngredientes = new List<ComidaIngrediente>();
            this.cantidad = 0;
        }

        public Ingrediente(Alimento alimento, int cantidad, UnidadDeMedida unidadDeMedida)
        {
            this.alimento = alimento;
            this.cantidad = cantidad;
            this.unidadDeMedida = unidadDeMedida;
            this.ComidaIngredientes = new List<ComidaIngrediente>();
        }

        public Ingrediente(Alimento alimento, int cantidad, UnidadDeMedida unidadDeMedida, List<ComidaIngrediente> comidaIngredientes)
        {
            this.alimento = alimento;
            this.cantidad = cantidad;
            this.unidadDeMedida = unidadDeMedida;
            ComidaIngredientes = comidaIngredientes;
        }

        public void SetAlimento(Alimento alimento)
        {
            this.alimento = alimento;
        }

        public void SetUnidadDeMedida(UnidadDeMedida unidadDeMedida)
        {
            this.unidadDeMedida = unidadDeMedida;
        }

        public void AddCantidad(int cantidadAgregada = 0)
        {
            if (cantidadAgregada < 0)
            {
                throw new ArgumentOutOfRangeException("Value should be equal or greater than 0.");
            }

            this.cantidad += cantidadAgregada;
        }

        public int CalculaCalorias()
        {
            return this.alimento.Calorias * this.cantidad;
        }
    }
}