using LMG.API.Controllers.LMG.API.Controllers;
using LMG.BLL.Models;
using LMG.DAT.Interfaces;
using LMG.DAT.Models.Series;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : LMGControllerBase<SeriesModel, DC_Series>
    {
        public SeriesController(GenericRepository<DC_Series> repository) : base(repository)
        {
        }
    }
}
