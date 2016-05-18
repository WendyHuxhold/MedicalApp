using MedicalApp.Infrastructure;
using MedicalApp.Models;
using MedicalApp.Services.Models;
using MedicalApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalApp.Services
{
    public class ExpenseService
    {
        private ExpenseRepository _expRepo;
        private UserRepository _userRepo;
        private CategoryRepository _catRepo;

        public ExpenseService(ExpenseRepository expRepo, UserRepository userRepo, CategoryRepository catRepo)
        {
            _expRepo = expRepo;
            _userRepo = userRepo;
            _catRepo = catRepo;
        }

        public IEnumerable<ExpenseDTO> GetExpenseList(string currentUser)
        {
            return (from e in _expRepo.List(currentUser)
                    select new ExpenseDTO()
                    {
                        Id = e.Id,
                        ApptDate = e.ApptDate,
                        CategoryType = e.Category.CatType,
                        Cost = e.Cost,
                        Description = e.Description,
                        Physician = e.Physician

                    }).ToList();


        }

        public ExpenseDTO GetExpenseById(string currentUser, int id)
        {
            return (from e in _expRepo.Get(currentUser, id)
                   // where e.Id == id, where clauses only belong in the Repository
                    select new ExpenseDTO()
                    {
                        Id = e.Id,
                        ApptDate = e.ApptDate,
                        CategoryType = e.Category.CatType,
                        Cost = e.Cost,
                        Description = e.Description,
                        Physician = e.Physician
                    }).FirstOrDefault();
        }

        public void PostExpense(ExpenseDTO expense)
        {
            var newExpense = new Expense
            {
                Patient = (from p in _userRepo.List()
                           where p.FirstName == expense.FirstName && p.LastName == expense.LastName
                           select p).FirstOrDefault(),
                ApptDate = expense.ApptDate,
                Cost = expense.Cost.Value,
                Description = expense.Description,
                Physician = expense.Physician,
                Category = (from c in _catRepo.List()
                            where c.CatType == expense.CategoryType
                            select c).FirstOrDefault()
            };
            _expRepo.AddExpense(newExpense);
        }
    }
}
