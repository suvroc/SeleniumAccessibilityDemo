using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AccessibilityDemo.Rules
{
    public class AriaHiddenBodyRule : IAccessibilityRule
    {
        public string Description => "Ensures aria-hidden='true' is not present on the document body";

        public IEnumerable<AccessibilityViolation> Check(IWebDriver driver)
        {
            var element = driver.FindElement(By.TagName("body"));
            
            if (element != null && element.GetAttribute("aria-hidden") == "true")
            {
                return new List<AccessibilityViolation>()
                {
                    new AccessibilityViolation()
                    {
                        Element = element,
                        Violation = Description
                    }
                };
            }
            return Enumerable.Empty<AccessibilityViolation>();
        }
    }
}
