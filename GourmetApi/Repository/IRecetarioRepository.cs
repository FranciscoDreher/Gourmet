using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gourmet;

namespace GourmetApi.Repository
{
    public interface IRecetarioRepository : IRepository<Recetario>
    {
        Task<List<Comida>> GetComidasDelRecetario(int id);
    }
}
