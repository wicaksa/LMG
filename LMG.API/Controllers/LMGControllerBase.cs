using LMG.BLL;
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
        public abstract class LMGControllerBase<TDataModel, TDataContext> : ControllerBase where TDataContext : DataContextBase
        {

            // Get an instance of the generic repository
            protected readonly GenericRepository<TDataContext> Repository;
            private GenericBLL<TDataModel,TDataContext> _BLL;

            // Constructor 
            public LMGControllerBase(GenericRepository<TDataContext> repository)
            {
                Repository = repository;
                _BLL = new GenericBLL<TDataModel, TDataContext>(Repository);
            }

            // Delete
            [HttpDelete]
            [Route("deleteById/{id}")]
            public async Task Delete(int id)
            {
                // Get obj by id
                /*
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
                */
                await _BLL.Delete(id);
                await Repository.SaveRepoAsync();
            }

            // Get all records in the db.
            [HttpGet]
            [Route("getAll")]
            public async Task<ICollection<TDataModel>> GetAll()
            {
                // Find how many rows are availabe.
                //return Ok(await Repository.GetAllAsync(0, 5));
                return await _BLL.GetAll();
            }

            // Get By Id
            [HttpGet]
            [Route("getById/{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                // Get object from the db
                /*
                var obj = await Repository.GetByIdAsync(id);

                // If no object was pulled
                if (obj == null)
                {
                    // Return 400 code and put message in response body
                    return BadRequest("Id does not exist in databse.");
                }

                // Return object 
                return Ok(obj);
                */
                var obj = await _BLL.GetById(id);
                if(obj == null)
                {
                    return NotFound("Invalid ID");
                }
                return Ok(obj);
            }

            // Insert
            [HttpPost]
            [Route("insert")]
            public void Insert([FromBody] TDataModel obj)
            {
                /*
                Repository.Insert(obj);
                Repository.SaveRepoAsync();
                */
                _BLL.Insert(obj);
                Repository.SaveRepoAsync();
            }

            // Insert collection
            [HttpPost]
            [Route("insertCollection")]
            public async Task InsertCollection(IEnumerable<TDataModel> obj)
            {
                /*
                await Repository.InsertCollection(obj);
                await Repository.SaveRepoAsync();
                */

                await _BLL.InsertCollection(obj);
                await Repository.SaveRepoAsync();
            }

            // Update
            /*
            [HttpPut]
            [Route("update")]
            public async Task<IActionResult> Update(TDataContext obj)
            {
                // Update
                await Repository.UpdateById(obj);
                await Repository.SaveRepoAsync();

                // Return object 
                return Ok(obj);
            }
            */

            // Update
            [HttpPatch]
            [Route("updateById")]
            public async Task Update(int id, TDataModel obj)
            {
                /*
                Repository.Update(obj);
                await Repository.SaveRepoAsync();
                Ok();
                */
                
                await _BLL.Update(id, obj);
                await Repository.SaveRepoAsync();
            }
        }
    }
}
