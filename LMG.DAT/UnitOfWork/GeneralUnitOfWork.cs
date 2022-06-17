using LMG.DAT.DataContext;
using LMG.DAT.Interfaces;
using LMG.DAT.Models.Author;
using LMG.DAT.Models.Book;
using LMG.DAT.Models.BookAuthor;
using LMG.DAT.Models.Borrow;
using LMG.DAT.Models.Member;
using LMG.DAT.Models.Reservation;
using LMG.DAT.Models.Review;
using LMG.DAT.Models.Series;
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
        Interfaces.GenericRepository<DC_Borrow> BorrowRepository { get; }
        Interfaces.GenericRepository<DC_Member> MemberRepository { get; }
        Interfaces.GenericRepository<DC_Reservation> ReservationRepository { get; }
        Interfaces.GenericRepository<DC_Review> ReviewRepository { get; }
        Interfaces.GenericRepository<DC_Series> SeriesRepository { get; }
    }
    public class GeneralUnitOfWork : IGeneralUnitOfWork
    {
        public Interfaces.GenericRepository<DC_Book> BookRepository { get; private set; }
        public Interfaces.GenericRepository<DC_Author> AuthorRepository { get; private set; }
        public Interfaces.GenericRepository<DC_BookAuthor> BookAuthorRepository { get; private set; }
        public Interfaces.GenericRepository<DC_Borrow> BorrowRepository { get; private set; }
        public Interfaces.GenericRepository<DC_Member> MemberRepository { get; private set; }
        public Interfaces.GenericRepository<DC_Reservation> ReservationRepository { get; private set; }
        public Interfaces.GenericRepository<DC_Review> ReviewRepository { get; private set; }
        public Interfaces.GenericRepository<DC_Series> SeriesRepository { get; private set; }

        public GeneralUnitOfWork(Interfaces.GenericRepository<DC_Book> bookRepository,
                                 Interfaces.GenericRepository<DC_Author> authorRepository,
                                 Interfaces.GenericRepository<DC_BookAuthor> bookAuthorRepository,
                                 Interfaces.GenericRepository<DC_Borrow> borrowRepository,
                                 Interfaces.GenericRepository<DC_Member> memberRepository,
                                 Interfaces.GenericRepository<DC_Reservation> reservationRepository,
                                 Interfaces.GenericRepository<DC_Review> reviewRepository,
                                 Interfaces.GenericRepository<DC_Series> seriesRepository)
        {
            BookRepository = bookRepository;
            AuthorRepository = authorRepository;
            BookAuthorRepository = bookAuthorRepository;
            BorrowRepository = borrowRepository;
            MemberRepository = memberRepository;
            ReservationRepository = reservationRepository;
            ReviewRepository = reviewRepository;
            SeriesRepository = seriesRepository;
        } 

    }
}
