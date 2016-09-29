using System;
using System.Diagnostics;
using System.Text;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Threading;

namespace AV2TestesAutomatizados_AnaeRamon.Specs
{
    [Binding]
    public class BuscaDePalavrasChave
    {
        private Process process;
        string retorno;

        #region busca palavras chaves já cadastradas 
        [Given(@"que ja cadastrei a palavra ""(.*)""")]
        public void DadoQueJaCadastreiAPalavra(string p0)
        {
            //ProcessStartInfo processStartInfo = new ProcessStartInfo(@"C:\vtex\ambiente\github\AV2TestesAutomatizados\AV2TestesAutomatizados_AnaeRamon\AV2TestesAutomatizados_AnaeRamon\bin\Ana\AV2TestesAutomatizados_AnaeRamon.exe");
            ProcessStartInfo processStartInfo = new ProcessStartInfo(@"C:\Users\Ramon\Documents\Github\AV2TestesAutomatizados\AV2TestesAutomatizados_AnaeRamon\AV2TestesAutomatizados_AnaeRamon\bin\RHome\AV2TestesAutomatizados_AnaeRamon.exe");
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.UseShellExecute = false;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.StandardOutputEncoding = Encoding.GetEncoding(850);
            process = Process.Start(processStartInfo);

            process.StandardInput.Write("2");
            process.StandardInput.Write(p0);


        }

        [When(@"digito a opção de iniciar boot")]
        public void QuandoDigitoAOpcaoDeIniciarBoot()
        {
            process.StandardInput.WriteLine("4");
        }

        [Then(@"o sistema deve exibir uma mensagem de sucesso de busca no twitter")]
        public void EntaoOSistemaDeveExibirUmaMensagemDeSucessoDeBuscaNoTwitter()
        {
            retorno = "";
            process.StandardInput.Close();
            retorno = process.StandardOutput.ReadToEnd();

            Assert.IsTrue(retorno.Contains("Palavra(s) buscadas com sucesso!"));

        }
        #endregion
        #region Busca por palavra chave não cadastrada no twitter

        [Given(@"que esqueci de cadastrar uma palavra e não possuo nenhuma outra cadastrada")]
        public void DadoQueEsqueciDeCadastrarUmaPalavraENaoPossuoNenhumaOutraCadastrada()
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo(@"C:\Users\Ramon\Documents\Github\AV2TestesAutomatizados\AV2TestesAutomatizados_AnaeRamon\AV2TestesAutomatizados_AnaeRamon\bin\RHome\AV2TestesAutomatizados_AnaeRamon.exe");
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.UseShellExecute = false;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.StandardOutputEncoding = Encoding.GetEncoding(850);
            process = Process.Start(processStartInfo);

        }

        [Then(@"o sistema deve exibir uma mensagem de erro de busca no twitter")]
        public void EntaoOSistemaDeveExibirUmaMensagemDeErroDeBuscaNoTwitter()
        {
            process.StandardInput.Close();
            retorno = process.StandardOutput.ReadToEnd();
            Assert.IsTrue(retorno.Contains("ERRO NA BUSCA DA PALAVRA "));
        }

        [Then(@"pedir para o usuario cadastrar uma palavra")]
        public void EntaoPedirParaOUsuarioCadastrarUmaPalavra()
        {
            Assert.IsTrue(retorno.Contains("Para retwittar uma palavra é necessario primeiro cadastra-la no banco"));
        }
        #endregion
    }
}
