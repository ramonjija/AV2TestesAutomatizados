#language: pt-br

Funcionalidade: Busca de palavras-chave no twitter
	Para encontrar tweets relevantes à disciplina de testes automatizados
	Como aluno de testes automatizados
	Desejo realizar a busca utilizando as palavras-chave cadastradas

	Cenario: Cadastro de Palavra-Chave
		Dado que estou no menu principal do app BotTweeter
		Quando digito a opção de cadastro de palavras
		E insiro a palavra "Teste"
		Entao o sistema deve exibir uma mensagem de sucesso de cadastro

	Cenario: Busca de uma palavra-chave ja cadastrada no twitter
		Dado que ja cadastrei a palavra "Teste" 
		Quando digito a opção de iniciar boot  
		Então o sistema deve exibir uma mensagem de sucesso de busca no twitter 
		
	Cenario: Busca de uma palavra-chave não cadastrada no twitter
		Dado que esqueci de cadastrar uma palavra  
		Quando digito a opção de iniciar boot  
		Então o sistema deve exibir uma mensagem de erro de busca no twitter 
		E pedir para o usuario cadastrar uma palavra 