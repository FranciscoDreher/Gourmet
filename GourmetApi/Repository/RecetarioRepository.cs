using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Gourmet;
using GourmetApi.Extensions;

namespace GourmetApi.Repository
{
    public class RecetarioRepository : IRecetarioRepository
    {
        private readonly GourmetContext _context;

        public RecetarioRepository(GourmetContext context)
        {
            _context = context;
        }

        public async Task<List<Recetario>> FindAll()
        {
            return await _context.Recetarios.Include(x => x.RecetarioComidas)
                                        .ThenInclude(x => x.Comida)
                                        .ThenInclude(x => x.ComidaIngredientes)
                                        .ThenInclude(x => x.Ingrediente)
                                        .ThenInclude(x => x.Alimento)
                                        .ToListAsync();
        }
        public async Task<Recetario> FindById(int id)
        {
            var recetario = await _context.Recetarios.Include(x => x.RecetarioComidas)
                                        .ThenInclude(x => x.Comida)
                                        .ThenInclude(x => x.ComidaIngredientes)
                                        .ThenInclude(x => x.Ingrediente)
                                        .ThenInclude(x => x.Alimento)
                                        .FirstOrDefaultAsync(p => p.RecetarioId == id);
            if(recetario == null)
            {
                return null;
            }
            
            return recetario;
        }
        public async Task<Recetario> Create(Recetario entity)
        {
            _context.Recetarios.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        public async Task<Recetario> Update(int id, Recetario entity)
        {
            var recetario = await _context.Recetarios.FindAsync(id);
            recetario.SetTitulo(entity.Titulo);
            _context.Entry(recetario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
            return recetario;
        }
        public async Task<Recetario> Delete(int id)
        {
            var entity = await _context.Recetarios.FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            _context.Recetarios.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<List<Comida>> GetComidasDelRecetario(int id)
        {
            return await _context.RecetarioComidas.Where(rc => rc.RecetarioId == id)
                                                .Include(x => x.Comida)
                                                .ThenInclude(x => x.ComidaIngredientes)
                                                .ThenInclude(x => x.Ingrediente)
                                                .ThenInclude(x => x.Alimento)
                                                .Select(rc => rc.Comida)
                                                .ToListAsync();
        }
    }
}