using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AccessibilityDemo.Rules
{
public class DocumentTitleRule : IAccessibilityRule
{
    public string Description => "Documents must have <title> element to aid in navigation";

    public IEnumerable<AccessibilityViolation> Check(IWebDriver driver)
    {
        if (driver.FindElements(By.TagName("title")).Count == 0)
        {
            return new List<AccessibilityViolation>() {
                new AccessibilityViolation()
                {
                    Element = null,
                    Violation = Description
                }
            };
        }
        return Enumerable.Empty<AccessibilityViolation>();
    }
}
}
