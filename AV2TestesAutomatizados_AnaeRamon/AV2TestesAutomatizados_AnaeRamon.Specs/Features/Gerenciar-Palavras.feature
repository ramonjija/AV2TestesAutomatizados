#language: pt-br

Funcionalidade: Gerenciar Palavras Cadastradas
	Para aumentar a possibilidades de busca
	Como um aluno de testes automatizados
	Desejo permitir o cadastro, exibição e remoção de um conjunto de palavras-chave

	Cenario: Cadastro de Palavra-Chave
		Dado que estou no menu principal do app BotTweeter
		Quando digito a opção de cadastro de palavras
		E insiro a palavra "Teste"
		Entao o sistema deve exibir uma mensagem de sucesso de cadastro

	Cenario: Exibição de Palavra-Chave
		Dado que estou no menu principal do app BotTweeter
		Quando digito a opção de exibição de palavras-chave
		Então o sistema deve exibir a palavra cadastrada "TESTEEXIBICAOPALAVRA"

	Cenario: Remoção de Palavra-Chave
		Dado que estou no menu principal do app BotTweeter
		Quando digito a opção de remoção de palavras
		E insiro o id da palavra "TESTEEXIBICAOPALAVRA"
		Então o sistema deve exibir uma mensagem de sucesso de remoção
