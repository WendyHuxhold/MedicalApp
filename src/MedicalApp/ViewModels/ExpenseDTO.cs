using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalApp.ViewModels
{
    public class ExpenseDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime ApptDate { get; set; }
        public string CategoryType { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public string Physician { get; set; }
    }
}