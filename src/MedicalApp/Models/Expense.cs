using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalApp.Models
{
    public class Expense
    {
        public int Id { get; set; }

        public string PatientId { get; set; }
        [ForeignKey("PatientId")]
        public ApplicationUser Patient { get; set; }

        public DateTime ApptDate { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public decimal Cost { get; set; }

        public string Description { get; set; }

        public string Physician { get; set; }
    }
}
