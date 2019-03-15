using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessibilityDemo
{
public interface IAccessibilityRule
{
    IEnumerable<AccessibilityViolation> Check(IWebDriver driver);
    string Description { get; }
}
}
