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

            var wasCreate = false;
            this._budgetService.Created += (sender, args) => { wasCreate = true; };
            this._budgetService.Create(model);

            _budgetRepositoryStub.Received()
                .Save(Arg.Is<Budgets>(x => x.Amount == 2000 && x.YearMonth == "2017-02"));

            Assert.IsTrue(wasCreate);
        }


        [TestMethod()]
        public void CreateTest_when_exist_record_should_update_budget()
        {
            this._budgetService = new BudgetService(_budgetRepositoryStub);

            var budgetFromDb = new Budgets { Amount = 999, YearMonth = "2017-02" };

            _budgetRepositoryStub.Read(Arg.Any<Func<Budgets, bool>>())
                .ReturnsForAnyArgs(budgetFromDb);

            var model = new BudgetAddViewModel { Amount = 2000, Month = "2017-02" };

            var wasUpdated = false;
            this._budgetService.Updated += (sender, args) => { wasUpdated = true; };

            this._budgetService.Create(model);

            _budgetRepositoryStub.Received()
                .Save(Arg.Is<Budgets>(x => x == budgetFromDb && x.Amount == 2000));


            Assert.IsTrue(wasUpdated);
        }
    }
}
