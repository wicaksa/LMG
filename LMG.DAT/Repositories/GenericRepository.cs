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
        }

        // GET ALL
        public async Task<ICollection<TDataContextObject>> GetAllAsync(int skip, int take)
        {
            return await Context.Set<TDataContextObject>().Skip(skip).Take(take).ToListAsync();
        }

        // GET BY ID
        public async Task<TDataContextObject> GetByIdAsync(int id)
        {
            return await Context.Set<TDataContextObject>().FindAsync(id);
        }

        // INSERT
        public void Insert(TDataContextObject dataContextObject)
        {
            dataContextObject.CreatedAt = DateTime.UtcNow;
            dataContextObject.CreatedBy = typeof(TDataContextObject).Name;
            dataContextObject.ModifiedBy = typeof(TDataContextObject).Name;
            dataContextObject.ModifiedAt = DateTime.UtcNow;

            Context.Set<TDataContextObject>().Add(dataContextObject);

        }

        // INSERT COLLECTION
        public async Task InsertCollection(IEnumerable<TDataContextObject> dataContextObjects)
        {
            foreach (var obj in dataContextObjects)
            {
                obj.CreatedAt = DateTime.UtcNow;
                obj.CreatedBy = typeof(TDataContextObject).Name;
                obj.ModifiedBy = typeof(TDataContextObject).Name;
                obj.ModifiedAt = DateTime.UtcNow;
            }

            await Context.Set<TDataContextObject>().AddRangeAsync(dataContextObjects);

        }

        // UPDATE
        public async void UpdateById(TDataContextObject dataContextObject)
        {
            var objToUpdate = await GetByIdAsync(dataContextObject.Id);
            objToUpdate.ModifiedAt = DateTime.UtcNow;
            objToUpdate.ModifiedBy = typeof(TDataContextObject).Name;

            Context.Set<TDataContextObject>().Attach(objToUpdate);
            Context.Entry(objToUpdate).State = EntityState.Modified;
        }

        // SAVE 
        public async Task SaveRepoAsync()
        {
            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateException uxe)
            {

            }
        }
    }
}
