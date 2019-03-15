using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AccessibilityDemo.Rules
{
    public class AriaRolesRule : IAccessibilityRule
    {
        public string Description => "Ensures all elements with a role attribute use a valid value";

        public IEnumerable<AccessibilityViolation> Check(IWebDriver driver)
        {
            throw new NotImplementedException();
        }
    }
}
