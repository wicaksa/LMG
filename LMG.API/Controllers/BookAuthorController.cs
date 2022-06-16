using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using LMG.API.Controllers.LMG.API.Controllers;
using LMG.DAT.Interfaces;
using LMG.DAT.Models.BookAuthor;
using LMG.BLL.Models;

namespace LMG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAuthorController : LMGControllerBase<BookAuthorModel, DC_BookAuthor>

    {
        public BookAuthorController(GenericRepository<DC_BookAuthor> repository) : base(repository)
        {

        }
    }
}
