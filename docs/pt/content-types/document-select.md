### Menu multimídia
| MIME type                                 | C#                                        |
|-------------------------------------------|-------------------------------------------|
| application/vnd.lime.document-select+json | [Lime.Messaging.Contents.DocumentSelect](https://github.com/takenet/lime-csharp/blob/master/src/Lime.Messaging/Contents/DocumentSelect.cs) |

Permite o envio de um menu de opções aos clientes, podendo o cabeçalho e as opções serem, além de **texto**, outros tipos de conteúdo como **link de mídia** ou **link web**. Para cada opção, é possível definir um documento que é entregue ao chatbot quando o cliente realiza uma escolha (depende de suporte do canal).

#### Exemplo
1 - Menu com imagem no cabeçalho e um link e texto como opções:
```json
{
    "id": "1",
    "to": "1042221589186385@messenger.gw.msging.net",
    "type": "application/vnd.lime.document-select+json",
    "content": {
        "header": {
            "type": "application/vnd.lime.media-link+json",
            "value": {
                "title": "Seja bem-vindo ao Chapeleiro Maluco",
                "text": "Aqui temos o melhor chapéu para sua cabeça.",
                "type": "image/jpeg",
                "uri": "http://petersapparel.parseapp.com/img/item100-thumb.png",
                "aspectRatio": "1:1"
            }
        },
        "options": [
            {
                "label": {
                    "type": "application/vnd.lime.web-link+json",
                    "value": {
                        "text": "Visitar site",
                        "uri": "https://petersapparel.parseapp.com/view_item?item_id=100"
                    }
                }
            },
            {
                "label": {
                    "type": "text/plain",
                    "value": "Ver estoque"
                },
                "value": {
                    "type": "application/json",
                    "value": {
                        "action": "show-items"
                    }
                }
            }
        ]
    }
}
```
Utilizando C#:
```csharp
var select = new DocumentSelect()
{
    Header = new DocumentContainer
    {
        Value = new MediaLink
        {
            Title = "Seja bem-vindo ao Chapeleiro Maluco",
            Text = "Aqui temos o melhor chapéu para sua cabeça.",
            Type = new MediaType(MediaType.DiscreteTypes.Image, MediaType.SubTypes.JPeg),
            Uri = new Uri("http://petersapparel.parseapp.com/img/item100-thumb.png"),
            AspectRatio = "1:1"
        }
    },
    Options = new DocumentSelectOption[]
    {
        new DocumentSelectOption
        {
            Label = new DocumentContainer
            {
                Value = new WebLink
                {
                    Text = "Visitar site",
                    Uri = new Uri("https://petersapparel.parseapp.com/view_item?item_id=100")
                }
            }
        },
        new DocumentSelectOption
        {
            Label = new DocumentContainer
            {
                Value = new PlainText
                {
                    Text = "Ver Estoque"
                }
            },
            Value = new DocumentContainer
            {
                Value = new PlainText
                {
                    Text = "show-items"
                }
            }
        }
    }
};

await _sender.SendMessageAsync(select, to, cancellationToken);
```

Para mais detalhes, consulte a especificação do [protocolo LIME](http://limeprotocol.org/content-types.html#document-select).

#### Mapeamento nos canais

| Canal              | Tipo                    | 
|--------------------|-------------------------|
| BLiP App           | Menu (Obs.: Os campos 'label' e 'header' podem assumir apenas o tipo PlainText. O campo 'value' de cada um dos 'options' pode assumir qualquer tipo de Documento, exceto DocumentContainer)     |
| Messenger          | [Generic template](https://developers.facebook.com/docs/messenger-platform/send-api-reference/generic-template)|
| SMS                | Texto                   |
| Skype              | [Activity](https://docs.botframework.com/en-us/skype/chat/#sending-messages-1)|
| Telegram           | [Message](https://core.telegram.org/bots/api#message)|
