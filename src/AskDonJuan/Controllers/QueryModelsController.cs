using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using AskDonJuan.Models;

namespace AskDonJuan.Controllers
{
    [Produces("application/json")]
    [Route("api/QueryModels")]
    public class QueryModelsController : Controller
    {
        private ApplicationDbContext _context;

        public QueryModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/QueryModels
        [HttpGet]
        public IEnumerable<QueryModel> GetQueryModel()
        {
            return _context.QueryModel;
        }

        // GET: api/QueryModels/5
        [HttpGet("{id}", Name = "GetQueryModel")]
        public IActionResult GetQueryModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            QueryModel queryModel = _context.QueryModel.Single(m => m.QueryKey == id);

            if (queryModel == null)
            {
                return HttpNotFound();
            }

            return Ok(queryModel);
        }

        // PUT: api/QueryModels/5
        [HttpPut("{id}")]
        public IActionResult PutQueryModel(int id, [FromBody] QueryModel queryModel)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != queryModel.QueryKey)
            {
                return HttpBadRequest();
            }

            _context.Entry(queryModel).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QueryModelExists(id))
                {
                    return HttpNotFound();
                }
                else
                {
                    throw;
                }
            }

            return new HttpStatusCodeResult(StatusCodes.Status204NoContent);
        }

        // POST: api/QueryModels
        [HttpPost]
        public IActionResult PostQueryModel([FromBody] QueryModel queryModel)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.QueryModel.Add(queryModel);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (QueryModelExists(queryModel.QueryKey))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetQueryModel", new { id = queryModel.QueryKey }, queryModel);
        }

        // DELETE: api/QueryModels/5
        [HttpDelete("{id}")]
        public IActionResult DeleteQueryModel(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            QueryModel queryModel = _context.QueryModel.Single(m => m.QueryKey == id);
            if (queryModel == null)
            {
                return HttpNotFound();
            }

            _context.QueryModel.Remove(queryModel);
            _context.SaveChanges();

            return Ok(queryModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QueryModelExists(int id)
        {
            return _context.QueryModel.Count(e => e.QueryKey == id) > 0;
        }
    }
}