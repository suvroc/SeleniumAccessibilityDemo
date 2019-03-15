using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AccessibilityDemo.Rules
{
    public class BlinkRule : IAccessibilityRule
    {
        public string Description => "Ensures <blink> elements are not used";

        public IEnumerable<AccessibilityViolation> Check(IWebDriver driver)
        {
            return driver.FindElements(By.TagName("blink"))
                .Select(x => new AccessibilityViolation()
                {
                    Element = x,
                    Violation = Description
                });
        }
    }
}
