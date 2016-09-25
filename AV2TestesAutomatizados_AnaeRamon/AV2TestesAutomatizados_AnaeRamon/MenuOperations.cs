﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AV2Database;
using AV2Database.Model;
using System.Data.Entity;
using LinqToTwitter;

namespace AV2TestesAutomatizados_AnaeRamon
{
    public class MenuOperations
    {
        public void Menu()
        {
            string command;
            Console.WriteLine("");
            Console.WriteLine(" =^_^= BotBDDTwitter - Ana e Ramon =^_^=");
            ExibeOpcoes();
            do
            {
                command = Console.ReadLine().ToString();
                switch (command)
                {
                    case "0":
                        Console.WriteLine("");
                        Console.WriteLine(" Até logo! ");
                        Console.WriteLine("");
                        break;

                    case "1":
                        Console.WriteLine("");
                        Console.WriteLine(" Palavras Cadastradas: ");
                        Console.WriteLine("");
                        Console.WriteLine(" == Inicio da lista de palavras cadastradas ==");
                        Console.WriteLine("");

                        ListarPalavras();
                        Console.WriteLine(" == Fim da Lista de palavras ==");
                        break;
                    case "2":
                        Console.WriteLine("");
                        Console.WriteLine(" Por favor digite a palavra desejada para cadastro:");
                        Console.WriteLine("");
                        CadastraPalavra(Console.ReadLine().Trim().ToString());
                        Console.WriteLine("");
                        break;
                    case "3":
                        Console.WriteLine("");
                        if (ValidaPermissaoRemocao())
                        {
                            Console.WriteLine(" Palavras Cadastradas: ");
                            Console.WriteLine("");
                            ListarPalavras();
                            Console.WriteLine("");
                            Console.WriteLine(" Por favor digite o ID da palavra desejada para remoção:");
                            Console.WriteLine("");
                            RemovePalavra(Console.ReadLine().Trim().ToString());
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine(" Não há palavras cadastradas para serem removidas");
                            Console.WriteLine("");
                        }

                        break;
                    case "4":
                        Console.WriteLine("");
                        wakeupBoot();
                        Console.WriteLine("");
                        break;
                    case "h":
                        Console.WriteLine("");
                        ExibeOpcoes();
                        Console.WriteLine("");
                        break;
                    default:
                        Console.WriteLine("");
                        Console.WriteLine(" Opção inválida");
                        Console.WriteLine("");
                        break;
                }
            } while (!String.Equals(command, "0"));
        }
        private void RemovePalavra(string idPalavra)
        {
            try
            {

                var unitofwork = new UnitOfWork(new DBPalavrasContext());
                unitofwork.RemoverPalavra(Int32.Parse(idPalavra));

                Console.WriteLine("");
                Console.WriteLine(" Palavra removida com sucesso!");

            }
            catch (Exception)
            {
                Console.WriteLine("");
                Console.WriteLine(" Ocorreu um erro ao remover a palavra");
            }

        }
        private void CadastraPalavra(string palavra)
        {
            string resultado = String.Format(" Palavra '{0}' foi cadastrada com sucesso!", palavra);
            PalavrasModel palavraInserida = new PalavrasModel() { Nome = palavra };

            try
            {
                var unitofwork = new UnitOfWork(new DBPalavrasContext());
                unitofwork.InserirPalavra(palavraInserida);

            }
            catch (Exception)
            {
                resultado = String.Format(" Ocorreu um erro no cadastro da palavra: {0}", palavra);
            }
            Console.WriteLine("");
            Console.WriteLine(resultado);
        }
        private void ListarPalavras()
        {
            string formatacaoPalavras = String.Empty;

            IList<PalavrasModel> listaDePalavras = new List<PalavrasModel>();

            try
            {
                listaDePalavras = ObterListaPalavras();

                if (listaDePalavras.Count >= 1)
                {
                    Console.WriteLine(" ID -> Valor");
                    Console.WriteLine(" ___________");
                    foreach (var palavra in listaDePalavras)
                    {
                        formatacaoPalavras = String.Format(formatacaoPalavras + "  " + palavra.Id + " -> " + palavra.Nome + "\n");
                    }
                    Console.WriteLine(formatacaoPalavras);
                }
                else
                {
                    Console.WriteLine(" Não há palavras cadastradas no momento");
                    Console.WriteLine("");
                }

            }
            catch (Exception)
            {
                Console.WriteLine(" Ocorreu um erro ao listar as palavras");
            }
        }
        public IList<PalavrasModel> ObterListaPalavras()
        {
            IList<PalavrasModel> listaDePalavras = new List<PalavrasModel>();
            try
            {
                var unitOfWork = new UnitOfWork(new DBPalavrasContext());
                listaDePalavras = unitOfWork.ObtemListaPalavras();
            }
            catch (Exception)
            {
                Console.WriteLine(" Ocorreu um erro ao retornar a lista de palavras do banco de dados");
                throw;
            }

            return listaDePalavras;
        }
        private static void ExibeOpcoes()
        {
            Console.WriteLine("");
            Console.WriteLine(" Por favor selecione uma das seguintes opções:");
            Console.WriteLine("");
            Console.WriteLine(" 0 - Sair do Programa");
            Console.WriteLine(" 1 - Listar Palavras Cadastradas");
            Console.WriteLine(" 2 - Cadastrar uma Palavra");
            Console.WriteLine(" 3 - Remover uma Palavra");
            Console.WriteLine(" 4 - Iniciar Bot");
            Console.WriteLine(" h - Exibe Opções");
            Console.WriteLine("");
            Console.WriteLine(" ================================================");
            Console.WriteLine("");
        }
        private static bool ValidaPermissaoRemocao()
        {
            bool valido = true;

            try
            {
                var unitofwork = new UnitOfWork(new DBPalavrasContext());
                var quantidadePalavrasInseridas = unitofwork.ObtemListaPalavras().Count;
                if (!(quantidadePalavrasInseridas > 0))
                {
                    valido = false;
                }
            }
            catch (Exception)
            {
                Console.WriteLine(" Ocorreu um erro na validação de remoção de palavras");
            }

            return valido;
        }
        private List<GeracaoPalavras.TermosDeBusca> ObtemVariacaoPalavras()
        {
            GeracaoPalavras gerarPalavras = new GeracaoPalavras();
            var list = gerarPalavras.GeraListaDeVariacaoDePalavra();
            //TODO: Acoplar com método do bot para buscar e retweetar tweets com essas palavras
            return list;

        }


