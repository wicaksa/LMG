using LMG.DAT.Interfaces;
using LMG.DAT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


// Base Controller Class
namespace LMG.API.Controllers
{
    // The API Route

    namespace LMG.API.Controllers
    {

        [Route("api/[controller]")]
        [ApiController]
        public abstract class LMGControllerBase<TDataContext> : ControllerBase where TDataContext : DataContextBase
        {

            // Get an instance of the generic repository
            protected readonly IGenericRepository<TDataContext> Repository;

            // Constructor 
            public LMGControllerBase(IGenericRepository<TDataContext> repository)
            {
                Repository = repository;
            }

            // Delete
            [HttpDelete]
            [Route("deleteById/{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                // Get obj by id
                var obj = await Repository.GetByIdAsync(id);

                // If obj doesn't exist
                if (obj == null)
                {
                    // Return error message
                    return BadRequest("Id does not exist in database.");
                }

                // If obj exists in db, delete it
                await Repository.Delete(id);

                // Save it 
                await Repository.SaveRepoAsync();

                return Ok(obj);
            }

            // Get all records in the db.
            [HttpGet]
            [Route("getAll")]
            public async Task<IActionResult> GetAll()
            {
                // Find how many rows are availabe.
                return Ok(await Repository.GetAllAsync(0, 5));
            }

            // Get By Id
            [HttpGet]
            [Route("getById/{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                // Get object from the db
                var obj = await Repository.GetByIdAsync(id);

                // If no object was pulled
                if (obj == null)
                {
                    // Return 400 code and put message in response body
                    return BadRequest("Id does not exist in databse.");
                }

                // Return object 
                return Ok(obj);
            }

            // Insert
            [HttpPost]
            [Route("insert")]
            public void Insert(TDataContext obj)
            {
                Repository.Insert(obj);
                Repository.SaveRepoAsync();
            }

            // Insert collection
            [HttpPost]
            [Route("insertCollection")]
            public async Task InsertCollection(IEnumerable<TDataContext> obj)
            {
                await Repository.InsertCollection(obj);
                await Repository.SaveRepoAsync();
            }

            // Update
            [HttpPut]
            [Route("updateById/{id}")]
            public async void /*Task<IActionResult>*/ Update(TDataContext obj)
            {

                // Update by Id
                Repository.UpdateById(obj);

                await Repository.SaveRepoAsync();

                // Return object 
                // return Ok(obj);
            }
        }
    }
}
