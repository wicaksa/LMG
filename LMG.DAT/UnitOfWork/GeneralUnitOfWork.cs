using LMG.DAT.Interfaces;
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
    public class GeneralUnitOfWork : IGeneralUnitOfWork
    {
        private readonly IGenericRepository<DC_Book> _bookRepository;
        private readonly IGenericRepository<DC_Author> _authorRepository;
        private readonly IGenericRepository<DC_BookAuthor> _bookAuthorRepository;

        public GeneralUnitOfWork(IGenericRepository<DC_Book> bookRepository, IGenericRepository<DC_Author> authorRepository, IGenericRepository<DC_BookAuthor> bookAuthorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _bookAuthorRepository = bookAuthorRepository;
        }

        public async Task<DC_Author> GetAuthorById(int id)
        {
            var getAuthor = await _authorRepository.GetByIdAsync(id);
            return getAuthor;
        }

        public async Task<DC_BookAuthor> GetBookAuthorById(int id)
        {
            var getBookAuthor = await _bookAuthorRepository.GetByIdAsync(id);
            return getBookAuthor;
        }

        public async Task<DC_Book> GetBookById(int id)
        {
            var getBook = await _bookRepository.GetByIdAsync(id);
            return getBook;
        }
    }
}
