using LMG.API.Controllers.LMG.API.Controllers;
using LMG.BLL.Models;
using LMG.DAT.Interfaces;
using LMG.DAT.Models.Borrow;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowController : LMGControllerBase<BorrowModel, DC_Borrow>
    {
        /*
        public BorrowController(IGenericRepository<DC_Borrow> repository) : base(repository)
        {
        }
        */
        public BorrowController(IGeneralUnitOfWork<BorrowModel, DC_Borrow> uow) : base(uow)
        {
        }
    }
}
