using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNet.Identity;
using System.Security.Claims;

namespace MedicalApp.Models
{
    public class SampleData
    {
        public async static void Initialize(IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetService<ApplicationDbContext>();

            var categories = new List<Category>()
            {
                new Category() { CatType = "Medical" },
                new Category() { CatType = "Optical" },
                new Category() { CatType = "Dental" },
                new Category() { CatType = "Chiropractic" },
                new Category() { CatType = "Physical Therapy" },
                new Category() { CatType = "Pharmacy" }
            };

            for (int i = 0; i < categories.Count; i++)
            {
                var cat = categories[i];
                var dbCat = db.Categories.FirstOrDefault(cm => cm.CatType == cat.CatType);
                //the below statement does the same as the statement above
                //var dbMake = (from cm in db.Categories
                //              where cm.CatType == cat.CatType
                //              select cm).FirstOrDefault();

                if (dbCat == null)
                {
                    db.Categories.Add(cat);
                }
                else
                {
                    categories[i] = dbCat;
                }
            }
            db.SaveChanges();

            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            var wendy = await userManager.FindByNameAsync("WendyHuxhold");
            if (wendy == null)
            {
                //create user
                wendy = new ApplicationUser
                {
                    UserName = "WendyHuxhold",
                    Email = "wlhinoz@gmail.com",
                    FirstName = "Wendy",
                    LastName = "Huxhold"

                };
                await userManager.CreateAsync(wendy, "Secret123!");

                //add claims
                await userManager.AddClaimAsync(wendy, new Claim("IsAdmin", "true"));
            }

            #region expenses
            var expenses = new List<Expense>()
            {
                new Expense() {
                    Patient = wendy,
                    ApptDate = DateTime.Parse("1/12/2016"),
                    Cost = 300.00m,
                    Physician =  "Dr. Smith",
                    Description = "knee x-rays",
                    CategoryId = categories.FirstOrDefault(cm => cm.CatType == "Medical").Id
                },
                new Expense() {
                    Patient = wendy,
                    ApptDate = DateTime.Parse("2/20/2016"),
                    Cost = 30.00m,
                    Physician = "Dr. Skidmmore",
                    CategoryId = categories.FirstOrDefault(cm => cm.CatType == "Chiropractic").Id
                },
                    new Expense() {
                    Patient = wendy,
                    ApptDate = DateTime.Parse("3/10/2016"),
                    Cost = 30.00m,
                    Physician = "Dr. Skidmmore",
                    CategoryId = categories.FirstOrDefault(cm => cm.CatType == "Chiropractic").Id
                    },
                    new Expense() {
                    Patient = wendy,
                    ApptDate = DateTime.Parse("3/30/2016"),
                    Cost = 180.00m,
                    Physician =  "Dr. Flanigan",
                    Description = "Teeth Cleaning",
                    CategoryId = categories.FirstOrDefault(cm => cm.CatType == "Dental").Id
                },
                    new Expense() {
                    Patient = wendy,
                    ApptDate = DateTime.Parse("4/15/2016"),
                    Cost = 75.00m,
                    Physician = "Dr. Robinson",
                    Description = "Eye exam",
                    CategoryId = categories.FirstOrDefault(cm => cm.CatType == "Optical").Id
                    },
                    new Expense()
                    {
                        Patient = wendy,
                        ApptDate = DateTime.Parse("4/28/2016"),
                        Cost = 50.00m,
                        Physician = "Dr. Laura",
                        Description = "Annual physical",
                        CategoryId = categories.FirstOrDefault(cm => cm.CatType == "Medical").Id
                    }//,
                    //new Expense()
                    //{
                    //    Patient = wendy,
                    //    ApptDate = DateTime.Parse("5/10/2016"),
                    //    Cost = 150.00m,
                    //    Physician = "Dr. Bolinger",
                    //    Description = "elbow rehab",
                    //    CategoryId = categories.FirstOrDefault(cm => cm.CatType == "Physical Therapy").Id
                    //}
            };
            for (int i = 0; i < expenses.Count; i++)
            {
                var exp = expenses[i];
                //var comparevar = (expenses[i].ApptDate).ToString() + (expenses[i].Cost).ToString();
                //var comparevarDb = (db.Expenses[i].ApptDate).ToString() + (expenses[i].Cost).ToString();
                //var dbExp = db.Expenses.FirstOrDefault(cm => cm.comparevar == exp.ShortDescription);
                //the below statement does the same as the statement above
                var dbExp = (from cm in db.Expenses
                             where cm.ApptDate == exp.ApptDate && cm.Cost == exp.Cost
                             select cm).FirstOrDefault();

                if (dbExp == null)
                {
                    db.Expenses.Add(exp);
                }
                else
                {
                    expenses[i] = dbExp;
                }
            }
            db.SaveChanges();
            #endregion

        }
    }
}
