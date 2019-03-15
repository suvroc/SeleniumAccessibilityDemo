using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AccessibilityDemo.Rules
{
    class ButtonRule : IAccessibilityRule
    {
        public string Description => throw new NotImplementedException();

        public IEnumerable<AccessibilityViolation> Check(IWebDriver driver)
        {
            return driver.FindElements(By.TagName("button"))
                .Concat(driver.FindElements(By.CssSelector("[role='button']")))
                .Concat(driver.FindElements(By.CssSelector("input[type='button']")))
                .Concat(driver.FindElements(By.CssSelector("input[type='submit']")))
                .Concat(driver.FindElements(By.CssSelector("input[type='reset']")))
                .Where(x => x.GetAttribute("aria-label") == "")
                .Select(x => new AccessibilityViolation()
                {
                    Element = x,
                    Violation = Description
                });
        }
    }
}

/*

Ensure that each<button> element and elements with role = "button" have one of the following characteristics:

    Inner text that is discernible to screen reader users.
    Non-empty aria-label attribute.
    aria-labelledby pointing to element with text which is discernible to screen reader users (i.e.not display: none; or aria-hidden="true".
    role="presentation" or role = "none"(ARIA 1.1) and is not in tab order(tabindex= "-1").

Ensure that<input type="button">s have one of the following characteristics:

    Non-empty value attribute.
    Non-empty aria-label attribute.
    aria-labelledby pointing to element with text which is discernible to screen reader users (i.e.not display: none; or aria-hidden="true".

Ensure that<input type="submit">, <input type = "reset" > have one of the following characteristics:

    Non-empty aria-label attribute.
    aria-labelledby pointing to element with text which is discernible to screen reader users (i.e.not display: none; or aria-hidden="true".
    Non-empty or unspecified value attribute.Browsers will give reset and submit buttons a default value so long as the value attribute is not specified.

*/
