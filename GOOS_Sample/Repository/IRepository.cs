using GOOS_Sample.Models;

namespace GOOS_Sample.Repository
{
    public interface IRepository<T>
    {
        void Save(T entity);
    }

    public class BudgetRepository : IRepository<Budgets>
    {
        public void Save(Budgets entity)
        {
            using (var dbcontext = new Entities())
            {
                dbcontext.Budgets.Add(entity);
                dbcontext.SaveChanges();
            }
        }
    }
}