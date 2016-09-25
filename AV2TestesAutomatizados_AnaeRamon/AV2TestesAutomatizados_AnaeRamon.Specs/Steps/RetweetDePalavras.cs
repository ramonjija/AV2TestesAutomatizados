using System;
using TechTalk.SpecFlow;

namespace AV2TestesAutomatizados_AnaeRamon.Specs.Steps
{
    [Binding]
    public class RetweetDePalavras
    {
        [Given(@"que ja realizei minha busca pelas palavras que quero")]
        public void DadoQueJaRealizeiMinhaBuscaPelasPalavrasQueQuero()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"que esqueci que ja retweetei uma palavra e chamo novamente o boot para relizar o retweet de novo")]
        public void DadoQueEsqueciQueJaRetweeteiUmaPalavraEChamoNovamenteOBootParaRelizarORetweetDeNovo()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"o sistema deve mostrar quais tweets foram retweetados")]
        public void EntaoOSistemaDeveMostrarQuaisTweetsForamRetweetados()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"retweetar tudo automaticamente")]
        public void EntaoRetweetarTudoAutomaticamente()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"o sistema deve exibir uma mensagem de erro na hora de realizar a ação de retweet")]
        public void EntaoOSistemaDeveExibirUmaMensagemDeErroNaHoraDeRealizarAAcaoDeRetweet()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
