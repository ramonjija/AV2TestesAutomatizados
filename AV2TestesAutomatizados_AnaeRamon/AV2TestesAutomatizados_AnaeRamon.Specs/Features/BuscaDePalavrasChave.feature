#language: pt-br

Funcionalidade: Busca de palavras-chave no twitter
	Para encontrar tweets relevantes à disciplina de testes automatizados
	Como aluno de testes automatizados
	Desejo realizar a busca utilizando as palavras-chave cadastradas

	Cenario: Busca de uma palavra-chave ja cadastrada no twitter
		Dado que ja cadastrei a palavra "testegrupo" 
		Quando digito a opção de iniciar boot  
		Então o sistema deve exibir uma mensagem de sucesso de busca no twitter 
		
	Cenario: Busca de uma palavra-chave não cadastrada no twitter
		Dado que esqueci de cadastrar uma palavra e não possuo nenhuma outra cadastrada 
		Quando digito a opção de iniciar boot  
		Então o sistema deve exibir uma mensagem de erro de busca no twitter 
		E pedir para o usuario cadastrar uma palavra 