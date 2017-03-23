### Texto
| MIME type                | C#                                  |
|--------------------------|-------------------------------------|
| text/plain               | [Lime.Messaging.Contents.PlainText](https://github.com/takenet/lime-csharp/blob/master/src/Lime.Messaging/Contents/PlainText.cs) |

Allows sending and receiving simple text messages.

#### Example

Sending a message for a Omni recipient:

```json
{
    "id": "1",
    "to": "553199991111@0mn.io",
    "type": "text/plain",
    "content": "Welcome to our service! How can I help you ?"
}
```

For more details, check the especification of [LIME protocol](http://limeprotocol.org/content-types.html#text).

#### Mapping on channels

| Channel              | Type                    | 
|--------------------|-------------------------|
| BLiP App           | Text                   |
| Messenger          | [Text message](https://developers.facebook.com/docs/messenger-platform/send-api-reference/text-message)|
| SMS                | Text                   |
| Skype              | [Activity](https://docs.botframework.com/en-us/skype/chat/#sending-messages-1)|
| Telegram           | [Message](https://core.telegram.org/bots/api#message)|

