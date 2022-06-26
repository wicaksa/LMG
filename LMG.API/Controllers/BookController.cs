using LMG.API.Controllers.LMG.API.Controllers;
using LMG.BLL.Models;
using LMG.DAT.Interfaces;
using LMG.DAT.Models.Book;
using LMG.DAT.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMG.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BookController : LMGControllerBase<BookModel, DC_Book>
    {
        //private readonly IGeneralUnitOfWork<BookModel, DC_Book> _uow;

        public BookController(IGeneralUnitOfWork<BookModel, DC_Book> uow) : base(uow)
        {
        }

        /*
        public BookController(IGenericRepository<DC_Book> repository) : base(repository)
        {
            
        }
        */

        /*
        [ActivatorUtilitiesConstructor]
        public BookController(IGeneralUnitOfWork uow, IGenericRepository<DC_Book> repository) : base(repository)
        {
            _uow = uow;
        }
        */


    }

}
