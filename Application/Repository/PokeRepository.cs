using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using Persistencia.Models;

namespace Application.Repository
{
    public class PokeRepository
    {

        private readonly ApplicationContext _dbContext;

        public PokeRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task AddAsync(Pokemons pk)
        {
            await _dbContext.Set<Pokemons>().AddAsync(pk);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pokemons pk)
        {
            _dbContext.Entry(pk).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Pokemons entity)
        {
            _dbContext.Set<Pokemons>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Pokemons>> GetAllAsync()
        {
            return await _dbContext
                 .Set<Pokemons>()
                 .ToListAsync();
        }
        public async Task<Pokemons> GetByIdAsync(int id)
        {
            return await _dbContext
                 .Set<Pokemons>()
                 .FindAsync(id);
        }
    }
}
