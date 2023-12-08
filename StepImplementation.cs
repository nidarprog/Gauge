using FluentAssertions;
using Gauge.CSharp.Lib;
using Gauge.CSharp.Lib.Attribute;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace netcore.template
{
    public class StepImplementation
    {
        private IWebDriver driver;

        [Step("Navigate to the search engine")]
        public void NavigateToSearchEngine()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.example.com");
        }

        [Step("Enter \"Gauge framework\" in the search bar")]
        public void EnterSearchTerm()
        {
            IWebElement searchBox = driver.FindElement(By.Name("q"));
            searchBox.SendKeys("Gauge framework");
        }

        [Step("Click on the search button")]
        public void ClickSearchButton()
        {
            IWebElement searchButton = driver.FindElement(By.Name("btnK"));
            searchButton.Click();
        }

        [Step("Verify that search results contain \"Gauge\"")]
        public void VerifySearchResultsContainGauge()
        {
            var pageSource = driver.PageSource;
            pageSource.Should().Contain("Gauge", "Search results should contain \"Gauge\"");
            driver.Quit();
        }
    }
}
