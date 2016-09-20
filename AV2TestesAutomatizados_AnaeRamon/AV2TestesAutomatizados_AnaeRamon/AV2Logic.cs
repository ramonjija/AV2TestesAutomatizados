using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AV2Database;
using AV2Database.Model;
using System.Data.Entity;

namespace AV2TestesAutomatizados_AnaeRamon
{
   public class AV2Logic
    {
        public void Menu()
        {
            string command;
            Console.WriteLine("");
            Console.WriteLine(" =^_^= BotTwitter - Ana e Ramon =^_^=");
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
                        Console.WriteLine(" Bot Iniciado");
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
        private void RemovePalavra(string IdPalavra)
        {
            try
            {
                using (var db = new DBPalavrasContext())
                {
                    var palavra = db.Palavras.Find(Int32.Parse(IdPalavra));
                    db.Palavras.Remove(palavra);
                    db.SaveChanges();
                }
                Console.WriteLine("");
                Console.WriteLine(" Palavra removida com sucesso!");
            }catch(Exception e)
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
                using (var db = new DBPalavrasContext())
                {
                    db.Palavras.Add(palavraInserida);
                    db.SaveChanges();
                }
            }catch(Exception e)
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
                using(var db = new DBPalavrasContext())
                {
                    listaDePalavras = db.Palavras.ToList();
                }

                if (listaDePalavras.Count >= 1)
                {
                    Console.WriteLine(" ID -> Valor");
                    Console.WriteLine(" ___________");
                    foreach (var palavra in listaDePalavras)
                    {
                        formatacaoPalavras = String.Format(formatacaoPalavras+"  "+ palavra.Id+" -> " +palavra.Nome + "\n");
                    }
                    Console.WriteLine(formatacaoPalavras);
                }
                else
                {
                    Console.WriteLine(" Não há palavras cadastradas no momento");
                    Console.WriteLine("");
                }

            }
            catch(Exception e)
            {
               Console.WriteLine( " Ocorreu um erro ao listar as palavras");
            }
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
                using(var db = new DBPalavrasContext())
                {
                    if(!(db.Palavras.Count<PalavrasModel>() > 0))
                    {
                        valido = false;
                    }
                }
            }catch(Exception e)
            {
                Console.WriteLine(" Ocorreu um erro na validação de remoção de palavras");
            }

            return valido;
        }
    }
}
