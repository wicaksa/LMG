using AutoMapper;
using LMG.BLL.Models;
using LMG.DAT.Models.Author;
using LMG.DAT.Models.Book;
using LMG.DAT.Models.BookAuthor;
using LMG.DAT.Models.Borrow;
using LMG.DAT.Models.Member;
using LMG.DAT.Models.Reservation;
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

        public async Task BorrowBook(int bookId, int memberId)
        {
            DC_Book book = await _uow.BookRepository.GetByIdAsync(bookId);
            DC_Member member = await _uow.MemberRepository.GetByIdAsync(memberId);

            if(book == null || member == null)
            {
                var message = string.Format("Book with id = {0} not found or invalid user", bookId);
                throw new Exception(message);
            }
            if(book.Copies > 0)
            {
                book.Copies--;
                _uow.BookRepository.Update(book);
                await _uow.BookRepository.SaveRepoAsync();
                DC_Borrow newEntry = new DC_Borrow
                {
                    BookId = bookId,
                    MemberId = memberId,
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

        public async Task ReturnBook(int borrowId)
        {
            DC_Borrow borrowInfo = await _uow.BorrowRepository.GetByIdAsync(borrowId);
            if(borrowInfo != null)
            {
                if(borrowInfo.Status != "Returned")
                {
                    DC_Book book = await _uow.BookRepository.GetByIdAsync(borrowInfo.BookId);
                    borrowInfo.ReturnDate = DateTime.UtcNow;
                    borrowInfo.Status = "Returned";
                    _uow.BorrowRepository.Update(borrowInfo);
                    await _uow.BorrowRepository.SaveRepoAsync();

                    book.Copies++;
                    _uow.BookRepository.Update(book);
                    await _uow.BookRepository.SaveRepoAsync();
                }
                else
                {
                    var message = string.Format("Book already returned.");
                    throw new Exception(message);
                }
               
            }
            else
            {
                var message = string.Format("Borrow with id = {0} not found.", borrowId);
                throw new Exception(message);
            }
            
        }

        public async Task ReserveBook(int bookId, int memberId)
        {
            // Get a book by id first
            DC_Book book = await _uow.BookRepository.GetByIdAsync(bookId);
            DC_Member member = await _uow.MemberRepository.GetByIdAsync(memberId);

            // Check if book is null
            if (book == null || member == null)
            {
                var message = string.Format("Book with id = {0} not found or invalid user", bookId);
                throw new Exception(message);
            }
            if(book.Copies > 0)
            {
                var message = string.Format("There are plenty of copies");
                throw new Exception(message);
            }

            // Do we need to check if we have enough copies to reserve?

            // Create a new entry in DC_Reservation
            DC_Reservation newReservation = new DC_Reservation
            {
                BookId = bookId,
                MemberId = memberId,
                ReservationDate = DateTime.UtcNow,
                ReservationExpirationDate = DateTime.UtcNow.AddDays(14), // 14 days EX
                ReservationStatus = true,
                ReservationResult = null
            };

            // Insert new reservation to db
            _uow.ReservationRepository.Insert(newReservation);

            // Save
            await _uow.ReservationRepository.SaveRepoAsync();
        }

        public async Task<ICollection<BookModel>> searchByTitle(string title)
        {
            ICollection<DC_Book> books = await _uow.BookRepository.GetAllAsync(0, 5);
            var bookList = books.ToList();

            //ICollection<DC_Book> foundBooks = new Collection<DC_Book>();

            foreach (var book in bookList)
            {
                if (!(book.Title.ToLower().Contains(title.ToLower())))
                {
                    books.Remove(book);
                }
            }

            ICollection<BookModel> model = _Mapper.Map<ICollection<DC_Book>, ICollection<BookModel>>(books);
            return model;
        }

        
        public async Task<ICollection<BookModel>> searchByAuthor(string author)
        {
            //Getting all the rows from bookAuthor
            ICollection<DC_BookAuthor> bookAuthors = await _uow.BookAuthorRepository.GetAllAsync(0,5);
            //Getting all the authors
            ICollection<DC_Author> authors = await _uow.AuthorRepository.GetAllAsync(0,5);
            //This will hold the books that are found and are related to the author entered. 
            ICollection<DC_Book> foundBooks = new Collection<DC_Book>();
            //Used if the author entered exists. 
            DC_Author foundAuthor = new DC_Author();
            //Go through all the authors and check if the first or last name contain the entered input. 
            foreach(var auth in authors)
            {
                if(auth.FirstName.ToLower().Contains(author) || auth.LastName.ToLower().Contains(author))
                {
                    foundAuthor = auth;
                }
            }
            var bookAuthorsList = bookAuthors.ToList();
            //Go thorugh the bookAuthor rows and check where the autherId is the same as the foundAuthorId. 
            foreach(var bookAuthor in bookAuthorsList)
            {
                if(bookAuthor.AuthorId == foundAuthor.Id)
                {
                    //Add the book to the foundBooks array. 
                    foundBooks.Add(await _uow.BookRepository.GetByIdAsync(bookAuthor.BookId));
                }
            }
            ICollection<BookModel> model = _Mapper.Map<ICollection<DC_Book>, ICollection<BookModel>>(foundBooks);
            return model;
        }
        
    }
}
