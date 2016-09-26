#language: pt-br

Funcionalidade: Retweet de palavras chaves no twiter 
Para seguir todo o conteudo relevante sobre testes
Como aluno de testes automatizados
Desejo que todo o tweeter com determinadas palavras sobre o assunto seja retweetado automaticamente 


	Cenario: Quero retweetar as palavras cadastrada no sistema 
		Dado que cadastrei a palavra "Tamagochi" no sistema 
	    Quando seleciono a opção de iniciar boot   
		Entao quero que o robo retweet tudo sobre a palavra automaticamente  

				
	Cenario: Retweetar o mesmo tweet 
		Dado que tento retweetar novamente sobre a palavra "Tamagochi"  
		Quando seleciono a opção de iniciar boot  
		Então o sistema deve exibir uma mensagem de erro na hora de realizar a ação de retweet