using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CatType { get; set;}
        public IList<Expense> Expenses { get; set; }
    }
}
