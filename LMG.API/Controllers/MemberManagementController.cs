using LMG.BLL;
using LMG.BLL.Models;
using LMG.DAT.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberManagementController : ControllerBase
    {
        private readonly IGeneralUnitOfWork _uow;
        private MemberManagementBLL _BLL;

        public MemberManagementController(IGeneralUnitOfWork uow)
        {
            _uow = uow;
            _BLL = new MemberManagementBLL(_uow);
        }

        [HttpGet]
        [Route("getAvailableBooks")]
        public async Task<ICollection<BookModel>> GetAvailableBooks()
        {
            return await _BLL.GetAvailableBooks();
        }

        [HttpGet]
        [Route("getUnavailableBooks")]
        public async Task<ICollection<BookModel>> GetUnavailableBooks()
        {
            return await _BLL.GetUnavailableBooks();
        }

        [HttpGet]
        [Route("searchByTitle")]
        public async Task<ICollection<BookModel>> SearchByTitle(string title)
        {
            return await _BLL.searchByTitle(title);
        }

        [HttpGet]
        [Route("searchByAuthor")]
        public async Task<ICollection<BookModel>> SearchByAuthor(string author)
        {
            return await _BLL.searchByAuthor(author);
        }

        [HttpPatch]
        [Route("borrowBook")]
        public async Task BorrowBook(int id)
        {
            await _BLL.BorrowBook(id);
        }

        [HttpPatch]
        [Route("returnBook")]
        public async Task ReturnBook(int id)
        {
            await _BLL.ReturnBook(id);
        }
    }
}
