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
using AV2Database;
using AV2Database.Model;
using AV2TestesAutomatizados_AnaeRamon;
using System.Data.Entity;

namespace AV2TestesAutomatizados_AnaeRamon.Specs.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private DbContextTransaction context;
        [BeforeScenario]
        public void BeforeScenario()
        {
            //new UnitOfWork(new DBPalavrasContext()).Dispose();
            //context = new DBPalavrasContext().Database.BeginTransaction();
            //RetweetDePalavrasChavesNoTwiterSteps.context = context;
            //BuscaDePalavrasChave.context = context;
            //GerenciarPalavrasCadastradasSteps.context = context;
            /*foreach (var palavra in context.Palavras)
            {
                context.Palavras.Remove(palavra);
            }*;*/
        }

        [AfterScenario]
        public void AfterScenario()
        {
        }
    }
}
