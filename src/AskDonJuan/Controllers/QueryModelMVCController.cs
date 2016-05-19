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
            return View();
        }
        
        
        // GET: QueryModelMVC
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


                return RedirectToAction("Index");
            }
            return View(queryModel);
        }


    }
}
