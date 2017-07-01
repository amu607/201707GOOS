using System;
using System.Text;
using System.Collections.Generic;
using GOOS_Sample.Models;
using GOOS_Sample.Models.ViewModels;
using GOOS_Sample.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using GOOS_Sample.Repository;

namespace GOOS_SampleTests.Services
{
    /// <summary>
    /// BudgetServiceTest 的摘要描述
    /// </summary>
    [TestClass]
    public class BudgetServiceTest
    {

        private BudgetService _budgetService;
        private IRepository<Budgets> _budgetRepositoryStub = Substitute.For<IRepository<Budgets>>();
        [TestMethod()]
        public void CreateTest_should_invoke_repository_one_time()
        {
            this._budgetService = new BudgetService(_budgetRepositoryStub);
            var model = new BudgetAddViewModel { Amount = 2000, Month = "2017-02" };
            this._budgetService.Create(model);
            _budgetRepositoryStub.Received()
                .Save(Arg.Is<Budgets>(x => x.Amount == 2000 && x.YearMonth == "2017-02"));
        }
    }
}
