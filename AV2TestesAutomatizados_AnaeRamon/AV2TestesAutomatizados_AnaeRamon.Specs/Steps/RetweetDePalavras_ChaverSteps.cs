using System;
using System.Diagnostics;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace AV2TestesAutomatizados_AnaeRamon.Specs.Steps
{
    [Binding]
    public class RetweetDePalavras_ChaverSteps
    {
        
        #region retweet de palavras cadastradas 
        [Given(@"que ja realizei minha busca pelas palavras que quero")]
        public void DadoQueJaRealizeiMinhaBuscaPelasPalavrasQueQuero()
        {

        }

        [Then(@"o sistema deve mostrar quais tweets foram retweetados")]
        public void EntaoOSistemaDeveMostrarQuaisTweetsForamRetweetados()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"retweetar tudo automaticamente")]
        public void EntaoRetweetarTudoAutomaticamente()
        {
        }
        #endregion
        #region retweete duas vezes de uma palavra 
        [Given(@"que esqueci que retweetei uma palavra e chamo novamente o boot para relizar o retweet de novo")]
        public void DadoQueEsqueciQueRetweeteiUmaPalavraEChamoNovamenteOBootParaRelizarORetweetDeNovo()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"o sistema deve exibir uma mensagem de erro na hora de realizar a ação de retweet")]
        public void EntaoOSistemaDeveExibirUmaMensagemDeErroNaHoraDeRealizarAAcaoDeRetweet()
        {
            ScenarioContext.Current.Pending();
        }
        #endregion

    }
}
