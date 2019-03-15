using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AccessibilityDemo.Rules
{
    public class TabIndexRule : IAccessibilityRule
    {
        public string Description => "Elements should not have tabindex greater than zero";

        public IEnumerable<AccessibilityViolation> Check(IWebDriver driver)
        {
            return driver.FindElements(By.CssSelector("[tabindex]")).Where(x => int.Parse(x.GetAttribute("tabindex")) > 0)
                .Select(x => new AccessibilityViolation()
                {
                    Element = x,
                    Violation = Description
                });
        }
    }
}
