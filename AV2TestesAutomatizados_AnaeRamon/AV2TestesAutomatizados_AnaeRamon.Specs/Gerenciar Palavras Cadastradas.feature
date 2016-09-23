#language: pt-br

Funcionalidade: Gerenciar Palavras Cadastradas
	Para aumentar a possibilidades de busca
	Como um aluno de testes automatizados
	Desejo permitir o cadastro, exibição e remoção de um conjunto de palavras-chave

Cenario: Cadastro de Palavras-Chave
	Dado que Augusto é um estudante assíduo de Testes de Software
	E gostaria de divulgar mais sobre o assunto utilizando a ferramenta de Bot do twitter
	Para isso, deve cadastrar palavras na ferramenta BotBDDTwitter
	Quando Augusto seleciona a opção de cadastro
	E digita a palavra "Teste"
	Entao o sistema deve exibir a mensagem "Palavra 'Teste' foi cadastrada com sucesso!"
	E a palavra "Teste" deve ser gravada no banco

	Cenario: Cadastro de Palavras-Chave no plural
	Dado que Alan ficou interessado na ferramenta de Bot do Twitter
	E gostaria de experimentar seu uso, cadastrando uma palavra
	Quando Alan seleciona a opção de cadastro
	E digita a palavra "Amigos"
	Entao o sistema deve exibir a mensagem "Palavra 'Amigos' foi cadastrada com sucesso!"

Cenario: Remoção de Palavra-chave
	Dado que Marissa gosta de organização
	E fica extremamente irritada com informações desnecessárias
	Para organizar melhor a lista de palavras cadastradas
	Quando Marissa seleciona a opção de Remover Palavra Cadastrada
	E digita o identificador 5, da palavra cadastrada Jujuba
	Entao o sistema deve exibir "Palavra removida com sucesso!"
	E a palavra Jujuba, não deve mais ser exibida no sistema.

Cenario: Exibicao de Palavras-chave Cadastradas
	Dado que Junior cadastrou as palavras Testes, Documentação Viva e BDD
	E gostaria de confirmar o cadastro de suas palavras
	Quando digita a opção de listar palavras
	Então o sistema deve exibir uma lista contendo as palavras Testes, Documentação Viva e BDD.
	