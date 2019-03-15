using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AccessibilityDemo.Rules
{
public class AccessKeysRule : IAccessibilityRule
{
    public string Description {  get { return "Every accesskey attribute value is unique"; } }

    public IEnumerable<AccessibilityViolation> Check(IWebDriver driver)
    {
        var elements = driver.FindElements(By.CssSelector("*[accesskey]"));

        var invalidTexts = elements.Select(x => x.GetAttribute("accesskey")).GroupBy(n => n).Where(c => c.Count() > 1).Select(x => x.Key);

        return elements.Where(x => invalidTexts.Contains(x.GetAttribute("accesskey")))
            .Select(x => new AccessibilityViolation()
            {
                Element = x,
                Violation = Description
            });
    }
}
}
