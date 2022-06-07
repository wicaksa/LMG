using LMG.DAT.DataContext;
using LMG.DAT.Interfaces;
using LMG.DAT.Models.Author;
using LMG.DAT.Models.Book;
using LMG.DAT.Models.BookAuthor;
using LMG.DAT.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMG.DAT.UnitOfWork
{
    public interface IGeneralUnitOfWork
    {
        IGenericRepository<DC_Book> BookRepository { get; }
        IGenericRepository<DC_Author> AuthorRepository { get; }
        IGenericRepository<DC_BookAuthor> BookAuthorRepository { get; }
    }
    public class GeneralUnitOfWork : IGeneralUnitOfWork
    {
        public IGenericRepository<DC_Book> BookRepository { get; private set; }
        public IGenericRepository<DC_Author> AuthorRepository { get; private set; }
        public IGenericRepository<DC_BookAuthor> BookAuthorRepository { get; private set; }

        public GeneralUnitOfWork(IGenericRepository<DC_Book> bookRepository, IGenericRepository<DC_Author> authorRepository, IGenericRepository<DC_BookAuthor> bookAuthorRepository)
        {
            BookRepository = bookRepository;
            AuthorRepository = authorRepository;
            BookAuthorRepository = bookAuthorRepository;
        } 

    }
}
