### Sensitive Information

| MIME type                            | C#                                 |
|--------------------------------------|------------------------------------|
| application/vnd.lime.sensitive+json  | [Lime.Messaging.Contents.SensitiveContainer](https://github.com/takenet/lime-csharp/blob/master/src/Lime.Messaging/Contents/SensitiveContainer.cs) |

This type wrapper a message content in order to signal that informations is confidential or sensitive. Thus, the server will handle the message in a different way and will not storing anything. The wrapped content can be of any available BLiP type.

**Important Note**: Any external channel (e.g. *Messenger*, *Telegram*) **can storage your sensitive informations**. Pay attention on particular security police of each channel.

#### Examples
1 - Sending a password using text content for a Messenger user:
```json
{
  "id": "1",
  "to": "1334448251684655@messenger.gw.msging.net",
  "type": "application/vnd.lime.sensitive+json",
  "content": {
    "type": "text/plain",
    "value": "Your password is 123456"
  }
}

```

2 - Sending a weblink:
```json
{
  "id": "2",
  "to": "1334448251684655@messenger.gw.msging.net",
  "type": "application/vnd.lime.sensitive+json",
  "content": {
    "type": "application/vnd.lime.web-link+json",
    "value": {
      "text": "Follow the link to finish your account",
      "uri": "https://mystore.com/checkout?ID=A8DJS1JFV98AJKS9"
    }
  }
}

```
