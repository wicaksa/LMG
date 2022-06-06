using LMG.DAT.UnitOfWork;
using LMG.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LMG.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGeneralUnitOfWork _uow;

        public HomeController(ILogger<HomeController> logger, IGeneralUnitOfWork uow)
        {
            _logger = logger;
            _uow = uow;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthorBookObjects()
        {
            try
            {
                return Ok(await _uow.GetAuthorBook());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}