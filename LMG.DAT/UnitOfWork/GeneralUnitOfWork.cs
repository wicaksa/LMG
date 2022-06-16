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
        Interfaces.GenericRepository<DC_Book> BookRepository { get; }
        Interfaces.GenericRepository<DC_Author> AuthorRepository { get; }
        Interfaces.GenericRepository<DC_BookAuthor> BookAuthorRepository { get; }
    }
    public class GeneralUnitOfWork : IGeneralUnitOfWork
    {
        public Interfaces.GenericRepository<DC_Book> BookRepository { get; private set; }
        public Interfaces.GenericRepository<DC_Author> AuthorRepository { get; private set; }
        public Interfaces.GenericRepository<DC_BookAuthor> BookAuthorRepository { get; private set; }

        public GeneralUnitOfWork(Interfaces.GenericRepository<DC_Book> bookRepository, Interfaces.GenericRepository<DC_Author> authorRepository, Interfaces.GenericRepository<DC_BookAuthor> bookAuthorRepository)
        {
            BookRepository = bookRepository;
            AuthorRepository = authorRepository;
            BookAuthorRepository = bookAuthorRepository;
        } 

    }
}
