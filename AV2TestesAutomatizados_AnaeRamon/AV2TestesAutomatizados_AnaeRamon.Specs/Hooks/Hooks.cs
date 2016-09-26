using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace AV2TestesAutomatizados_AnaeRamon.Specs.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private IWebDriver driver;

        [BeforeScenario]
        public void BeforeScenario()
        {
            try
            {
                driver = new FirefoxDriver();
                driver.Navigate().GoToUrl("https://twitter.com/grupoanaeramon");


            }
            catch (Exception ex)
            {
                
                throw;
            }
            
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
            
        }
    }
}
