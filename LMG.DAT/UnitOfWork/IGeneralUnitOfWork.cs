using LMG.DAT.Models.Author;
using LMG.DAT.Models.Book;
using LMG.DAT.Models.BookAuthor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMG.DAT.UnitOfWork
{
    public interface IGeneralUnitOfWork
    {
        Task<DC_Book> GetBookById(int id);
        Task<DC_Author> GetAuthorById(int id);
        Task<DC_BookAuthor> GetBookAuthorById(int id);
    }
}
