using AutoMapper;
using LMG.DAT.Models;
using LMG.DAT.Models.Author;
using LMG.DAT.Models.Book;
using LMG.DAT.Models.BookAuthor;
using LMG.DAT.Models.Borrow;
using LMG.DAT.Models.Member;
using LMG.DAT.Models.Reservation;
using LMG.DAT.Models.Review;
using LMG.DAT.Models.Series;

namespace LMG.DAT.Interfaces
{
    public interface IGeneralUnitOfWork<TDataModel, TDataContext> where TDataContext : DataContextBase
    {
        Task<ICollection<TDataModel>> GetAll();
        Task<TDataModel> GetById(int id);
        void Insert(TDataModel model);
        Task Delete(int id);
        Task InsertCollection(IEnumerable<TDataModel> models);
        Task Update(int id, TDataModel model);
    }
}
