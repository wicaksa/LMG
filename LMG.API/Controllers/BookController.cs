using LMG.DAT.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IGeneralUnitOfWork _uow;

        public BookController(IGeneralUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _uow.BookRepository.GetByIdAsync(id));
        }
    }
}
