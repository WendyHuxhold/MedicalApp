using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using MedicalApp.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalApp.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private ApplicationDbContext _db;

        public CategoriesController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        // GET: api/categories
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return (from c in _db.Categories
                    select c.CatType).ToList();
        }
    }
}
