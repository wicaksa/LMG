using LMG.API.Controllers.LMG.API.Controllers;
using LMG.DAT.Interfaces;
using LMG.DAT.Models.Series;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : LMGControllerBase<DC_Series>
    {
        public SeriesController(IGenericRepository<DC_Series> repository) : base(repository)
        {
        }
    }
}
