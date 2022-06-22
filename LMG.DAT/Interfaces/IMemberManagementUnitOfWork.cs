using LMG.BLL.Models;
using LMG.DAT.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMG.DAT.Interfaces
{
    public interface IMemberManagementUnitOfWork
    {
        Task<ICollection<BookModel>> GetAvailableBooks();
        Task<ICollection<BookModel>> GetUnavailableBooks();
        Task BorrowBook(int bookId, int memberId);
        Task ReturnBook(int borrowId);
        Task ReserveBook(int bookId, int memberId);
        Task<ICollection<BookModel>> searchByTitle(string title);
        Task<ICollection<BookModel>> searchByAuthor(string author);

    }
}
