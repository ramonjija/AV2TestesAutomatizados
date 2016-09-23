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

        public class TermosDeBusca
        {
            public string singular { get; set; }
            public string plural { get; set; }
            public string minusculo { get; set; }
            public string maiusculo { get; set; }
            public string semEspacos { get; set; }
            public string semCaracteresEspeciais { get; set; }
            public string palavraCadastrada { get; set; }
        }

        public List<TermosDeBusca> ListaDeVariacaoDePalavras { get; private set; }

        public GeracaoPalavras()
        {
            ListaDeVariacaoDePalavras = new List<TermosDeBusca>();
        }

        public List<TermosDeBusca> GeraListaDeVariacaoDePalavra()
        {
            var listaDB = new UnitOfWork(new DBPalavrasContext()).ObtemListaPalavras();
            //List<TermosDeBusca> listaDeVariacaoDePalavra = new List<TermosDeBusca>();
            foreach (var palavraNaLista in listaDB)
            {
                ListaDeVariacaoDePalavras.Add(TrataPalavra(palavraNaLista));
            }
            return ListaDeVariacaoDePalavras;
        }

        private TermosDeBusca TrataPalavra(PalavrasModel palavrasModel)
        {
            TermosDeBusca termosDeBusca = new TermosDeBusca();
            //Palavra cadastrada
            termosDeBusca.palavraCadastrada = palavrasModel.Nome;

            //Espaços em branco
            //palavrasModel.Nome = palavrasModel.Nome.Replace(" ", string.Empty).Trim();
            termosDeBusca.semEspacos = palavrasModel.Nome.Replace(" ", string.Empty).Trim();

            //Minúscula
            //palavrasModel.Nome = palavrasModel.Nome.ToLower();
            termosDeBusca.minusculo = palavrasModel.Nome.ToLower();

            //Maiúscula
            termosDeBusca.maiusculo = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(palavrasModel.Nome);

            //Especiais
            //palavrasModel.Nome = Regex.Replace(palavrasModel.Nome, "[^à-éÀ-Éa-zA-Z0-9_.]+", "", RegexOptions.Compiled);
            termosDeBusca.semCaracteresEspeciais = Regex.Replace(palavrasModel.Nome, "[^à-éÀ-Éa-zA-Z0-9_.]+", "", RegexOptions.Compiled);

            //Plural
            if (!(new PortuguesePluralizationService().IsSingular(palavrasModel.Nome)))
            {
                termosDeBusca.plural = palavrasModel.Nome;
                string[] stringPalavras = palavrasModel.Nome.Split();
                if(stringPalavras.Length > 1)
                {
                    for(int i = 0; i < stringPalavras.Length; i++)
                    {
                        String termoSingular = new PortuguesePluralizationService().Singularize(stringPalavras[i]);
                        termosDeBusca.singular += termoSingular + " ";
                    }
                    termosDeBusca.singular = termosDeBusca.singular.Trim();

                }
                else
                {
                    termosDeBusca.singular = new PortuguesePluralizationService().Singularize(palavrasModel.Nome);

                }
            }
            else
            {

                termosDeBusca.singular = palavrasModel.Nome;
                string[] stringPalavras = palavrasModel.Nome.Split();
                if (stringPalavras.Length > 1)
                {
                    for (int i = 0; i < stringPalavras.Length; i++)
                    {
                        String termoPlural = new PortuguesePluralizationService().Pluralize(stringPalavras[i]);
                        termosDeBusca.plural += termoPlural + " ";
                    }
                    termosDeBusca.plural = termosDeBusca.plural.Trim();
                }
                else
                {
                    termosDeBusca.plural = new PortuguesePluralizationService().Pluralize(palavrasModel.Nome);
                }
                
            }
            return termosDeBusca;
        }
    }
}
