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

        // DELETE
        public async Task Delete(int id)
        {
            // Get the object by id
            var objToUpdate = await GetByIdAsync(id);
            // Remove the object --> Make sure to check for null value in LMGControllerBase
            Context.Set<TDataContextObject>().Remove(objToUpdate);
            // Save changes
            SaveRepoAsync();
        }

        public async Task<ICollection<TDataContextObject>> GetAllAsync(int skip, int take)
        {
            return await Context.Set<TDataContextObject>().Skip(skip).Take(take).ToListAsync();
        }

        public async Task<TDataContextObject> GetByIdAsync(int id)
        {
            return await Context.Set<TDataContextObject>().FindAsync(id);
        }

        public async Task<ICollection<TDataContextObject>> Insert(TDataContextObject obj)
        {
            Context.Add(obj);
            await SaveRepoAsync();
            return await Context.Set<TDataContextObject>().ToListAsync();
        }

        public Task InsertCollection()
        {
            throw new NotImplementedException();
        }

        // SAVE 
        public async Task SaveRepoAsync()
        { 
            await Context.SaveChangesAsync();
        }

        // UPDATE
        public async Task UpdateById(int id)
        {
            // Get the object by id
            // var objToUpdate = await GetByIdAsync(id);
            // Update the object
            // Context.Set<TDataContextObject>().Update(objToUpdate);

            var objToUpdate = await GetByIdAsync(id);

            Context.Set<TDataContextObject>().Attach(objToUpdate);
            Context.Entry(objToUpdate).State = EntityState.Modified;
            // Save changes

            await SaveRepoAsync();
        }
    }
}
