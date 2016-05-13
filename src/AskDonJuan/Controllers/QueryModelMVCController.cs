using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using AskDonJuan.Models;

namespace AskDonJuan.Controllers
{
    public class QueryModelMVCController : Controller
    {
        private ApplicationDbContext _context;

        public QueryModelMVCController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: QueryModelMVC
        public IActionResult Index()
        {
            return View(_context.QueryModel.ToList());
        }

        // GET: QueryModelMVC/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            QueryModel queryModel = _context.QueryModel.Single(m => m.QueryKey == id);
            if (queryModel == null)
            {
                return HttpNotFound();
            }

            return View(queryModel);
        }

        // GET: QueryModelMVC/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QueryModelMVC/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(QueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                _context.QueryModel.Add(queryModel);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(queryModel);
        }

        // GET: QueryModelMVC/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            QueryModel queryModel = _context.QueryModel.Single(m => m.QueryKey == id);
            if (queryModel == null)
            {
                return HttpNotFound();
            }
            return View(queryModel);
        }

        // POST: QueryModelMVC/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(QueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                _context.Update(queryModel);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(queryModel);
        }

        // GET: QueryModelMVC/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            QueryModel queryModel = _context.QueryModel.Single(m => m.QueryKey == id);
            if (queryModel == null)
            {
                return HttpNotFound();
            }

            return View(queryModel);
        }

        // POST: QueryModelMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            QueryModel queryModel = _context.QueryModel.Single(m => m.QueryKey == id);
            _context.QueryModel.Remove(queryModel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
