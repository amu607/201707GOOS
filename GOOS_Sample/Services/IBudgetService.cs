using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GOOS_Sample.Models;
using GOOS_Sample.Models.ViewModels;

namespace GOOS_Sample.Services
{
    public interface IBudgetService
    {
        void Create(BudgetAddViewModel model);
    }

    public class BudgetService : IBudgetService
    {
        public void Create(BudgetAddViewModel model)
        {
            using (var dbcontext = new Entities())
            {
                var budget = new Budgets()
                {
                    Amount = model.Amount,
                    YearMonth = model.Month
                };
                dbcontext.Budgets.Add(budget);
                dbcontext.SaveChanges();
            }
        }
    }
}