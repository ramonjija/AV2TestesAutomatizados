using System;
using System.Diagnostics;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace AV2TestesAutomatizados_AnaeRamon.Specs
{
   
    [Binding]
    public class RetweetDePalavrasChavesNoTwiterSteps
    {
        public IWebDriver driver;
        private Process process;
 
        [Given(@"que cadastrei a palavra ""(.*)"" no sistema")]
        public void DadoQueCadastreiAPalavraNoSistema(string p0)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo(@"C:\vtex\ambiente\github\AV2TestesAutomatizados\AV2TestesAutomatizados_AnaeRamon\AV2TestesAutomatizados_AnaeRamon\bin\Ana\AV2TestesAutomatizados_AnaeRamon.exe");
            //ProcessStartInfo processStartInfo = new ProcessStartInfo(@"C:\Users\Ramon\Documents\Github\AV2TestesAutomatizados\AV2TestesAutomatizados_AnaeRamon\AV2TestesAutomatizados_AnaeRamon\bin\RHome\AV2TestesAutomatizados_AnaeRamon.exe");
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.UseShellExecute = false;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.StandardOutputEncoding = Encoding.GetEncoding(850);
            process = Process.Start(processStartInfo);

            process.StandardInput.WriteLine("2");
            process.StandardInput.WriteLine(p0);
        }
        
        [When(@"seleciono a opção de iniciar boot")]
        public void QuandoSelecionoAOpcaoDeIniciarBoot()
        {
            process.StandardInput.WriteLine("4");
            string retorno = "";
            process.StandardInput.Close();
            retorno = process.StandardOutput.ReadToEnd();
            
            
            if (retorno.Contains("Não é possivel retwitar duas vezes"))
            {
                Assert.IsTrue(retorno.Contains("Não é possivel retwitar duas vezes"));
            }
            if (retorno.Contains("Palavra(s) buscadas com sucesso!") && !retorno.Contains("Não é possivel retwitar duas vezes"))
            {
                Assert.IsTrue(retorno.Contains("Palavra(s) buscadas com sucesso!"));
                process.Close();
            }
                       
        }
        
        [Then(@"quero que o robo retweet tudo sobre a palavra automaticamente")]
        public void EntaoQueroQueORoboRetweetTudoSobreAPalavraAutomaticamente()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://twitter.com/grupoanaeramon");
        }

        [Given(@"que tento retweetar novamente sobre a palavra ""(.*)""")]
        public void DadoQueTentoRetweetarNovamenteSobreAPalavra(string p0)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo(@"C:\vtex\ambiente\github\AV2TestesAutomatizados\AV2TestesAutomatizados_AnaeRamon\AV2TestesAutomatizados_AnaeRamon\bin\Ana\AV2TestesAutomatizados_AnaeRamon.exe");
            //ProcessStartInfo processStartInfo = new ProcessStartInfo(@"C:\Users\Ramon\Documents\Github\AV2TestesAutomatizados\AV2TestesAutomatizados_AnaeRamon\AV2TestesAutomatizados_AnaeRamon\bin\RHome\AV2TestesAutomatizados_AnaeRamon.exe");
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.UseShellExecute = false;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.StandardOutputEncoding = Encoding.GetEncoding(850);
            process = Process.Start(processStartInfo);

            process.StandardInput.WriteLine("2");
            process.StandardInput.WriteLine(p0);
        }
       
        [Then(@"o sistema deve exibir uma mensagem de erro na hora de realizar a ação de retweet")]
        public void EntaoOSistemaDeveExibirUmaMensagemDeErroNaHoraDeRealizarAAcaoDeRetweet()
        {

        }
    }
}
