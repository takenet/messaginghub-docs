### Lista
| MIME type                            | C#                                 |
|--------------------------------------|------------------------------------|
| application/vnd.lime.list+json       | [Lime.Protocol.DocumentCollection](https://github.com/takenet/lime-csharp/blob/master/src/Lime.Messaging/Contents/DocumentList.cs) |

Permite o envio de uma lista de documentos diferentes uma única mensagem. É possível definir um documento como cabeçalho da lista.

#### Exemplos
1 - Enviando uma lista com cabeçalho de **links da web** para um usuário do Messenger:
```json
{  
  "id":"1",
  "to":"123129898129832@msging.gw.msging.net",
  "type":"application/vnd.lime.list+json",
  "content":{  
    "header":{  
      "type":"application/vnd.lime.web-link+json",
      "value":{  
        "title":"Classic T-Shirt Collection",
        "text":"See all our colors",
        "previewUri":"https://peterssendreceiveapp.ngrok.io/img/collection.png",
        "uri":"https://peterssendreceiveapp.ngrok.io/shop_collection?messengerExtensions=true",
        "target":"selfTall"
      }
    },
    "items":[  
      {  
        "type":"application/vnd.lime.web-link+json",
        "value":{  
          "title":"Classic White T-Shirt",
          "text":"100% Cotton, 200% Comfortable",
          "previewUri":"https://peterssendreceiveapp.ngrok.io/img/white-t-shirt.png",
          "uri":"https://peterssendreceiveapp.ngrok.io/view?item=100&messengerExtensions=true",
          "target":"selfTall"
        }
      },
      {  
        "type":"application/vnd.lime.web-link+json",
        "value":{  
          "title":"Classic Blue T-Shirt",
          "text":"100% Cotton, 200% Comfortable",
          "previewUri":"https://peterssendreceiveapp.ngrok.io/img/blue-t-shirt.png",
          "uri":"https://peterssendreceiveapp.ngrok.io/view?item=101&messengerExtensions=true",
          "target":"selfTall"
        }
      },
      {  
        "type":"application/vnd.lime.web-link+json",
        "value":{  
          "title":"Classic Black T-Shirt",
          "text":"100% Cotton, 200% Comfortable",
          "previewUri":"https://peterssendreceiveapp.ngrok.io/img/black-t-shirt.png",
          "uri":"https://peterssendreceiveapp.ngrok.io/view?item=102&messengerExtensions=true",
          "target":"selfTall"
        }
      }
    ]
  }
}
```

### Mapeamento nos canais

| Canal              | Tipo                    | 
|--------------------|-------------------------|
| BLiP App           | Não suportado           |
| Messenger          | [List template](https://developers.facebook.com/docs/messenger-platform/send-api-reference/list-template)|
| SMS                | Texto                   |
| Skype              | [Activity](https://docs.botframework.com/en-us/skype/chat/#sending-messages-1)|
| Telegram           | [Message](https://core.telegram.org/bots/api#message)|
