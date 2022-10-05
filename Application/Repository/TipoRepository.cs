using Microsoft.EntityFrameworkCore;
using Persistencia;
using Persistencia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class TipoRepository
    {
        private readonly ApplicationContext _dbContext;

        public TipoRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task AddAsync(tipos pk)
        {
            await _dbContext.Set<tipos>().AddAsync(pk);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(tipos pk)
        {
            _dbContext.Entry(pk).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(tipos entity)
        {
            _dbContext.Set<tipos>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<tipos>> GetAllAsync()
        {
            return await _dbContext
                 .Set<tipos>()
                 .ToListAsync();
        }
        public async Task<tipos> GetByIdAsync(int id)
        {
            return await _dbContext
                 .Set<tipos>()
                 .FindAsync(id);
        }
    }
}