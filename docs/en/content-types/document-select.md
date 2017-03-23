### Multimedia Menu
| MIME type                                 | C#                                        |
|-------------------------------------------|-------------------------------------------|
| application/vnd.lime.document-select+json | [Lime.Messaging.Contents.DocumentSelect](https://github.com/takenet/lime-csharp/blob/master/src/Lime.Messaging/Contents/DocumentSelect.cs) |

Allows sending an options menu to customers, the header and options can be, besides **text**, other types of content such as **media link** or **web link**. For each option, it is possible to define a document that is delivered to the contact when the customer performs a choice (depending on the channel support).

#### Example

1 - Menu with image in the header and a link and text as options:
```json
{
    "id": "1",
    "to": "1042221589186385@messenger.gw.msging.net",
    "type": "application/vnd.lime.document-select+json",
    "content": {
        "header": {
            "type": "application/vnd.lime.media-link+json",
            "value": {
                "title": "Welcome to mad hatter",
                "text": "Here we have the best hats to your head.",
                "type": "image/jpeg",
                "uri": "http://petersapparel.parseapp.com/img/item100-thumb.png"
            }
        },
        "options": [
            {
                "label": {
                    "type": "application/vnd.lime.web-link+json",
                    "value": {
                        "text": "Go to site",
                        "uri": "https://petersapparel.parseapp.com/view_item?item_id=100"
                    }
                }
            },
            {
                "label": {
                    "type": "text/plain",
                    "value": "Show stock"
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

2 - Getting the location of a Messenger user:
```json
{
    "id": "2",
    "to": "1042221589186385@messenger.gw.msging.net",
    "type": "application/vnd.lime.document-select+json",
    "content": {
        "scope": "immediate",
        "header": {
            "type": "text/plain",
            "value": "Please, share your location"
        },
        "options": [
            {
                "label": {
                    "type": "application/vnd.lime.input+json",
                    "value": {                      
                        "validation": {
                          "rule": "type",
                          "type": "application/vnd.lime.location+json"
                        } 
                    }
                }
            }
        ]
    }
}
```

For more details, check the [LIME protocol](http://limeprotocol.org/content-types.html#document-select) specification.

#### Mapping on Channels

| Channel              | Type                    | 
|--------------------|-------------------------|
| BLiP App           | Menu (Note: The properties 'label' and 'header' can assign just the PlainText content. The property 'value' of each one of 'options' can assign any type of Document, with exception of DocumentContainer)     |
| Messenger          | [Generic template](https://developers.facebook.com/docs/messenger-platform/send-api-reference/generic-template)|
| SMS                | Text                   |
| Skype              | [Activity](https://docs.botframework.com/en-us/skype/chat/#sending-messages-1)|
| Telegram           | [Message](https://core.telegram.org/bots/api#message)|
