using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AccessibilityDemo.Rules
{
    public class ListItemRule : IAccessibilityRule
    {
        public string Description => "All list items (<li>) must be contained within <ul> or <ol> parent elements.";

        public IEnumerable<AccessibilityViolation> Check(IWebDriver driver)
        {
            return driver.FindElements(By.TagName("ul"))
                .Concat(driver.FindElements(By.TagName("ol")))

                .Where(x => x.FindElements(By.XPath("*")).Any(y => y.TagName != "li"))
                .Select(x => new AccessibilityViolation()
                {
                    Element = x,
                    Violation = Description
                });                
        }
    }
}
