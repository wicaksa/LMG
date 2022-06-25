using AutoMapper;
using LMG.BLL.Models;
using LMG.DAT.Interfaces;
using LMG.DAT.Models.Book;
using LMG.DAT.UnitOfWork;
using Moq;

namespace LMG.UnitTest
{
    public class GeneralManagementUnitTest
    {
        private Mock<IGenericRepository<DC_Book>> _mockBookRepo;
        private Mapper _Mapper;
        private GeneralUnitOfWork<BookModel, DC_Book> uow;
        private List<DC_Book> books;

        [SetUp]
        public void Setup()
        {
            _mockBookRepo = new Mock<IGenericRepository<DC_Book>>();

            var _config = new MapperConfiguration(cfg => cfg.CreateMap<DC_Book, BookModel>().ReverseMap());
            _Mapper = new Mapper(_config);

            uow = new GeneralUnitOfWork<BookModel, DC_Book>(_mockBookRepo.Object);

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
        }

        [Test]
        public async Task GetAll_Success()
        {
            var expected = _Mapper.Map<ICollection<DC_Book>, ICollection<BookModel>>(books);
            _mockBookRepo.Setup(repo => repo.GetAllAsync(0, 5)).ReturnsAsync(books);

            var actual = await uow.GetAll();

            Assert.That(actual.ToString(), Is.EqualTo(expected.ToString()));

        }
        
        [Test]
        public async Task GetById_ValidParam_Success()
        {
            var expected = _Mapper.Map<DC_Book, BookModel>(books[0]);
            _mockBookRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(books[0]);

            var actual = await uow.GetById(1);

            Assert.That(actual.ToString(), Is.EqualTo(expected.ToString()));

        }
        
        [Test]
        public void GetById_InvalidParam_ThrowsException()
        {
            var invalidId = Assert.ThrowsAsync<Exception>(() => uow.GetById(100));

            Assert.That(invalidId.Message, Is.EqualTo("Not Found"));
        }

        [Test]
        public void Insert_Success()
        {
            var book = books[0];
            var model = _Mapper.Map<DC_Book, BookModel>(book);

            uow.Insert(model);

            _mockBookRepo.Verify(insert => insert.Insert(It.IsAny<DC_Book>()), Times.Exactly(1));
            _mockBookRepo.Verify(save => save.SaveRepoAsync(), Times.Exactly(1));
        }

    }
}
