### Menu
| MIME type                                 | C#                                        |
|-------------------------------------------|-------------------------------------------|
| application/vnd.lime.select+json | [Lime.Messaging.Contents.Select](https://github.com/takenet/lime-csharp/blob/master/src/Lime.Messaging/Contents/Select.cs) |

Permite o envio de um menu de opções aos clientes para a realização de uma escolha. O cabeçalho e as opções são do tipo texto, sendo possível definir um documento que deve ser entregue ao contato quando o cliente realiza uma escolha (depende de suporte do canal). As opções podem opcionalmente serem numeradas.

Alguns canais suportam a limitação do escopo das opções, que determina por quanto tempo as mesmas são válidas para seleção por parte do usuário. Por exemplo, em alguns casos as opções enviadas só podem ser selecionadas pelo cliente naquele momento e devem desaparecer após a escolha. Neste caso, o escopo é **imediato**. Em outros, as opções são válidas para seleção em qualquer momento, sendo o escopo **persistente**.

Para mais detalhes, consulte a especificação do [protocolo LIME](http://limeprotocol.org/content-types.html#select).

####Exemplo
Menu com opções numeradas
```json
{
    "id":"3",
    "to":"1042221589186385@messenger.gw.msging.net",
    "type":"application/vnd.lime.document-select+json",
    "content":{
        "text":"Escolha uma opção",
        "options":[
            {
                "order":1,
                "text":"Primeira opção"
            },
            {
                "order":2,
                "text":"Segunda opção"
            },
            {
                "order":3,
                "text":"Terceira opção",
                "type":"application/json",
                "value":{
                    "key1":"value1",
                    "key2":2
                }
            }
        ]
    }
}
```

### Mapeamento nos canais

| Canal              | Tipo                    | 
|--------------------|-------------------------|
| Omni               | Menu                    |
| Messenger          | [Button template](https://developers.facebook.com/docs/messenger-platform/send-api-reference/button-template) (no escopo padrão) e [Quick replies](https://developers.facebook.com/docs/messenger-platform/send-api-reference/quick-replies) (no escopo *immediate*)|
| SMS                | Texto                   |
| Skype              | [Activity](https://docs.botframework.com/en-us/skype/chat/#sending-messages-1)|
| Telegram           | [Message](https://core.telegram.org/bots/api#message)|
