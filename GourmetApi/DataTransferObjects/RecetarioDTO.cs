using System;
using System.Linq;
using System.Collections.Generic;
using Gourmet;

namespace GourmetApi.DTO
{
    public class RecetarioDTO
    {
        public int RecetarioId { get; set; }
        public string Titulo { get; set; }
        public List<ComidaDTO> Comidas { get; set; }
    }
}