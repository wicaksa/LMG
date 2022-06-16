using LMG.API.Controllers.LMG.API.Controllers;
using LMG.BLL;
using LMG.BLL.Models;
using LMG.DAT.Interfaces;
using LMG.DAT.Models.Author;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : LMGControllerBase<AuthorModel, DC_Author>
    {
        public AuthorController(GenericRepository<DC_Author> repository) : base(repository)
        {
        }
    }
}
