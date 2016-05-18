using MedicalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalApp.Infrastructure
{
    public class ExpenseRepository
    {
        ApplicationDbContext _db;
        public ExpenseRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IQueryable<Expense> List(string currentUser)
        {
            return from e in _db.Expenses
                   where e.Patient.UserName == currentUser
                   select e;
        }

        public IQueryable<Expense> Get(string currentUser, int id)
        {
            return from e in _db.Expenses
                   where e.Patient.UserName == currentUser && e.Id == id
                   select e;
        }

        public void AddExpense(Expense expense)
        {
            _db.Expenses.Add(expense);
            _db.SaveChanges();
        }
    }
}
