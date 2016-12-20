### Link da web
| MIME type                | C#                                  |
|--------------------------|-------------------------------------|
| application/vnd.lime.web-link+json               | [Lime.Messaging.Contents.WebLink](https://github.com/takenet/lime-csharp/blob/master/src/Lime.Messaging/Contents/WebLink.cs) |

Permite o envio de um link para uma página da web, podendo incluir metadados como título e um texto descritivo do link, além de uma imagem miniatura.

#### Exemplo

Enviando uma mensagem para um destinatário do Omni:

```json
{
    "id": "1",
    "to": "553199991111@0mn.io",
    "type": "application/vnd.lime.web-link+json",
    "content": { 
        "uri": "http://limeprotocol.org/content-types.html#web-link",
        "target": "self",
        "text": "Segue documentação do web-link"        
    }
}
```

Para mais detalhes, consulte a especificação do [protocolo LIME](http://limeprotocol.org/content-types.html#web-link).

#### Mapeamento nos canais

| Canal              | Tipo                    | 
|--------------------|-------------------------|
| Omni               | Link web                |
| Messenger          | [Generic template](https://developers.facebook.com/docs/messenger-platform/send-api-reference/generic-template) ou [Button](https://developers.facebook.com/docs/messenger-platform/send-api-reference/buttons) (se utilizado junto a um [menu multimídia](https://blip.ai/portal/#/docs/content-types/document-select). |
| SMS                | Texto com link          |
| Skype              | [Activity](https://docs.botframework.com/en-us/skype/chat/#sending-messages-1)|
| Telegram           | [Message](https://core.telegram.org/bots/api#message)|

Em alguns canais, é possível utilizar [URI schemes](https://en.wikipedia.org/wiki/Uniform_Resource_Identifier) especiais para a criação de links com comportamentos específicos. 

| Canal     | URI Scheme | Descrição                                                           | Exemplo              |
|-----------|------------|---------------------------------------------------------------------|----------------------|
| Messenger | `tel`      | Define um link para a ligação telefonica para o número especificado | `tel:+5531999990000` |
| Messenger | `share`    | Define um link para compartilhamento da mensagem atual. É válido somente se utilizado junto a um [menu multimídia](https://blip.ai/portal/#/docs/content-types/document-select). | `share:`             |

