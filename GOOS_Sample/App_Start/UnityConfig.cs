using System.Web.Mvc;
using GOOS_Sample.Models;
using GOOS_Sample.Repository;
using GOOS_Sample.Services;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

namespace GOOS_Sample
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            container.RegisterType<IBudgetService, BudgetService>();
            container.RegisterType<IRepository<Budgets>, BudgetRepository>();
        }
    }
}