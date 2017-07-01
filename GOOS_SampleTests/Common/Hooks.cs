using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAutomation;
using TechTalk.SpecFlow;

namespace GOOS_SampleTests.Common
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [Scope (Tag = "web")]
        public static void StartBrowker()
        {
            SeleniumWebDriver.Bootstrap(SeleniumWebDriver.Browser.Chrome);
        }
    }
}
