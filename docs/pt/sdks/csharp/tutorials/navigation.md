### Tutorial: Navegação

Neste tutorial, será demonstrado uma forma de construir um contato que responde automaticamente comandos de texto enviados pelos usuários.

O primeiro passo é, no Visual Studio, criar um novo projeto do tipo *Class Library* e instalar o pacote do SDK via **NuGet**, através do comando:

    Install-Package Takenet.MessagingHub.Client.Template
  
Desta forma, é adicionado ao projeto entre outras dependências, o arquivo `application.json`, onde ficam registrados os *receivers* de mensagens e notificações. Os **receivers** são as entidades responsáveis por processar as mensagens e notificações recebidas realizando ações específicas (invocando APIs, salvando informações no banco de dados, etc.) e, se necessário, enviar uma resposta ao usuário.

Um detalhe importante e bastante útil é que é possível registrar *receivers* definindo **filtros** de mensagens e notificações que o mesmo deve processar. Os filtros podem combinar várias propriedades, como o originador e conteúdo das mensagens, por exemplo. Além disso, são **expressões regulares** que permitem uma maior flexibilidade em sua definição.

Abaixo um exemplo do arquivo `application.json` criado em um novo projeto:

```json
{
  "identifier": "",
  "accessKey": "",
  "messageReceivers": [
    {
      "type": "PlainTextMessageReceiver",
      "mediaType": "text/plain"
    }
  ],
  "settings": {
    "setting1": "value1"
  },
  "startupType": "Startup",
  "schemaVersion": 2
}
```

Neste caso, existe apenas um **receiver** de mensagem registrado, com um filtro do tipo de conteúdo `text/plain` sendo que seu processamento é feito pela classe `PlainTextMessageReceiver` que deve estar registrada no projeto.
