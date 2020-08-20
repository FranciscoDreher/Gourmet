using System;
using System.Linq;
using System.Collections.Generic;

namespace GourmetApi.DTO
{
    public class ComidaDTO
    {
        public int ComidaId { get; set; }
        public string Nombre { get; set; }
        public List<IngredienteDTO> Ingredientes { get; set; }
    }
}