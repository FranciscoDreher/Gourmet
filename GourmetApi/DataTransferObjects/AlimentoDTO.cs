using System;
using Gourmet;

namespace GourmetApi.DTO
{
    public class AlimentoDTO
    {
        public int AlimentoId { get; set; }
        public string Nombre { get; set; }
        public int Calorias { get; set; }
        public GrupoAlimenticio GrupoAlimenticio { get; set; }
    }
}