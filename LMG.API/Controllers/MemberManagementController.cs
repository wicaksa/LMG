using LMG.BLL.Models;
using LMG.DAT.Interfaces;
using LMG.DAT.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace LMG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberManagementController : ControllerBase
    {
        private readonly IMemberManagementUnitOfWork _uow;

        public MemberManagementController(IMemberManagementUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        [Route("getAvailableBooks")]
        public async Task<ICollection<BookModel>> GetAvailableBooks()
        {
            return await _uow.GetAvailableBooks();
        }

        [HttpGet]
        [Route("getUnavailableBooks")]
        public async Task<ICollection<BookModel>> GetUnavailableBooks()
        {
            return await _uow.GetUnavailableBooks();
        }

        [HttpGet]
        [Route("searchByTitle")]
        public async Task<ICollection<BookModel>> SearchByTitle(string title)
        {
            return await _uow.searchByTitle(title);
        }

        [HttpGet]
        [Route("searchByAuthor")]
        public async Task<ICollection<BookModel>> SearchByAuthor(string author)
        {
            return await _uow.searchByAuthor(author);
        }

        [HttpPatch]
        [Route("borrowBook")]
        public async Task BorrowBook(int bookId, int memberId)
        {
            await _uow.BorrowBook(bookId, memberId);
        }

        [HttpPatch]
        [Route("returnBook")]
        public async Task ReturnBook(int borrowId)
        {
            await _uow.ReturnBook(borrowId);
        }

        [HttpPatch]
        [Route("reserveBook")]
        public async Task ReserveBook(int bookId, int memberId)
        {
            await _uow.ReserveBook(bookId, memberId);
        }
    }
}
