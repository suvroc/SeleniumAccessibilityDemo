using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessibilityDemo.Rules
{
    public class TestRule : IAccessibilityRule
    {
        public string Description => "Test";

        public IEnumerable<AccessibilityViolation> Check(IWebDriver driver)
        {
            return Enumerable.Empty<AccessibilityViolation>();
        }
    }
}
