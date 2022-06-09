using LMG.DAT.DataContext;
using LMG.DAT.Interfaces;
using LMG.DAT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMG.DAT.Repositories
{
    public class GenericRepository<TDataContextObject> : IGenericRepository<TDataContextObject> where TDataContextObject : DataContextBase
    {
        protected readonly LMG_DbContext Context;
        public GenericRepository(LMG_DbContext context)
        {
            Context = context;
        }

        public async Task Delete(int id)
        {
            var objToUpdate = await GetByIdAsync(id);
            Context.Set<TDataContextObject>().Remove(objToUpdate);
        }

        public async Task<ICollection<TDataContextObject>> GetAllAsync(int skip, int take)
        {
            return await Context.Set<TDataContextObject>().Skip(skip).Take(take).ToListAsync();
        }

        public async Task<TDataContextObject> GetByIdAsync(int id)
        {
            return await Context.Set<TDataContextObject>().FindAsync(id);
        }

        public void Insert()
        {
 
            throw new NotImplementedException();
        }

        public Task InsertCollection()
        {
            throw new NotImplementedException();
        }

        public async Task SaveRepoAsync()
        {
            
            throw new NotImplementedException();
        }

        public async Task UpdateById()
        {
            throw new NotImplementedException();
        }
    }
}
