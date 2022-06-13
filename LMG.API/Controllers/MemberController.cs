using LMG.API.Controllers.LMG.API.Controllers;
using LMG.DAT.Interfaces;
using LMG.DAT.Models.Member;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : LMGControllerBase<DC_Member>
    {
        public MemberController(DAT.Interfaces.IGenericRepository<DC_Member> repository) : base(repository)
        {
        }
    }
}
