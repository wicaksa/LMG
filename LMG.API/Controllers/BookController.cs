using LMG.API.Controllers.LMG.API.Controllers;
using LMG.DAT.Interfaces;
using LMG.DAT.Models.Book;
using LMG.DAT.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMG.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BookController : LMGControllerBase<DC_Book>
    {
        private readonly IGeneralUnitOfWork _uow;

        public BookController(IGenericRepository<DC_Book> repository) : base(repository)
        {
            
        }

        [ActivatorUtilitiesConstructor]
        public BookController(IGeneralUnitOfWork uow, IGenericRepository<DC_Book> repository) : base(repository)
        {
            _uow = uow;
        }

        
    }

}
