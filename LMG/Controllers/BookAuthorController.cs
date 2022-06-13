using LMG.DAT.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMG.Controllers
{
    public class BookAuthorController : Controller
    {
        private readonly IGeneralUnitOfWork _uow;
        public BookAuthorController(IGeneralUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: BookAuthorController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BookAuthorController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                return Ok(await _uow.BookAuthorRepository.GetByIdAsync(id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: BookAuthorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookAuthorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookAuthorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookAuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookAuthorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookAuthorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
