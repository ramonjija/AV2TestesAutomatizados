using System;
using TechTalk.SpecFlow;

namespace AV2TestesAutomatizados_AnaeRamon.Specs
{
    [Binding]
    public class BuscaDePalavrasChave
    {
        
        #region busca palavras chaves já cadastradas 
        [Given(@"que ja cadastrei a palavra ""(.*)""")]
        public void DadoQueJaCadastreiAPalavra(string p0)
        {
            ScenarioContext.Current.Pending();
        }
               
        [When(@"digito a opção de iniciar boot")]
        public void QuandoDigitoAOpcaoDeIniciarBoot()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"o sistema deve exibir uma mensagem de sucesso de busca no twitter")]
        public void EntaoOSistemaDeveExibirUmaMensagemDeSucessoDeBuscaNoTwitter()
        {
            ScenarioContext.Current.Pending();
        }
        #endregion
        #region Busca por palavra chave não cadastrada no twitter


        [Given(@"que esqueci de cadastrar uma palavra")]
        public void DadoQueEsqueciDeCadastrarUmaPalavra()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"o sistema deve exibir uma mensagem de erro de busca no twitter")]
        public void EntaoOSistemaDeveExibirUmaMensagemDeErroDeBuscaNoTwitter()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"pedir para o usuario cadastrar uma palavra")]
        public void EntaoPedirParaOUsuarioCadastrarUmaPalavra()
        {
            ScenarioContext.Current.Pending();
        }
        #endregion
    }
}
