### Localização
| MIME type                            | C#                                   |
|--------------------------------------|--------------------------------------|
| application/vnd.lime.location+json | [Lime.Messaging.Contents.Location](https://github.com/takenet/lime-csharp/blob/master/src/Lime.Messaging/Contents/Location.cs) |

Permite o envio e recebimento de informações geográficas. 

#### Exemplo
1 - Enviando uma localização com latitude, longitude e altitude:
```json
{
    "id": "1",
    "to": "1042221589186385@messenger.gw.msging.net",
    "type": "application/vnd.lime.location+json",
    "content": {
        "latitude": -19.918899,
        "longitude": -43.959275,
        "altitude": 853,
        "text": "Sede da Take.net"
    }
}
```

Em C#:
```csharp
var location = new Location
{
    Latitude = -19.918899,
    Longitude = -43.959275,
    Altitude = 853,
    Text = "Sede da Take.net"
};
```

2 - Enviando uma requisição para localização do usuário:
```json
{
    "type": "application/vnd.lime.input+json",
    "value": {
        "label": {
            "type": "text/plain",
            "value": "Envie sua localização"
        },
        "validation": {
            "rule": "type",
            "type": "application/vnd.lime.location+json"
        }
    }
}
```

Em C#:
```csharp
var locationInput = new Input
{
    Label = new DocumentContainer
    {
        Value = new PlainText
        {
            Text = "Envie sua localização"
        }
    },
    Validation = new InputValidation
    {
        Type = Location.MediaType,
        Rule = InputValidationRule.Type
    }
};
```

Para mais detalhes, consulte a especificação do [protocolo LIME](http://limeprotocol.org/content-types.html#location).

### Mapeamento nos canais

| Canal              | Tipo                    | 
|--------------------|-------------------------|
| BLiP App           | Localização             |
| Messenger          | [Generic template](https://developers.facebook.com/docs/messenger-platform/send-api-reference/generic-template)|
| SMS                | Texto com link          |
| Skype              | [Activity](https://docs.botframework.com/en-us/skype/chat/#sending-messages-1)|
| Telegram           | [Location](https://core.telegram.org/bots/api#location)|

