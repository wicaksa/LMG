using LMG.DAT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMG.DAT.Interfaces
{
    public interface IGenericRepository<TDataContextObject> where TDataContextObject : DataContextBase
    {
        // Delete data
        Task Delete(int id);

        // Get data
        Task<ICollection<TDataContextObject>> GetAllAsync(int skip, int take);
        Task<TDataContextObject> GetByIdAsync(int id);

        // Inserting data
        void Insert(TDataContextObject dataContextObject);
        Task InsertCollection(IEnumerable<TDataContextObject> dataContextObjects);

        // Update data
        //Task UpdateById(TDataContextObject dataContextObject);
        TDataContextObject Update(TDataContextObject dataContextObject);

        // Save
        Task SaveRepoAsync();
    }
}
