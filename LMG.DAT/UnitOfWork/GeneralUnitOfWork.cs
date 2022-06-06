using LMG.DAT.Interfaces;
using LMG.DAT.Models.Author;
using LMG.DAT.Models.Book;
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

        public GeneralUnitOfWork(IGenericRepository<DC_Book> bookRepository, IGenericRepository<DC_Author> authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        public async Task<AuthorBookObject> GetAuthorBook()
        {
            var getAuthor = await _authorRepository.GetByIdAsync(1);
            var getBook = await _bookRepository.GetByIdAsync(1);

            return new AuthorBookObject()
            {
                AuthorName = getAuthor.FirstName,
                BookName = getBook.Title
            };
        }
    }
}
