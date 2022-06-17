using AutoMapper;
using LMG.BLL.Models;
using LMG.DAT.Models.Book;
using LMG.DAT.Models.Borrow;
using LMG.DAT.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMG.BLL
{
    public class MemberManagementBLL
    {
        protected readonly IGeneralUnitOfWork _uow;
        private Mapper _Mapper;

        public MemberManagementBLL(IGeneralUnitOfWork uow)
        {
            _uow = uow;
            var _config = new MapperConfiguration(cfg => cfg.CreateMap<DC_Book, BookModel>().ReverseMap());
            _Mapper = new Mapper(_config);
        }

        public async Task<ICollection<BookModel>> GetAvailableBooks()
        {
            ICollection<DC_Book> books = await _uow.BookRepository.GetAllAsync(0, 5);
            var list = books.ToList();
            ICollection<DC_Book> availableBooks = new Collection<DC_Book>();
            foreach (var book in list)
            {
                if(book.Copies > 0)
                {
                    availableBooks.Add(book);
                }
            }
            ICollection<BookModel> model = _Mapper.Map<ICollection<DC_Book>, ICollection<BookModel>>(availableBooks);
            return model;
        }

        public async Task<ICollection<BookModel>> GetUnavailableBooks()
        {
            ICollection<DC_Book> books = await _uow.BookRepository.GetAllAsync(0, 5);
            var list = books.ToList();
            ICollection<DC_Book> unavailableBooks = new Collection<DC_Book>();
            foreach (var book in list)
            {
                if (book.Copies <= 0)
                {
                    unavailableBooks.Add(book);
                }
            }
            ICollection<BookModel> model = _Mapper.Map<ICollection<DC_Book>, ICollection<BookModel>>(unavailableBooks);
            return model;
        }

        public async Task BorrowBook(int id)
        {
            DC_Book book = await _uow.BookRepository.GetByIdAsync(id);
            if(book.Copies > 0)
            {
                book.Copies--;
                _uow.BookRepository.Update(book);
                await _uow.BookRepository.SaveRepoAsync();
                DC_Borrow newEntry = new DC_Borrow
                {
                    BookId = id,
                    MemberId = 1,
                    BorrowDate = DateTime.UtcNow,
                    ReturnDate = null,
                    Status = "Good"
                };
                _uow.BorrowRepository.Insert(newEntry);
                await _uow.BorrowRepository.SaveRepoAsync();
            }
            else
            {
                throw new Exception("Cannot borrow this book. There is not enough copies.");
            }
        }

        public async Task ReturnBook(int id)
        {
            DC_Book book = await _uow.BookRepository.GetByIdAsync(id);
            book.Copies++;
            _uow.BookRepository.Update(book);
            await _uow.BookRepository.SaveRepoAsync();
        }
    }
}
