#language: pt-br

Funcionalidade: Retweet de palavras chaves no twiter 
Para seguir todo o conteudo relevante sobre testes
Como aluno de testes automatizados
Desejo que todo o tweeter com determinadas palavras sobre o assunto seja retweetado automaticamente 


	Cenario: Quero retweetar as palavras cadastrada no sistema 
		Dado que cadastrei a palavra "TESTEAUTOMACAOESSAMSGDEVESERDELETADA00012345" no sistema 
	    Quando seleciono a opção de iniciar boot   
		Entao o robo deve retweetar tweets sobre a palavra "TESTEAUTOMACAOESSAMSGDEVESERDELETADA00012345" automaticamente  

	Cenario: Retweetar o mesmo tweet 
		Dado que tento retweetar novamente sobre a palavra "TESTEAUTOMACAOESSAMSGDEVESERDELETADA00012345"  
		Quando seleciono a opção de iniciar boot  
		Então o sistema deve exibir uma mensagem de erro na hora de realizar a ação de retweet

		Cenário: Retweetar palavras cadastradas em minúsculo
		Dado que cadastrei a palavra "testegruporamoneanateste" no sistema
		Quando seleciono a opção de inicar boot
		Então o robo deve retweetar tweets sobre a palavra "testegruporamoneanateste" automaticamente

	Cenário: Retweetar palavras cadastradas no singular
		Dado que cadastrei a palavra "testegruporamoneanateste" no sistema
		Quando seleciono a opção de inicar boot
		Então o robo deve retweetar tweets sobre a palavra "testegruporamoneanateste" automaticamente

	Cenário: Retweetar palavras cadastradas no plural
		Dado que cadastrei a palavra "testegruporamoneanatestes" no sistema
		Quando seleciono a opção de inicar boot
		Então o robo deve retweetar tweets sobre a palavra "testegruporamoneanatestes" automaticamente

	Cenário: Retweetar palavras cadastradas com caracteres especiais
		Dado que cadastrei a palavra "testegruporamoneanatestes!@#$%¨&" no sistema
		Quando seleciono a opção de inicar boot
		Então o robo deve retweetar tweets sobre a palavra "testegruporamoneanatestes!@#$%¨&" automaticamente

	Cenário: Retweetar palavras cadastradas com espaço
		Dado que cadastrei a palavra "testegruporamon eanateste" no sistema
		Quando seleciono a opção de inicar boot
		Então o robo deve retweetar tweets sobre a palavra "testegruporamon eanateste" automaticamente
				