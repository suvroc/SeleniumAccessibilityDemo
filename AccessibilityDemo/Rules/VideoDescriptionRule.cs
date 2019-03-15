using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AccessibilityDemo.Rules
{
    public class VideoDescriptionRule : IAccessibilityRule
    {
        public string Description => "Ensures <video> elements have audio descriptions";

        public IEnumerable<AccessibilityViolation> Check(IWebDriver driver)
        {
            return driver.FindElements(By.TagName("video")).Where(x => x.FindElements(By.TagName("track")).Count != 0)
                .Select(x => new AccessibilityViolation()
                {
                    Element = x,
                    Violation = Description
                });
        }
    }
}