        private void wakeupBoot()
        {

            Console.WriteLine("Acordando Boot Twitter!");

            var _twitterController = new TwitterConnector();
            SingleUserAuthorizer authorizer = _twitterController.authorization();
            Console.WriteLine("Conectado ao twitter.");
            Console.WriteLine("Obtendo do banco de dados as palavras cadastradas...");
            List<GeracaoPalavras.TermosDeBusca> listObtencaoPalavras = ObtemVariacaoPalavras();
            var listDistinctPalavras = listObtencaoPalavras.Distinct().ToList(); //listPalavras.Distinct().ToList();

            Console.WriteLine("Varrendo o twitter com as palavras cadastradas...");

            //metodos com o twitter 
            if (listDistinctPalavras.Count > 0)
            {
                List<ulong> arrayTwitters = TwitterController.BuscarTwitters(authorizer, listObtencaoPalavras);
                TwitterController.RetweetAsync(authorizer, arrayTwitters);
                Console.WriteLine("Retweeted Acabou");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine(":::::::::::::::::ERRO NA BUSCA DA PALAVRA :::::::::::::::::::::");
                Console.WriteLine("Para retwittar uma palavra é necessario primeiro cadastra-la no banco");
                Console.WriteLine("Digite 'H' para visualizar o menu de opções e cadastra-la");
            }
            Console.WriteLine("");
        }


    }
}
