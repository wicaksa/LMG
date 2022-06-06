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
        void Insert();
        Task InsertCollection();
        Task UpdateById();
        Task<ICollection<TDataContextObject>> GetAllAsync(int skip, int take);
        Task<TDataContextObject> GetByIdAsync(int id);
        Task Delete(int id);
        Task SaveRepoAsync();
    }
}
