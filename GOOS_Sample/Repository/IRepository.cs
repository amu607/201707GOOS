using System;
using System.Linq;
using GOOS_Sample.Models;

namespace GOOS_Sample.Repository
{
    public interface IRepository<T>
    {
        void Save(T entity);

        T Read(Func<T, bool> predicate);
    }

    public class BudgetRepository : IRepository<Budgets>
    {
        public void Save(Budgets entity)
        {

            using (var dbcontext = new Entities())
            {
                var budgetFromDb = dbcontext.Budgets
                    .FirstOrDefault(x => x.YearMonth == entity.YearMonth);

                if (budgetFromDb == null)
                {
                    dbcontext.Budgets.Add(entity);
                }
                else
                {
                    budgetFromDb.Amount = entity.Amount;
                }

                dbcontext.SaveChanges();
            }
        }

        public Budgets Read(Func<Budgets, bool> predicate)
        {
            using (var dbcontext = new Entities())
            {
                var budget = dbcontext.Budgets.FirstOrDefault(predicate);
                return budget;
            }
        }
    }
}