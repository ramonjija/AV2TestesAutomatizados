#language: pt-br

Funcionalidade: Retweet de palavras-chave no twitter
	Para seguir todo o conteudo relevantes sobre testes automatizados
	Como aluno de testes automatizados
	Desejo que todo o tweeter com determinadas palavras sobre o assunto seja retweetado automaticamente 

	Cenario: Quero que minha busca no twitter por palavras especificas seja retweetado 
		Dado que ja realizei minha busca pelas palavras que quero
	    Quando digito a opção de iniciar boot  
		Entao o sistema deve mostrar quais tweets foram retweetados 
		E retweetar tudo automaticamente 
		
				
	Cenario: Falha ao tentar Retweetar o mesmo tweet mais de uma vez  
		Dado que esqueci que retweetei uma palavra e chamo novamente o boot para relizar o retweet de novo    
		Quando digito a opção de iniciar boot  
		Então o sistema deve exibir uma mensagem de erro na hora de realizar a ação de retweet