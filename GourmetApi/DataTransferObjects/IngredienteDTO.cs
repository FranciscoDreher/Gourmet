using System;
using Gourmet;

namespace GourmetApi.DTO
{
    public class IngredienteDTO
    {
        public int IngredienteId { get; set; }
        public int Cantidad { get; set; }
        public UnidadDeMedida UnidadDeMedida { get; set; }
        public AlimentoDTO Alimento { get; set; }
    }
}