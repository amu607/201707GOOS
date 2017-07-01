using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GOOS_Sample.Models;
using GOOS_Sample.Models.ViewModels;
using GOOS_Sample.Repository;

namespace GOOS_Sample.Services
{
    public interface IBudgetService
    {
        void Create(BudgetAddViewModel model);
    }

    public class BudgetService : IBudgetService
    {
        private IRepository<Budgets> _budgeRepository;
 
        public BudgetService(IRepository<Budgets> budgetRepository)
        {
            _budgeRepository = budgetRepository;
        }

        public void Create(BudgetAddViewModel model)
        {
            var budget = new Budgets()
            {
                Amount = model.Amount,
                YearMonth = model.Month
            };
            _budgeRepository.Save(budget);
            //using (var dbcontext = new Entities())
            //{
            //  
            //    dbcontext.Budgets.Add(budget);
            //    dbcontext.SaveChanges();
            //}
        }
    }
}