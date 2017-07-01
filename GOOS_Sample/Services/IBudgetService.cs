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

        event EventHandler Created;

        event EventHandler Updated;
    }

    public class BudgetService : IBudgetService
    {
        private IRepository<Budgets> _budgetRepository;
 
        public BudgetService(IRepository<Budgets> budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }

        public void Create(BudgetAddViewModel model)
        {
            var budget = _budgetRepository.Read(x => x.YearMonth == model.Month);
            if (budget == null)
            {
                _budgetRepository.Save(new Budgets()
                { Amount = model.Amount, YearMonth = model.Month });

                var handler = Created;
                handler?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                budget.Amount = model.Amount;
                _budgetRepository.Save(budget);

                var handler = Updated;
                handler?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler Created;
        public event EventHandler Updated;
    }
}