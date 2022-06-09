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
        // Get data
        Task<ICollection<TDataContextObject>> GetAllAsync(int skip, int take);
        Task<TDataContextObject> GetByIdAsync(int id);

        // Inserting data
        void Insert();
        Task InsertCollection();

        // Update data
        Task UpdateById();
        
        // Delete data
        Task Delete(int id);

        // Save
        Task SaveRepoAsync();
    }
}
