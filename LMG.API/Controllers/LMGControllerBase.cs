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


            // Get all records in the db.
            [HttpGet]
            [Route("getAll")]
            public async Task<IActionResult> GetAll()
            {
                // Find how many rows are availabe.
                // Put like 3 for now
                return Ok(await Repository.GetAllAsync(0, 3));
            }

            // Get By Id Route
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

            /*
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

            */

            // Insert
            //[HttpPost]
            //[Route("api/{id}")]
            ///public async Task<IActionResult> Add()
            //{
            //    Repository.Insert
            // }

            // Update
            /*
            [HttpPut]
            [Route("updateById/{id}")]
            public async Task<IActionResult> Update(int id)
            {
                // Get obj by id
                var obj = await Repository.GetByIdAsync(id);

                // If obj doesn't exist
                if (obj == null)
                {
                    // Return error message
                    return BadRequest("Id does not exist in database.");
                }

                // Update by Id
                await Repository.UpdateById(id);

                // Save
                await Repository.SaveRepoAsync();

                // Return
                return Ok(obj);
            }

            */


            /*
             * 
            [HttpGet]
            [Route("Foobar/{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                return Ok(await Repository.GetByIdAsync(id));
            }

                */

        }
    }
}
