using System;
using System.Collections.Generic;
using System.Linq;
using Gourmet;
using GourmetApi.DTO;

namespace GourmetApi.Extensions
{
    public static class Extensions
    {
        public static RecetarioDTO ConvertToDTO(this Recetario recetario) =>
            new RecetarioDTO
            {
                RecetarioId = recetario.RecetarioId,
                Titulo = recetario.Titulo,
                Comidas = recetario.RecetarioComidas.Select(rc => rc.Comida.ConvertToDTO()).ToList(),
            }; 
        
        public static ComidaDTO ConvertToDTO(this Comida comida) =>
            new ComidaDTO
            {
                ComidaId = comida.ComidaId,
                Nombre = comida.Nombre,
                Ingredientes = comida.ComidaIngredientes.Where(ci => ci.ComidaId == comida.ComidaId).Select(ci => ci.Ingrediente.ConvertToDTO()).ToList(),
            }; 

        public static IngredienteDTO ConvertToDTO(this Ingrediente ingrediente) =>
            new IngredienteDTO
            {
                IngredienteId = ingrediente.IngredienteId,
                Cantidad = ingrediente.Cantidad,
                UnidadDeMedida = ingrediente.UnidadDeMedida,
                Alimento = ingrediente.Alimento.ConvertToDTO(),
            };

        public static AlimentoDTO ConvertToDTO(this Alimento alimento) =>
            new AlimentoDTO
            {
                AlimentoId = alimento.AlimentoId,
                Nombre = alimento.Nombre,
                Calorias = alimento.Calorias,
                GrupoAlimenticio = alimento.GrupoAlim
            };
    }
}