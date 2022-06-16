using LMG.API.Controllers.LMG.API.Controllers;
using LMG.BLL.Models;
using LMG.DAT.Interfaces;
using LMG.DAT.Models.Review;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : LMGControllerBase<ReviewModel, DC_Review>
    {
        public ReviewController(GenericRepository<DC_Review> repository) : base(repository)
        {
        }
    }
}
