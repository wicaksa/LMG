using AutoMapper;
using LMG.BLL.Models;
using LMG.DAT.Interfaces;
using LMG.DAT.Models.Author;
using LMG.DAT.Models.Book;
using LMG.DAT.Models.BookAuthor;
using LMG.DAT.Models.Borrow;
using LMG.DAT.Models.Member;
using LMG.DAT.Models.Reservation;
using LMG.DAT.Models.Review;
using LMG.DAT.Models.Series;
using LMG.DAT.UnitOfWork;
using Moq;

namespace LMG.UnitTest
{
    public class MemberManagementUnitTests
    {
        private Mock<IGenericRepository<DC_Book>> _mockBookRepo;
        private Mock<IGenericRepository<DC_Author>> _mockAuthorRepo;
        private Mock<IGenericRepository<DC_BookAuthor>> _mockBookAuthorRepo;
        private Mock<IGenericRepository<DC_Borrow>> _mockBorrowRepo;
        private Mock<IGenericRepository<DC_Member>> _mockMemberRepo;
        private Mock<IGenericRepository<DC_Reservation>> _mockReservationRepo;
        private Mock<IGenericRepository<DC_Review>> _mockReviewRepo;
        private Mock<IGenericRepository<DC_Series>> _mockSeriesRepo;
        private Mock<IMemberManagementUnitOfWork> _uow;

        private Mapper _Mapper;

        /*
        private DbContextOptions<LMG_DbContext> _dbContextOptions = null!;
        private LMG_DbContext _ctx = null!;
        */

        //MOck all te repos
        //helper classes
        //Assignemnt for now is code coverage on membermanagement_uow
        //Make interface for the membermanagement_UOW //
        //Fix the dependency injection //
        //Helper fuinctions in general_uow (used for other UOW)
        [SetUp]
        public void Setup()
        {
            _mockBookRepo = new Mock<IGenericRepository<DC_Book>>();
            _mockAuthorRepo = new Mock<IGenericRepository<DC_Author>>();
            _mockBookAuthorRepo = new Mock<IGenericRepository<DC_BookAuthor>>();
            _mockBorrowRepo = new Mock<IGenericRepository<DC_Borrow>>();
            _mockMemberRepo = new Mock<IGenericRepository<DC_Member>>();
            _mockReservationRepo = new Mock<IGenericRepository<DC_Reservation>>();
            _mockReviewRepo = new Mock<IGenericRepository<DC_Review>>();
            _mockSeriesRepo = new Mock<IGenericRepository<DC_Series>>();

            _uow = new Mock<IMemberManagementUnitOfWork>();

            var _config = new MapperConfiguration(cfg => cfg.CreateMap<DC_Book, BookModel>().ReverseMap());
            _Mapper = new Mapper(_config);

            /* Used for repos
            var dbName = $"LMGFakeDb_{DateTime.Now.ToFileTimeUtc()}";
            _dbContextOptions = new DbContextOptionsBuilder<LMG_DbContext>()
            .UseInMemoryDatabase(dbName)
            .EnableSensitiveDataLogging()
            .Options;

            _ctx = new LMG_DbContext(_dbContextOptions);
            */


            /*
            _uow.Setup(m => m.BookRepository).Returns(_mockBookRepo.Object);
            _uow.Setup(m => m.AuthorRepository).Returns(_mockAuthorRepo.Object);
            _uow.Setup(m => m.BookAuthorRepository).Returns(_mockBookAuthorRepo.Object);
            _uow.Setup(m => m.BorrowRepository).Returns(_mockBorrowRepo.Object);
            _uow.Setup(m => m.MemberRepository).Returns(_mockMemberRepo.Object);
            _uow.Setup(m => m.ReservationRepository).Returns(_mockReservationRepo.Object);
            _uow.Setup(m => m.ReviewRepository).Returns(_mockReviewRepo.Object);
            _uow.Setup(m => m.SeriesRepository).Returns(_mockSeriesRepo.Object);
            */
        }

        [Test]
        public async Task GetAvailableBooks_Success()
        {
            var books = new List<DC_Book>();
            DC_Book currentModel = new DC_Book
            {
                Title = "Harry Potter & The Socerer's Stone",
                Copies = 3,
                SerieId = 1,
                Edition = 1,
                Genre = "Fantasy",
                Summary = "A boy learns on his eleventh birthday that he is the orphaned son of two powerful wizards and possesses unique magical powers of his own. He is summoned from his life as an unwanted child to become a student at Hogwarts, an English boarding school for wizards. There, he meets several friends who become his closest allies and help him discover the truth about his parents' mysterious deaths.",
                PublicationYear = 1997
            };
            books.Add(currentModel);
            currentModel = new DC_Book
            {
                Title = "The Catcher in the Rye",
                Copies = 5,
                SerieId = null,
                Edition = 1,
                Genre = "Fiction",
                Summary = "The novel details two days in the life of 16-year-old Holden Caulfield after he has been expelled from prep school. Confused and disillusioned, Holden searches for truth and rails against the phoniness of the adult world.",
                PublicationYear = 1951,
            };
            books.Add(currentModel);
            currentModel = new DC_Book
            {
                Title = "Things Fall Apart",
                Copies = 5,
                SerieId = null,
                Edition = 1,
                Genre = "Fiction",
                Summary = "Things Fall Apart is the debut novel by Nigerian author Chinua Achebe, first published in 1958. It depicts pre-colonial life in the southeastern part of Nigeria and the invasion by Europeans during the late 19th century. ",
                PublicationYear = 1958
            };
            books.Add(currentModel);

            _mockBookRepo.Setup(repo => repo.GetAllAsync(0, 5)).ReturnsAsync(books.ToList());
            //_ctx.Book.AddRange(books);
            var uow = new MemberManagementUnitOfWork(_mockBookRepo.Object, _mockAuthorRepo.Object, _mockBookAuthorRepo.Object, _mockBorrowRepo.Object, _mockMemberRepo.Object, _mockReservationRepo.Object, _mockReviewRepo.Object, _mockSeriesRepo.Object);
            var actual = await uow.GetAvailableBooks();
            Assert.IsNotNull(actual, "Its Null");
            Assert.That(actual, Is.EquivalentTo(books));
        }
    }
}