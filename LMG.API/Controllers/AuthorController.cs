using LMG.DAT.Interfaces;
using LMG.DAT.Models.Author;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : LMGControllerBase<DC_Author>
    {
        public AuthorController(IGenericRepository<DC_Author> repository) : base(repository)
        {
        }
    }
}
