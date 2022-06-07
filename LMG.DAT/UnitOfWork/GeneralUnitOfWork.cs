using LMG.DAT.DataContext;
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

    }
    public class GeneralUnitOfWork : IGeneralUnitOfWork
    {
        private LMG_DbContext context = new LMG_DbContext();
        private GenericRepository<DC_Book> _bookRepository;
        private GenericRepository<DC_Author> _authorRepository;
        private GenericRepository<DC_BookAuthor> _bookAuthorRepository;

        /*public GeneralUnitOfWork(GenericRepository<DC_Book> bookRepository, GenericRepository<DC_Author> authorRepository, GenericRepository<DC_BookAuthor> bookAuthorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _bookAuthorRepository = bookAuthorRepository;
        } */

        public GenericRepository<DC_Book> BookRepository
        {
            get
            {

                if (this._bookRepository == null)
                {
                    this._bookRepository = new GenericRepository<DC_Book>(context);
                }
                return _bookRepository;
            }
        } 
        public GenericRepository<DC_Author> AuthorRepository
        {
            get
            {

                if (this._authorRepository == null)
                {
                    this._authorRepository = new GenericRepository<DC_Author>(context);
                }
                return _authorRepository;
            }
        } 
        public GenericRepository<DC_BookAuthor> BookAuthorRepository
        {
            get
            {

                if (this._bookAuthorRepository == null)
                {
                    this._bookAuthorRepository = new GenericRepository<DC_BookAuthor>(context);
                }
                return _bookAuthorRepository;
            }
        }

    }
}
