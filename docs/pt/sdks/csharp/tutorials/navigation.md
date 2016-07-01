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

Neste caso, existe apenas um **receiver** de mensagem registrado, com um filtro do tipo de conteúdo `text/plain` sendo que seu processamento é feito pela classe `PlainTextMessageReceiver` que deve existir no projeto.

Imagine que nosso contato deva responder a comando com o texto `ajuda` com uma mensagem estática de auxílio ao usuário. Desta forma, precisamos:
- Registrar um novo receiver de mensagem
- Incluir um filtro de tipo *texto* e conteúdo *ajuda*
- Retornar a mensagem de ajuda ao originador

Para facilitar, o SDK inclui alguns *receivers* para ações comuns, como mensagens estáticas, não sendo necessário neste primeiro caso de uso implementar o *receiver* para envio da mensagem. Neste caso, a sessão receivers ficaria da seguinte forma:

```json
  "messageReceivers": [
    {
      "mediaType": "text/plain",
      "content": "ajuda",
      "response": {
        "mediaType": "text/plain",
        "plainContent": "Olá, seja bem-vindo ao serviço de ajuda do Messaging Hub."
      }
    }
  ]
```
Desta forma, se o cliente enviar a palavra `ajuda`, ele receberá uma mensagem do tipo `text/plain` com conteúdo `Olá, seja bem-vindo ao serviço de ajuda do Messaging Hub.`. Se quisermos incluir outras palavras para a ativação do comando, basta alterar a propriedade `content` e alterar a expressão regular de filtro, como por exemplo:

```json
  "messageReceivers": [
    {
      "mediaType": "text/plain",
      "content": "^(inicio|iniciar|começar|ajuda)$",
      "response": {
        "mediaType": "text/plain",
        "plainContent": "Olá, seja bem-vindo ao serviço de ajuda do Messaging Hub."
      }
    }
  ]
```
Podemos retornar, ao invés de um texto simples, uma tipo de mensagem complexa como um **Select**, que mostra um menu de opções ao usuário. Para isso, basta utilizarmos a propriedade `jsonContent` ao invés de `plainContent`, como abaixo:

```json
  "messageReceivers": [
    {
      "mediaType": "text/plain",
      "content": "^(inicio|iniciar|começar|ajuda)$",
      "response": {
        "mediaType": "application/vnd.lime.select+json",
        "jsonContent": {
          "text": "Olá, seja bem-vindo ao serviço de ajuda do Messaging Hub. Escolha o que você deseja receber:",
          "options": [
            {
              "order": 1,
              "text": "Um TEXTO",
              "type": "text/plain",
              "value": "texto"
            },
            {
              "order": 2,
              "text": "Uma IMAGEM",
              "type": "text/plain",
              "value": "imagem"
            },
            {
              "order": 3,
              "text": "A DATA atual",
              "type": "text/plain",
              "value": "data"
            }
          ]
        }
      }
    }
  ]
```
