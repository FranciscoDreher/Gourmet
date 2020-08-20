using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gourmet
{
    public class Alimento
    {
        [Key]
        public int AlimentoId { get; set; }

        private string nombre;

        public string Nombre
        {
            private set { nombre = value; }
            get { return nombre; }
        }

        private int calorias;

        public int Calorias 
        {
            private set { calorias = value; }
            get { return calorias; }
        }

        private GrupoAlimenticio grupoAlim;

        public GrupoAlimenticio GrupoAlim
        {
            private set { grupoAlim = value; }
            get { return grupoAlim; }
        }

        public List<Ingrediente> Ingredientes { get; set; }

        public Alimento()
        {
            nombre = String.Empty;
            calorias = 0;
        }

        public Alimento(string nombre, int calorias, GrupoAlimenticio grupoAlim)
        {
            this.nombre = nombre;
            this.calorias = calorias;
            this.grupoAlim = grupoAlim;
        }

        public void SetNombre(String nombre = "")
        {
            this.nombre = nombre;
        }

        public void SetCalorias(int calorias)
        {
            this.calorias = calorias;
        }

        public void SetGrupoAlimenticio(GrupoAlimenticio grupoAlimenticio)
        {
            this.grupoAlim = grupoAlimenticio;
        }

        public bool BelongsToGrupoAlimenticio(GrupoAlimenticio grupo)
        {
            return this.grupoAlim == grupo;
        }
    }
}