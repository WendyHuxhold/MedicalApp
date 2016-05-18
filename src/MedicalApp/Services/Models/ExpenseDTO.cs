using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalApp.Services.Models
{
    public class ExpenseDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public DateTime ApptDate { get; set; }

        [Required]
        public string CategoryType { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal? Cost { get; set; }

        public string Description { get; set; }

        public string Physician { get; set; }
    }
}