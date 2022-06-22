using LMG.DAT.Interfaces;
using LMG.DAT.Models.Book;
using Moq;

namespace LMG.UnitTest
{
    public class MemberManagementUnitTests
    {
        private Mock<IGenericRepository<DC_Book>> _mockBookRepo;
        //MOck all te repos
        //helper classes
        //Assignemnt for now is code coverage on membermanagement_uow
        //Make interface for the membermanagement_UOW
        //Fix the dependency injection
        //Helper fuinctions in general_uow (used for other UOW)
        [SetUp]
        public void Setup()
        {
            _mockBookRepo = new Mock<IGenericRepository<DC_Book>>();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}