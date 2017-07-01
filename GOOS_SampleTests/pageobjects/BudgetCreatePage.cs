using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAutomation;
using GOOS_SampleTests.steps;

namespace GOOS_SampleTests.pageobjects
{
    public class BudgetCreatePage : PageObject<BudgetCreatePage>
    {

        public BudgetCreatePage(FluentTest test) : base(test)
        {
            this.Url = $"{PageContext.Domain}/budget/add";
        }

        public BudgetCreatePage Amount(int amount)
        {
            I.Enter(amount.ToString()).In("#amount");
            return this;
        }

        public BudgetCreatePage Month(string yearMonth)
        {
            I.Enter(yearMonth).In("#month");
            return this;
        }

        public void AddBudget()
        {
            I.Click("input[type=\"submit\"]");
        }

        public void ShouldDisplay(string message)
        {
            I.Assert.Text(message).In("#message");
        }
    }
}
