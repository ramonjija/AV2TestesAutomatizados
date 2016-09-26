using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AV2TestesAutomatizados_AnaeRamon.Specs.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        IWebDriver driver;
        [BeforeScenario]
        public void BeforeScenario()
        {
            try
            {
                driver = new ChromeDriver();
                driver.Navigate().GoToUrl("http://www.twitter.com.br/grupoanaeramon/");
            }
            catch (Exception ex)
            {
                
                throw;
            }
            
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Close();
        }
    }
}
