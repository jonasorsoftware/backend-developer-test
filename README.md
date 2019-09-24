Roteiro da Prova (Tempo previsto de prova 3hrs)
=======================

Observação: Para fazer o teste deve ser criado um Fork do projeto e quando finalizar criar um Pull Request.

Sobre a prova os passo são os seguintes:

-Criar database, com o nome desejado no SQL Server(qualquer versão).

-Rodar o Script.sql que esta dentro da pasta Rakuten.Test na database criada e garantir que todas as tabelas e procedures sejam criadas corrigindo todos os erros de script

-Correções e Melhorias:

	- O Projeto irá apresentar erros de compilação, faz parte do teste identificar e corrigir esses erros para que o projeto compile

	-Tela de usuários
	A tela de usuários precisa estar com as ações de listar, inserir, alterar e remover funcionando corretamente(testar e corrigir todas as funcionalidades que apresentem erros)

	-Inserir usuário
	Criar uma nova coluna na tabela de usuário que deverá guardar o número do RG do usuário.

	Adicionar uma validação para verificar se o RG ou CPF de um novo usuário que está se cadastrando, já está cadastrado na base de dados (semelhante a verificação do e-mail) e não permitir o cadastro desse cliente.

	-Log
	Implementar um log de texto para guardar os erros da aplicação e os erros pegos na validação dos documentos e de email(pode criar um log implementado do zero ou utilizar um framework como por exemplo Log4net)

	-Webservice de pedidos (Order.asmx)
	Será necessário criar um novo método no serviço Order.asmx, que exiba apenas os pedidos que não estão marcados como integrados(Orders com o campo Integrated = 0). O nome do método deve ser GetNewOrders

	Será necessário criar um novo método no serviço Order.asmx, que altere o status do pedido. O nome do método deve ser ChangeOrderStatus e receberá como parâmetros o id do pedido e o status que o pedido será alterado e irá alterar a coluna CurrentStatus do pedido passado.
  
  Boa Sorte
