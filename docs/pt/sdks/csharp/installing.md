### Instalação

> É necessário o *Visual Studio 2015 Update 1* e o *.NET Framework 4.6.1*.

No Visual Studio, crie um projeto do tipo *Class library*. 

A partir do Package Manager Console, instale o template de aplicações usando:

    Install-Package Takenet.MessagingHub.Client.Template
    

Este pacota instala todos as dependências necessárias, além de criar o arquivo `application.json` que define todas as configurações da sua aplicação.

Você precisará de um identificador e uma chave de acesso, para poder se conectar ao Messaging Hub. Para obtê-los, faça o seguinte:
- Acesse o [Painel Omni](http://omni.messaginghub.io/portal).
- Na aba `Contatos` clique em `Criar Contato`.
- Preencha com os parâmetros requeridos e na próxima etapa escolha a opção `Chat Bot (SDK)`
- Pronto, seu contato foi criado e o identificador e chave de acesso serão exibidos.

O identificador e a chave de acesso devem ser definidos no arquivo `application.json` do seu projeto.
