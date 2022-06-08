using LMG.DAT.Interfaces;
using LMG.DAT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class LMGControllerBase<TDataContext> : ControllerBase where TDataContext : DataContextBase
    {
        protected readonly IGenericRepository<TDataContext> Repository;
        public LMGControllerBase(IGenericRepository<TDataContext> repository)
        {
            Repository = repository;
        }

        [HttpGet]
        [Route("Foobar/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Repository.GetByIdAsync(id));
        }
    }
}
