using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using GOOS_Sample.Controllers;
using GOOS_Sample.Models;
using GOOS_Sample.Models.ViewModels;
using GOOS_Sample.Services;
using GOOS_SampleTests.Common;
using GOOS_SampleTests.DataModel;
using Microsoft.Practices.Unity;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace GOOS_SampleTests.steps
{
    [Binding]
    [Scope(Feature = "BudgetController")]
    public class BudgetControllerSteps
    {
        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <remarks>
        /// 也可以在宣告的時侯直接new，因為每次跑Scenario都會觸發new
        /// </remarks>
        private BudgetController _budgetController;

        [BeforeScenario()]
        public void BeforeScenario()
        {
           _budgetController = Hooks.UnityContainer.Resolve<BudgetController>();
        }

        [When(@"add a budget")]
        public void WhenAddABudget(Table table)
        {
            var model = table.CreateInstance<BudgetAddViewModel>();
            var result = this._budgetController.Add(model);

            ScenarioContext.Current.Set<ActionResult>(result);
        }
        
        [Then(@"ViewBag should have a message for adding successfully")]
        public void ThenViewBagShouldHaveAMessageForAddingSuccessfully()
        {

            var result = ScenarioContext.Current.Get<ActionResult>() as ViewResult;
            string message = result.ViewBag.Message;
            message.Should().Be(GetAddingSuccessfullyMessage());
        }

        /// <summary>
        /// 訊息驗證不寫在feature而且抽出來是為了多國語系的情境
        /// </summary>
        /// <returns></returns>
        private static string GetAddingSuccessfullyMessage()
        {
            return "added successfully";
        }

        [Then(@"it should exist a budget record in budget table")]
        public void ThenItShouldExistABudgetRecordInBudgetTable(Table table)
        {
            using (var dbcontext = new DataModelForTest())
            {
                var budget = dbcontext.Budgets
                    .FirstOrDefault();
                budget.Should().NotBeNull();
                table.CompareToInstance(budget);
            }
        }
    }
}
