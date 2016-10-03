using System;
using System.Diagnostics;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using AV2TestesAutomatizados_AnaeRamon;
using System.Threading;
using System.Threading.Tasks;
using LinqToTwitter;
using System.Collections.ObjectModel;

namespace AV2TestesAutomatizados_AnaeRamon.Specs
{

    [Binding]
    public class RetweetDePalavrasChavesNoTwiterSteps
    {
        public IWebDriver driver;
        private Process process;
        private string tweet;
        private string tweetId;

        [Given(@"que cadastrei a palavra ""(.*)"" no sistema")]
        public void DadoQueCadastreiAPalavraNoSistema(string p0)
        {
            //ProcessStartInfo processStartInfo = new ProcessStartInfo(@"C:\vtex\ambiente\github\AV2TestesAutomatizados\AV2TestesAutomatizados_AnaeRamon\AV2TestesAutomatizados_AnaeRamon\bin\Ana\AV2TestesAutomatizados_AnaeRamon.exe");
            ProcessStartInfo processStartInfo = new ProcessStartInfo(@"C:\Users\Ramon\Documents\Github\AV2TestesAutomatizados\AV2TestesAutomatizados_AnaeRamon\AV2TestesAutomatizados_AnaeRamon\bin\RHome\AV2TestesAutomatizados_AnaeRamon.exe");
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


        }

        [Given(@"que tento retweetar novamente sobre a palavra ""(.*)""")]
        public void DadoQueTentoRetweetarNovamenteSobreAPalavra(string p0)
        {
            //ProcessStartInfo processStartInfo = new ProcessStartInfo(@"C:\vtex\ambiente\github\AV2TestesAutomatizados\AV2TestesAutomatizados_AnaeRamon\AV2TestesAutomatizados_AnaeRamon\bin\Ana\AV2TestesAutomatizados_AnaeRamon.exe");
            ProcessStartInfo processStartInfo = new ProcessStartInfo(@"C:\Users\Ramon\Documents\Github\AV2TestesAutomatizados\AV2TestesAutomatizados_AnaeRamon\AV2TestesAutomatizados_AnaeRamon\bin\RHome\AV2TestesAutomatizados_AnaeRamon.exe");
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.UseShellExecute = false;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.StandardOutputEncoding = Encoding.GetEncoding(850);
            process = Process.Start(processStartInfo);

            process.StandardInput.WriteLine("2");
            process.StandardInput.WriteLine(p0);
            process.StandardInput.WriteLine("4");
        }

        [Then(@"o sistema deve exibir uma mensagem de erro na hora de realizar a ação de retweet")]
        public void EntaoOSistemaDeveExibirUmaMensagemDeErroNaHoraDeRealizarAAcaoDeRetweet()
        {
            string retorno = "";
            process.StandardInput.Close();
            retorno = process.StandardOutput.ReadToEnd();

            driver = new ChromeDriver();
            UndoRetweetRetrieveID(driver);
            driver.Quit();

            Assert.IsTrue(retorno.Contains("Não é possivel retwitar duas vezes"));

        }

        [When(@"seleciono a opção de inicar boot")]
        public void QuandoSelecionoAOpcaoDeInicarBoot()
        {
            process.StandardInput.WriteLine("4");
        }

        [Then(@"o robo deve retweetar tweets sobre a palavra ""(.*)"" automaticamente")]
        public void EntaoORoboDeveRetweetarTweetsSobreAPalavraAutomaticamente(string p0)
        {
            Thread.Sleep(2000);
            string retorno = "";
            string compara = p0;
            process.StandardInput.Close();
            retorno = process.StandardOutput.ReadToEnd();

            int indiceInicioTweet = retorno.IndexOf("Tweet: " + p0);
            int indiceInicioTweetId = retorno.IndexOf("TweetID: ");
            tweet = retorno.Substring(indiceInicioTweet + 6, compara.Length + 1).Trim();
            tweetId = retorno.Substring(indiceInicioTweetId + 9, 20).Trim();
            if (retorno.Contains("Palavra(s) buscadas com sucesso!") && !retorno.Contains("Não é possivel retwitar duas vezes"))
            {
                Assert.IsTrue(retorno.Contains("Palavra(s) buscadas com sucesso!"));
                Assert.IsTrue(tweet.Contains(compara));
                process.Close();
            }
            driver = new ChromeDriver();
            var element = UndoRetweetRetrieveID(driver);
            driver.Quit();
            Assert.Greater(element.Count, 0);
        }

        private ReadOnlyCollection<IWebElement> UndoRetweetRetrieveID(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://twitter.com/grupoanaeramon");
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("*[name='session[username_or_email]']")).SendKeys("grupoanaeramon@gmail.com");
            driver.FindElement(By.CssSelector("*[name='session[password]']")).SendKeys("testesautomatizados");
            driver.FindElement(By.CssSelector("*[value='Entrar']")).Click();
            Thread.Sleep(2000);
            var element = driver.FindElements(By.CssSelector("*[data-tweet-id='" + tweetId + "']"));
            //driver.FindElement(By.CssSelector("*[data-tweet-id='" + tweetId + "']")).Click();
            Thread.Sleep(2000);
            try
            {
                var button = driver.FindElements(By.CssSelector("*[data-modal='ProfileTweet-retweet']"));
                button[1].Click();
            }
            catch (Exception e) { Console.WriteLine("Erro na remoção do RT"); }
            return element;
        }
    }
}
