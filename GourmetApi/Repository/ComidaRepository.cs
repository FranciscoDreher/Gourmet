using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Gourmet;
using GourmetApi.Extensions;

namespace GourmetApi.Repository
{
    public class ComidaRepository : IRepository<Comida>
    {
        private readonly GourmetContext _context;

        public ComidaRepository(GourmetContext context)
        {
            _context = context;
        }

        public async Task<List<Comida>> FindAll()
        {
            return await _context.Comidas.Include(x => x.ComidaIngredientes)
                                            .ThenInclude(x => x.Ingrediente)
                                            .ThenInclude(x => x.Alimento)
                                            .ToListAsync();
        }

        public async Task<Comida> FindById(int id)
        {
            var comida = await _context.Comidas.Include(x => x.ComidaIngredientes)
                                            .ThenInclude(x => x.Ingrediente)
                                            .ThenInclude(x => x.Alimento)
                                            .FirstOrDefaultAsync(p => p.ComidaId == id);
            if(comida == null)
            {
                return null;
            }
            
            return comida;
        }

        public async Task<Comida> Create(Comida entity)
        {
            _context.Comidas.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Comida> Update(int id, Comida entity)
        {
            var comida = await _context.Comidas.FindAsync(id);
            comida.SetNombre(entity.Nombre);
            _context.Entry(comida).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
            return comida;
        }

        public async Task<Comida> Delete(int id)
        {
            var entity = await _context.Comidas.FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            _context.Comidas.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}