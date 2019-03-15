using AccessibilityDemo.Rules;
using Globant.Selenium.Axe;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessibilityDemo
{
[TestFixture]
public class Tests
{
    [Test]
    public void Test()
    {
        var driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://www.google.com");

            AxeResult results = driver.Analyze();

            Assert.IsEmpty(results.Violations);

            driver.Close();
    }

        [Test]
        public void TestRules()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com");

            var engine = new AccessiblityEngine(driver, new AccessibilityTestConfiguration()
            {
                Rules = new List<IAccessibilityRule>()
                {
                    new TestRule(),
                    new AccessKeysRule(),
                    new AriaHiddenBodyRule(),
                    new BlinkRule(),
                    new ButtonRule(),
                    new DocumentTitleRule(),
                    new ListItemRule(),
                    new TabIndexRule(),
                    new ValidLangRule(),
                    new VideoDescriptionRule()
                }
            });

            var result = engine.Check();

            driver.Close();
        }
    }
}
