using System;
using TechTalk.SpecFlow;
using AV2TestesAutomatizados_AnaeRamon;
using System.Diagnostics;
using NUnit.Framework;
using AV2Database;
using AV2Database.Model;

namespace AV2TestesAutomatizados_AnaeRamon.Specs
{
    [Binding]
    public class GerenciarPalavrasCadastradasSteps
    {
        private Process process;

        #region Menu Principal
        [Given(@"que estou no menu principal do app BotTweeter")]
        public void DadoQueEstouNoMenuPrincipalDoAppBotTweeter()
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo(@"C:\vtex\ambiente\github\AV2TestesAutomatizados\AV2TestesAutomatizados_AnaeRamon\AV2TestesAutomatizados_AnaeRamon\bin\Ana\AV2TestesAutomatizados_AnaeRamon.exe");
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.UseShellExecute = false;
            processStartInfo.CreateNoWindow = true;
            process = Process.Start(processStartInfo);
           
        }
        #endregion

        #region Teste Cadastro de Palavra
        [When(@"digito a opção de cadastro de palavras")]
        public void QuandoDigitoAOpcaoDeCadastroDePalavras()
        {
            process.StandardInput.WriteLine("2");
        }

        [When(@"insiro a palavra ""(.*)""")]
        public void QuandoInsiroAPalavra(string p0)
        {
            process.StandardInput.WriteLine(p0);
        }

        [Then(@"o sistema deve exibir uma mensagem de sucesso de cadastro")]
        public void EntaoOSistemaDeveExibirUmaMensagemDeSucessoDeCadastro()
        {
            string line = "";
            while (process.StandardOutput.Peek() > -1)
            {
                line = process.StandardOutput.ReadLine();
                if (line.Equals(" Palavra 'Teste' foi cadastrada com sucesso!"))
                {
                    break;
                }
            }
            Assert.AreEqual(" Palavra 'Teste' foi cadastrada com sucesso!", line);

            process.Close();
        }

        #endregion

        #region Teste Listagem de Palavra
        [When(@"digito a opção de exibição de palavras-chave")]
        public void QuandoDigitoAOpcaoDeExibicaoDePalavras_Chave()
        {
            process.StandardInput.WriteLine("1");
        }

        [Then(@"o sistema deve exibir a palavra cadastrada ""(.*)""")]
        public void EntaoOSistemaDeveExibirAPalavraCadastrada(string p0)
        {
            string line = "";

            while (process.StandardOutput.Peek() > -1)
            {
                line = process.StandardOutput.ReadLine();
                if (line.Contains(p0))
                {
                    break;
                }
            }
            Assert.IsTrue(line.Contains(p0));
        }
        #endregion

        #region Teste Remoção de Palavra
        [When(@"digito a opção de remoção de palavras")]
        public void QuandoDigitoAOpcaoDeRemocaoDePalavras()
        {
            process.StandardInput.WriteLine("3");
        }
        [When(@"insiro o id da palavra ""(.*)""")]
        public void QuandoInsiroOIdDaPalavra(string p0)
        {
            string line = "";
            string idPalavra = "0";

            while (process.StandardOutput.Peek() > -1)
            {
                line = process.StandardOutput.ReadLine();
                if (line.Contains(p0))
                {
                    idPalavra = line.Substring(0, 3).Trim();
                    break;
                }
            }
            process.StandardInput.WriteLine(idPalavra);
        }

        [Then(@"o sistema deve exibir uma mensagem de sucesso de remoção")]
        public void EntaoOSistemaDeveExibirUmaMensagemDeSucessoDeRemocao()
        {
            string line = "";

            while (process.StandardOutput.Peek() > -1)
            {
                line = process.StandardOutput.ReadLine();
                if (line.Equals(" Palavra removida com sucesso!"))
                {
                    break;
                }
            }
            Assert.AreEqual(" Palavra removida com sucesso!", line);
        }
        #endregion
    }
}
