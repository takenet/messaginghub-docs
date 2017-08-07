### Instalação

> **Prerequisitos:**

- *Visual Studio 2017*, ou superior.
- *.NET Framework 4.6.1*.

No Visual Studio, crie um projeto do tipo *Class library*.

A partir do Package Manager Console, instale o template de aplicações usando:

    Install-Package Takenet.MessagingHub.Client.Template

Este pacote instala todos as dependências necessárias para utilizar o *client C#* e cria o arquivo `application.json` que define todas as configurações da sua aplicação.

Você precisará de um identificador e uma chave de acesso para poder se conectar ao BLiP Messaging Hub. Para obtê-los:
- Acesse o [Painel BLiP](https://portal.blip.ai).
- Na aba `Chatbots` clique em `Criar chatbot`.
- Escolha a opção `SDK` (para desenvolvedores) e preencha as informações solicitadas
- Pronto, seu chatbot foi criado e o identificador e chave de acesso serão exibidos na opção `Configurações` do menu lateral.

O identificador e a chave de acesso devem ser definidos no arquivo `application.json` do seu projeto.
