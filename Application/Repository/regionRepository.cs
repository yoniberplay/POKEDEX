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
    public class regionRepository { 

            private readonly ApplicationContext _dbContext;

    public regionRepository(ApplicationContext dbContext)
    {
        _dbContext = dbContext;

    }

    public async Task AddAsync(regions pk)
    {
        await _dbContext.Set<regions>().AddAsync(pk);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(regions pk)
    {
        _dbContext.Entry(pk).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(regions entity)
    {
        _dbContext.Set<regions>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<regions>> GetAllAsync()
    {
        return await _dbContext
             .Set<regions>()
             .ToListAsync();
    }
    public async Task<regions> GetByIdAsync(int id)
    {
        return await _dbContext
             .Set<regions>()
             .FindAsync(id);
    }
}
}