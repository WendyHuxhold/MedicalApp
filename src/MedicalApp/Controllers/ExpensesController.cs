using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using MedicalApp.Models;
using MedicalApp.ViewModels;
using MedicalApp.Services;
using MedicalApp.Services.Models;
using Microsoft.AspNet.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860
//api/expenses
namespace MedicalApp.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ExpensesController : Controller
    {
        //public ApplicationDbContext _db;

        //public ExpensesController(ApplicationDbContext db)
        //{
        //    _db = db;
        //}

        private ExpenseService _expService;
        public ExpensesController(ExpenseService expService)
        {
            _expService = expService;
        }
        
        // GET: api/expenses
        [HttpGet]
        public IEnumerable<ExpenseDTO> Get()
        {
            //return (from e in _db.Expenses
            //        select new ExpenseDTO() {
            //            Id = e.Id,
            //            ApptDate = e.ApptDate,
            //            CategoryType = e.Category.CatType,
            //            Cost = e.Cost,
            //            Description = e.Description,
            //            Physician = e.Physician

            //        }).ToList();
            return _expService.GetExpenseList(User.Identity.Name);
        }

        // GET api/expenses/5
        [HttpGet("{id}")]
        public ExpenseDTO Get(int id)
        {
            //return (from e in _db.Expenses
            //        where e.Id == id
            //        select e).FirstOrDefault();
            return _expService.GetExpenseById(User.Identity.Name, id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]ExpenseDTO expense)
        {
            //var newExpense = new Expense
            //{
            //    Patient = (from p in _db.Users
            //               where p.FirstName == expense.FirstName && p.LastName == expense.LastName
            //               select p).FirstOrDefault(),
            //    ApptDate = expense.ApptDate,
            //    Cost = expense.Cost,
            //    Description = expense.Description,
            //    Physician = expense.Physician,
            //    Category = (from c in _db.Categories
            //                where c.CatType == expense.CategoryType
            //                select c).FirstOrDefault()
            //};
            //_db.Expenses.Add(newExpense);
            //_db.SaveChanges();

            if (ModelState.IsValid)
            {
                _expService.PostExpense(expense);
                return Ok(expense);
            }
            return HttpBadRequest(ModelState);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
