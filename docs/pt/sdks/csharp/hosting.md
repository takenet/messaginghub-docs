### Hospedagem

Quando o contato criado via SDK, a hospedagem fica a cargo do usuário. O ambiente que a aplicação fica hospedado precisa de acesso à internet para que a conexão com o servidor seja estabelecida.

Uma conexão *TCP* é estabelecida na porta 55321 do servidor do MessagingHub. Esta conexão irá servir como camada de transporte do protocolo [Lime](http://limeprotocol.org/), que é o protocolo utilizado para comunicação.

#### Hospedando no IIS

O pacote `Takenet.MessagingHub.Client.WebTemplate` permite a execução do seu código como uma aplicação do ASP.NET, o que torna possível que o mesmo seja hospedado no **IIS**. Na prática, é apenas um *wrapper* do **OWIN** para a inicialização do cliente, sendo que a comunicação **não acontece via HTTP**. Por este motivo, ao colocar em um servidor, é importante configurar o *application pool* da sua aplicação para permanecer ativo e não ser reciclado automaticamente.

Para utilizá-lo, é necessário criar um projeto web vazio. No Visual Studio, clique em **File > New > Project...** e em **Visual C#** escolha **ASP.NET Web Application**, lembrando de escolher a versão **4.6.1** ou superior do .NET Framework. Ao ser exibida a tela para escolha do template ASP.NET, escolha a opção **Empty** e desmarque todas as opções na seção **Add folders and core references**.

Será criado um projeto vazio, apenas com o arquivo *Web.config*. Daí, basta executar o comando para instalação do pacote, na janela **Package Manager Console**:

```
Install-Package Takenet.MessagingHub.Client.WebTemplate
```

No mais, basta incluir seus arquivos e configurar o `application.json` criado como um projeto qualquer. Para testar localmente, basta iniciar o *Debug* do Visual Studio. E para publicar, basta publicá-lo no IIS como uma aplicação web qualquer, lembrando de configurar o *application pool* para se manter ativo. Pode ser necessário na primeira vez ao publicar no servidor acessar a URL da aplicação web para que a aplicação seja inicializada.
