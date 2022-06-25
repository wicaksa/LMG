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

        private Mapper _Mapper;
        private List<DC_Book> books;
        private List<DC_Author> authors;
        private List<DC_BookAuthor> bookAuthors;
        private DC_Member user;
        private MemberManagementUnitOfWork uow;
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
            //Mock Repos
            _mockBookRepo = new Mock<IGenericRepository<DC_Book>>();
            _mockAuthorRepo = new Mock<IGenericRepository<DC_Author>>();
            _mockBookAuthorRepo = new Mock<IGenericRepository<DC_BookAuthor>>();
            _mockBorrowRepo = new Mock<IGenericRepository<DC_Borrow>>();
            _mockMemberRepo = new Mock<IGenericRepository<DC_Member>>();
            _mockReservationRepo = new Mock<IGenericRepository<DC_Reservation>>();
            _mockReviewRepo = new Mock<IGenericRepository<DC_Review>>();
            _mockSeriesRepo = new Mock<IGenericRepository<DC_Series>>();

            //config for Mapper
            var _config = new MapperConfiguration(cfg => cfg.CreateMap<DC_Book, BookModel>().ReverseMap());
            _Mapper = new Mapper(_config);

            //Objects needed for the mocks
            books = new List<DC_Book>(){new DC_Book
            {
                Id = 1,
                Title = "Harry Potter & The Socerer's Stone",
                Copies = 2,
                SerieId = 1,
                Edition = 1,
                Genre = "Fantasy",
                Summary = "A boy learns on his eleventh birthday that he is the orphaned son of two powerful wizards and possesses unique magical powers of his own. He is summoned from his life as an unwanted child to become a student at Hogwarts, an English boarding school for wizards. There, he meets several friends who become his closest allies and help him discover the truth about his parents' mysterious deaths.",
                PublicationYear = 1997,
                CreatedBy = "Me",
                ModifiedBy = "Me"
            }, new DC_Book
            {
                Id = 2,
                Title = "Harry Potter and the Chamber of Secrets",
                Copies = 0,
                SerieId = 1,
                Edition = 1,
                Genre = "Fantasy",
                Summary = "The second instalment of boy wizard Harry Potter's adventures at Hogwarts School of Witchcraft and Wizardry, based on the novel by JK Rowling. A mysterious elf tells Harry to expect trouble during his second year at Hogwarts, but nothing can prepare him for trees that fight back, flying cars, spiders that talk and deadly warnings written in blood on the walls of the school.",
                PublicationYear = 1998,
                CreatedBy = "Me",
                ModifiedBy = "Me"
            }, new DC_Book
            {
                Title = "The Catcher in the Rye",
                Copies = 5,
                SerieId = null,
                Edition = 1,
                Genre = "Fiction",
                Summary = "The novel details two days in the life of 16-year-old Holden Caulfield after he has been expelled from prep school. Confused and disillusioned, Holden searches for truth and rails against the phoniness of the adult world.",
                PublicationYear = 1951,
            }, new DC_Book
            {
                Title = "Things Fall Apart",
                Copies = 5,
                SerieId = null,
                Edition = 1,
                Genre = "Fiction",
                Summary = "Things Fall Apart is the debut novel by Nigerian author Chinua Achebe, first published in 1958. It depicts pre-colonial life in the southeastern part of Nigeria and the invasion by Europeans during the late 19th century. ",
                PublicationYear = 1958
            }, new DC_Book
            {
                Id = 5,
                Title = "We Are What We Eat: A Slow Food Manifesto",
                Copies = 0,
                SerieId = null,
                Edition = 1,
                Genre = "Non-Fiction",
                Summary = "Since opening Chez Panisse in 1971, Alice Waters has been a kind of living legend in the movement for local food, sustainable agriculture, and seasonal cooking. In her latest work, she recounts scenes from that career that fans of hers will enjoy while championing a slow food approach to farming and eating, with an emphasis on regenerative agriculture, biodiversity, and health.",
                PublicationYear = 2021,
                CreatedBy = "Me",
                ModifiedBy = "Me"
            }};

            authors = new List<DC_Author>()
            {
                 new DC_Author

                {
                    Id = 1,
                    FirstName = "J.K.",
                    LastName = "Rowling",
                    Description = "Joanne Rowling, also known by her pen name " +
                    "J. K. Rowling, is a British author and philanthropist. She " +
                    "wrote a seven-volume children's fantasy series, Harry Potter," +
                    " published from 1997 to 2007.",
                    Dob = "07/31/1965",
                    Dod = null,
                    CreatedBy = "Me",
                    ModifiedBy = "Me"
                },

                new DC_Author
                {
                    Id = 2,
                    FirstName = "J.D.",
                    LastName = "Sallinger",
                    Description = "Jerome David Salinger was an American author " +
                    "best known for his 1951 novel The Catcher in the Rye. Before " +
                    "its publication, Salinger published several short stories in " +
                    "Story magazine and served in World War II.",
                    Dob = "01/01/1919",
                    Dod = "01/27/2010",
                    CreatedBy = "Me",
                    ModifiedBy = "Me"
                },

                new DC_Author

                {
                    Id = 3,
                    FirstName = "Chinua",
                    LastName = "Achebe",
                    Description = "Chinua Achebe was a Nigerian novelist, poet, and " +
                    "critic who is regarded as the dominant figure of modern African " +
                    "literature. His first novel and magnum opus, Things Fall Apart," +
                    " occupies a pivotal place in African literature and remains the " +
                    "most widely studied, translated and read African novel.",
                    Dob = "11/16/1930",
                    Dod = "03/21/2013",
                    CreatedBy = "Me",
                    ModifiedBy = "Me"
                },

                new DC_Author

                {
                    Id = 4,
                    FirstName = "Alice",
                    LastName = "Waters",
                    Description = "Alice Louise Waters is an American chef, restaurateur, " +
                    "and author. In 1971 she opened Chez Panisse, a Berkeley, California " +
                    "restaurant famous for its role in creating the farm-to-table movement " +
                    "and for pioneering California cuisine.",
                    Dob = "04/28/1944",
                    Dod = null,
                    CreatedBy = "Me",
                    ModifiedBy = "Me"
                }
            };

            bookAuthors = new List<DC_BookAuthor>()
            {
                new DC_BookAuthor
                {
                    Id = 1,
                    AuthorId = 1,
                    BookId = 1
                },

                new DC_BookAuthor
                {
                    Id = 2,
                    AuthorId = 1,
                    BookId = 2
                },

                new DC_BookAuthor
                {
                    Id = 3,
                    AuthorId = 2,
                    BookId = 3
                },

                new DC_BookAuthor
                {
                    Id = 4,
                    AuthorId = 3,
                    BookId = 4
                },

                new DC_BookAuthor
                {
                    Id = 5,
                    AuthorId = 4,
                    BookId = 5
                }
            };

            user = new DC_Member
            {
                Id = 1,
                FirstName = "Earl",
                LastName = "Stevens",
                Birthdate = "11/15/1967",
                Gender = "Male",
                Phone = 8312124438
            };

            //setup for get functions
            _mockBookRepo.Setup(repo => repo.GetAllAsync(0, 5)).ReturnsAsync(books.ToList());

            //Book with copies > 0
            _mockBookRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(books.First);
            //Book with copies == 0
            _mockBookRepo.Setup(repo => repo.GetByIdAsync(2)).ReturnsAsync(books[1]);

            _mockMemberRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(user);

            _mockBookAuthorRepo.Setup(repo => repo.GetAllAsync(0, 5)).ReturnsAsync(bookAuthors);
            _mockAuthorRepo.Setup(repo => repo.GetAllAsync(0, 5)).ReturnsAsync(authors);

            /* Used for repos
            var dbName = $"LMGFakeDb_{DateTime.Now.ToFileTimeUtc()}";
            _dbContextOptions = new DbContextOptionsBuilder<LMG_DbContext>()
            .UseInMemoryDatabase(dbName)
            .EnableSensitiveDataLogging()
            .Options;

            _ctx = new LMG_DbContext(_dbContextOptions);
            */

            uow = new MemberManagementUnitOfWork(_mockBookRepo.Object, _mockAuthorRepo.Object, _mockBookAuthorRepo.Object, _mockBorrowRepo.Object, _mockMemberRepo.Object, _mockReservationRepo.Object, _mockReviewRepo.Object, _mockSeriesRepo.Object);

        }

        [Test]
        public async Task GetAvailableBooks_Success()
        {
            var expectedBooks = new List<DC_Book>() { new DC_Book
            {
                Id = 1,
                Title = "Harry Potter & The Socerer's Stone",
                Copies = 2,
                SerieId = 1,
                Edition = 1,
                Genre = "Fantasy",
                Summary = "A boy learns on his eleventh birthday that he is the orphaned son of two powerful wizards and possesses unique magical powers of his own. He is summoned from his life as an unwanted child to become a student at Hogwarts, an English boarding school for wizards. There, he meets several friends who become his closest allies and help him discover the truth about his parents' mysterious deaths.",
                PublicationYear = 1997,
                CreatedBy = "Me",
                ModifiedBy = "Me"
            }, new DC_Book
            {
                Title = "The Catcher in the Rye",
                Copies = 5,
                SerieId = null,
                Edition = 1,
                Genre = "Fiction",
                Summary = "The novel details two days in the life of 16-year-old Holden Caulfield after he has been expelled from prep school. Confused and disillusioned, Holden searches for truth and rails against the phoniness of the adult world.",
                PublicationYear = 1951,
            }, new DC_Book
            {
                Title = "Things Fall Apart",
                Copies = 5,
                SerieId = null,
                Edition = 1,
                Genre = "Fiction",
                Summary = "Things Fall Apart is the debut novel by Nigerian author Chinua Achebe, first published in 1958. It depicts pre-colonial life in the southeastern part of Nigeria and the invasion by Europeans during the late 19th century. ",
                PublicationYear = 1958
            }};


            //_ctx.Book.AddRange(books);
            var uow = new MemberManagementUnitOfWork(_mockBookRepo.Object, _mockAuthorRepo.Object, _mockBookAuthorRepo.Object, _mockBorrowRepo.Object, _mockMemberRepo.Object, _mockReservationRepo.Object, _mockReviewRepo.Object, _mockSeriesRepo.Object);
            var actual = await uow.GetAvailableBooks();
            var bookModels = _Mapper.Map<ICollection<DC_Book>, ICollection<BookModel>>(expectedBooks);
            Assert.That(actual.ToString(), Is.EqualTo(bookModels.ToString()));
        }

        [Test]
        public async Task GetUnavailableBooks_Success()
        {
            var expectedBooks = new List<DC_Book>()
            {
                 new DC_Book
            {
                Id = 2,
                Title = "Harry Potter and the Chamber of Secrets",
                Copies = 0,
                SerieId = 1,
                Edition = 1,
                Genre = "Fantasy",
                Summary = "The second instalment of boy wizard Harry Potter's adventures at Hogwarts School of Witchcraft and Wizardry, based on the novel by JK Rowling. A mysterious elf tells Harry to expect trouble during his second year at Hogwarts, but nothing can prepare him for trees that fight back, flying cars, spiders that talk and deadly warnings written in blood on the walls of the school.",
                PublicationYear = 1998,
                CreatedBy = "Me",
                ModifiedBy = "Me"
            },
                new DC_Book
            {
                Id = 5,
                Title = "We Are What We Eat: A Slow Food Manifesto",
                Copies = 0,
                SerieId = null,
                Edition = 1,
                Genre = "Non-Fiction",
                Summary = "Since opening Chez Panisse in 1971, Alice Waters has been a kind of living legend in the movement for local food, sustainable agriculture, and seasonal cooking. In her latest work, she recounts scenes from that career that fans of hers will enjoy while championing a slow food approach to farming and eating, with an emphasis on regenerative agriculture, biodiversity, and health.",
                PublicationYear = 2021,
                CreatedBy = "Me",
                ModifiedBy = "Me"
            }};

            //_ctx.Book.AddRange(books);
            var uow = new MemberManagementUnitOfWork(_mockBookRepo.Object, _mockAuthorRepo.Object, _mockBookAuthorRepo.Object, _mockBorrowRepo.Object, _mockMemberRepo.Object, _mockReservationRepo.Object, _mockReviewRepo.Object, _mockSeriesRepo.Object);
            var actual = await uow.GetUnavailableBooks();
            var bookModels = _Mapper.Map<ICollection<DC_Book>, ICollection<BookModel>>(expectedBooks);
            Assert.That(actual.ToString(), Is.EqualTo(bookModels.ToString()));
        }

        [Test]
        public async Task BorrowBook_validParams_Success()
        {
            //Arrange

            //Act
            await uow.BorrowBook(1, 1);

            //Assert
            _mockBookRepo.Verify(update => update.Update(It.IsAny<DC_Book>()), Times.Exactly(1));
            _mockBorrowRepo.Verify(insert => insert.Insert(It.IsAny<DC_Borrow>()), Times.Exactly(1));
            _mockBookRepo.Verify(save => save.SaveRepoAsync(), Times.Exactly(1));
        }

        [Test]
        public void BorrowBook_invalidParams_throwsException()
        {
            //Arrange

            //Act

            //Assert
            var invalidMemberId = Assert.ThrowsAsync<Exception>(() => uow.BorrowBook(2, 100));
            var invalidBookId = Assert.ThrowsAsync<Exception>(() => uow.BorrowBook(200, 1));
            Assert.That(invalidMemberId.Message, Is.EqualTo(string.Format("Book with id = {0} not found or invalid user", 2)));
            Assert.That(invalidBookId.Message, Is.EqualTo(string.Format("Book with id = {0} not found or invalid user", 200)));
        }

        [Test]
        public void BorrowBook_notEnoughCopies_throwsException()
        {
            var ex = Assert.ThrowsAsync<Exception>(() => uow.BorrowBook(2, 1));
            Assert.That(ex.Message, Is.EqualTo("Cannot borrow this book. There is not enough copies."));

        }

        [Test]
        public async Task ReturnBook_ValidParams_Success()
        {
            var newBorrow = new DC_Borrow {
                Id = 1,
                BookId = 1,
                MemberId = 1,
                BorrowDate = new DateTime(2022, 1, 1),
                ReturnDate = new DateTime(2022, 1, 8),
                Status = "Good"
            };
            //Arrange
            _mockBorrowRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(newBorrow);

            //Act
            await uow.ReturnBook(1);

            //Assert
            _mockBorrowRepo.Verify(update => update.Update(It.IsAny<DC_Borrow>()), Times.Exactly(1));
            _mockBookRepo.Verify(update => update.Update(It.IsAny<DC_Book>()), Times.Exactly(1));
            _mockBookRepo.Verify(save => save.SaveRepoAsync(), Times.Exactly(1));
        }

        [Test]
        public void ReturnBook_invalidParam_throwsException()
        {
            var ex = Assert.ThrowsAsync<Exception>(() => uow.ReturnBook(100));
            Assert.That(ex.Message, Is.EqualTo(string.Format("Borrow with id = {0} not found.", 100)));
        }

        [Test]
        public void ReturnBook_alreadyReturned_throwsException()
        {
            var borrowEntry = new DC_Borrow
            {
                Id = 4,
                BookId = 3,
                MemberId = 3,
                BorrowDate = new DateTime(2022, 1, 3),
                ReturnDate = new DateTime(2022, 1, 10),
                Status = "Returned"
            };

            _mockBorrowRepo.Setup(repo => repo.GetByIdAsync(4)).ReturnsAsync(borrowEntry);
            var ex = Assert.ThrowsAsync<Exception>(() => uow.ReturnBook(4));
            Assert.That(ex.Message, Is.EqualTo("Book already returned."));
        }

        [Test]
        public async Task ReserveBook_ValidParams_Success()
        {
            //Arrange 

            //Act
            await uow.ReserveBook(2, 1);

            //Assert
            _mockReservationRepo.Verify(insert => insert.Insert(It.IsAny<DC_Reservation>()), Times.Exactly(1));
            _mockReservationRepo.Verify(save => save.SaveRepoAsync(), Times.Exactly(1));
        }

        [Test]
        public void ReservereBook_invalidParams_throwsException()
        {
            var invalidMemberId = Assert.ThrowsAsync<Exception>(() => uow.ReserveBook(2, 100));
            var invalidBookId = Assert.ThrowsAsync<Exception>(() => uow.ReserveBook(200, 1));
            Assert.That(invalidMemberId.Message, Is.EqualTo(string.Format("Book with id = {0} not found or invalid user", 2)));
            Assert.That(invalidBookId.Message, Is.EqualTo(string.Format("Book with id = {0} not found or invalid user", 200)));
        }
        
        [Test]
        public void ReservereBook_enoughCopies_throwsException()
        {
            var ex = Assert.ThrowsAsync<Exception>(() => uow.ReserveBook(1, 1));
            Assert.That(ex.Message, Is.EqualTo("There are plenty of copies"));
        }

        [Test]
        public async Task SearchByTitle_validParam_Success()
        {
            //Arrange
            var expectedBooks = new List<DC_Book>()
            {
                new DC_Book
            {
                Id = 1,
                Title = "Harry Potter & The Socerer's Stone",
                Copies = 2,
                SerieId = 1,
                Edition = 1,
                Genre = "Fantasy",
                Summary = "A boy learns on his eleventh birthday that he is the orphaned son of two powerful wizards and possesses unique magical powers of his own. He is summoned from his life as an unwanted child to become a student at Hogwarts, an English boarding school for wizards. There, he meets several friends who become his closest allies and help him discover the truth about his parents' mysterious deaths.",
                PublicationYear = 1997,
                CreatedBy = "Me",
                ModifiedBy = "Me"
            },
                 new DC_Book
            {
                Id = 2,
                Title = "Harry Potter and the Chamber of Secrets",
                Copies = 0,
                SerieId = 1,
                Edition = 1,
                Genre = "Fantasy",
                Summary = "The second instalment of boy wizard Harry Potter's adventures at Hogwarts School of Witchcraft and Wizardry, based on the novel by JK Rowling. A mysterious elf tells Harry to expect trouble during his second year at Hogwarts, but nothing can prepare him for trees that fight back, flying cars, spiders that talk and deadly warnings written in blood on the walls of the school.",
                PublicationYear = 1998,
                CreatedBy = "Me",
                ModifiedBy = "Me"
            }};
            var bookModels = _Mapper.Map<ICollection<DC_Book>, ICollection<BookModel>>(expectedBooks);
            //Act
            var foundBooks = await uow.searchByTitle("Harry");

            //Asssert
            Assert.That(foundBooks.ToString(), Is.EqualTo(bookModels.ToString()));
        }

        [Test]
        public async Task SearchByTitle_findNothing_empty()
        {
            var foundBooks = await uow.searchByTitle("Nothing");
            Assert.IsEmpty(foundBooks);
        }

        [Test]
        public async Task SearchByAuthor_validParam_Success()
        {
            //Arrange
            var expectedBooks = new List<DC_Book>()
            {
                new DC_Book
            {
                Id = 1,
                Title = "Harry Potter & The Socerer's Stone",
                Copies = 2,
                SerieId = 1,
                Edition = 1,
                Genre = "Fantasy",
                Summary = "A boy learns on his eleventh birthday that he is the orphaned son of two powerful wizards and possesses unique magical powers of his own. He is summoned from his life as an unwanted child to become a student at Hogwarts, an English boarding school for wizards. There, he meets several friends who become his closest allies and help him discover the truth about his parents' mysterious deaths.",
                PublicationYear = 1997,
                CreatedBy = "Me",
                ModifiedBy = "Me"
            },
                 new DC_Book
            {
                Id = 2,
                Title = "Harry Potter and the Chamber of Secrets",
                Copies = 0,
                SerieId = 1,
                Edition = 1,
                Genre = "Fantasy",
                Summary = "The second instalment of boy wizard Harry Potter's adventures at Hogwarts School of Witchcraft and Wizardry, based on the novel by JK Rowling. A mysterious elf tells Harry to expect trouble during his second year at Hogwarts, but nothing can prepare him for trees that fight back, flying cars, spiders that talk and deadly warnings written in blood on the walls of the school.",
                PublicationYear = 1998,
                CreatedBy = "Me",
                ModifiedBy = "Me"
            }};
            var bookModels = _Mapper.Map<ICollection<DC_Book>, ICollection<BookModel>>(expectedBooks);
            //Act
            var foundBooks = await uow.searchByTitle("Harry");

            //Asssert
            Assert.That(foundBooks.ToString(), Is.EqualTo(bookModels.ToString()));
        }

        [Test]
        public async Task searchByAuthor_findNothing_empty()
        {
            var foundBooks = await uow.searchByAuthor("Nothing");
            Assert.IsEmpty(foundBooks);
        }
    }
}