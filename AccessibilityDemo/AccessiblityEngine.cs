using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessibilityDemo
{
public class AccessiblityEngine
{
    private IWebDriver Driver { get; set; }
    private AccessibilityTestConfiguration Configuration { get; set; }

    public AccessiblityEngine(IWebDriver driver, AccessibilityTestConfiguration configuration)
    {
        this.Driver = driver;
        this.Configuration = configuration;
    }

    public IEnumerable<AccessibilityViolation> Check()
    {
        List<AccessibilityViolation> result = new List<AccessibilityViolation>();

        foreach (var rule in Configuration.Rules)
        {
            result.AddRange(rule.Check(Driver));
        }

        return result;
    }
}
}
