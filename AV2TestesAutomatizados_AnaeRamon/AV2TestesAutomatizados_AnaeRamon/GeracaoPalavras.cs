using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AV2Database;
using AV2Database.Model;
using System.Text.RegularExpressions;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;
using PluralizationServices;

namespace AV2TestesAutomatizados_AnaeRamon
{
    public class GeracaoPalavras
    {
        public int idPalavraBanco { get; private set; }
        public string nomePalavraBanco { get; private set; }
        public IList<List<string>> ListaDeVariacaoDaPalavras { get; private set; }

        public GeracaoPalavras()
        {
            ListaDeVariacaoDaPalavras = new List<List<string>>();
        }


        private List<string> GeraListaDeVariacaoDePalavra()
        {
            var listaDB = new UnitOfWork(new DBPalavrasContext()).ObtemListaPalavras();
            List<string> listaDeVariacaoDePalavra = new List<string>();
            foreach (var palavraNaLista in listaDB)
            {
                listaDeVariacaoDePalavra.Add(TrataPalavra(palavraNaLista, false));
            }
            return listaDeVariacaoDePalavra;
        }

        private string TrataPalavra(PalavrasModel palavrasModel, bool trataPlural)
        {
            /*
          Ignorar espaços em branco => Juntar as palavras
          Ignorar cases => To lowerCase
          Ignorar caracteres especiais  => remove chars @#$%¨&*
          Singular e plural => PortuguesePluralizationService ?
          */

            //Espaços em branco
            palavrasModel.Nome = palavrasModel.Nome.Replace(" ", string.Empty).Trim();
            //Minúscula
            palavrasModel.Nome = palavrasModel.Nome.ToLower();
            //Especiais
            palavrasModel.Nome = Regex.Replace(palavrasModel.Nome, "[^à-éÀ-Éa-zA-Z0-9_.]+", "", RegexOptions.Compiled);
            //Plural
            if (trataPlural)
            {
                if (!(new PortuguesePluralizationService().IsSingular(palavrasModel.Nome)))
                {
                    palavrasModel.Nome = new PortuguesePluralizationService().Singularize(palavrasModel.Nome);
                }
            }
            return palavrasModel.Nome;
        }

        internal void Start()
        {
          ListaDeVariacaoDaPalavras.Add(new GeracaoPalavras().GeraListaDeVariacaoDePalavra());
        }
    }
}
