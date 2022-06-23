using LMG.BLL.Models;
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
    public interface IMemberManagementUnitOfWork
    {
        /*
        IGenericRepository<DC_Book> BookRepository { get; set; }
        IGenericRepository<DC_Author> AuthorRepository { get; set; }
        IGenericRepository<DC_BookAuthor> BookAuthorRepository { get; set; }
        IGenericRepository<DC_Borrow> BorrowRepository { get; set; }
        IGenericRepository<DC_Member> MemberRepository { get; set; }
        IGenericRepository<DC_Reservation> ReservationRepository { get; set; }
        IGenericRepository<DC_Review> ReviewRepository { get; set; }
        IGenericRepository<DC_Series> SeriesRepository { get; set; }
        */
        Task<ICollection<BookModel>> GetAvailableBooks();
        Task<ICollection<BookModel>> GetUnavailableBooks();
        Task BorrowBook(int bookId, int memberId);
        Task ReturnBook(int borrowId);
        Task ReserveBook(int bookId, int memberId);
        Task<ICollection<BookModel>> searchByTitle(string title);
        Task<ICollection<BookModel>> searchByAuthor(string author);

    }
}
