using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using System.Diagnostics;
using WatiN.Core;


namespace AV2TestesAutomatizados_AnaeRamon.Specs.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        
        [BeforeScenario]
        public void BeforeScenario()
        {
            try
            {
                var browser = new FireFox("https://twitter.com/grupoanaeramon");
                
            }
            catch (Exception ex)
            {
                
                throw;
            }
            
        }

        [AfterScenario]
        public void AfterScenario()
        {
        }
    }
}
