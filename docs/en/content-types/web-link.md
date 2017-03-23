### Link da web
| MIME type                | C#                                  |
|--------------------------|-------------------------------------|
| application/vnd.lime.web-link+json               | [Lime.Messaging.Contents.WebLink](https://github.com/takenet/lime-csharp/blob/master/src/Lime.Messaging/Contents/WebLink.cs) |

Allows sending a link to a webpage, it is possible to include metadata such as title and a descriptive text of the link, and also a miniature image. 

#### Example

Sending a message to a BLiP App recipient:

```json
{
    "id": "1",
    "to": "553199991111@0mn.io",
    "type": "application/vnd.lime.web-link+json",
    "content": { 
        "uri": "http://limeprotocol.org/content-types.html#web-link",
        "target": "self",
        "text": "Here is a documentation web-link"        
    }
}
```

In some channels is possible to define how the webpage will be diplayed (on the same window, openning a new window or occuping part of device window) through `target` property. For more details, check the [LIME protocol](http://limeprotocol.org/content-types.html#web-link) specification.

#### Mapping on Channels

| Channel              | Type                    | 
|--------------------|-------------------------|
| BLiP App           | Web Link                |
| Messenger          | [Generic template](https://developers.facebook.com/docs/messenger-platform/send-api-reference/generic-template) or [Button](https://developers.facebook.com/docs/messenger-platform/send-api-reference/buttons) (if used with the [Multimedia Menu](https://blip.ai/portal/#/docs/content-types/document-select)). |
| SMS                | Text with link          |
| Skype              | [Activity](https://docs.botframework.com/en-us/skype/chat/#sending-messages-1)|
| Telegram           | [Message](https://core.telegram.org/bots/api#message)|


In some channels, it is possible to use special [URI schemes](https://en.wikipedia.org/wiki/Uniform_Resource_Identifier) for the links creation with specific behaviors;

| Channel     | URI Scheme | Description                                                           | Example              |
|-----------|------------|---------------------------------------------------------------------|----------------------|
| Messenger | `tel`      | Defines a link for the telephone call to the specific number. Mapped to a [Call button](https://developers.facebook.com/docs/messenger-platform/send-api-reference/call-button). | `tel:+5531999990000` |
| Messenger | `share`    | Defines a link to share current message. Mapped to a [Share button](https://developers.facebook.com/docs/messenger-platform/send-api-reference/share-button).  | `share:`             |

- On Messenger, these **URI schemes** are valid only if utilized together with a multimedia [Multimedia Menu](https://blip.ai/portal/#/docs/content-types/document-select).
- To enable the use of [Messenger extensions](https://developers.facebook.com/docs/messenger-platform/messenger-extension) on link webpage, you must add on URL *query string* the `messengerExtensions` parameter with value `true`. For above sample, the `uri` value would be as follows: `http://limeprotocol.org/content-types.html#web-link?messengerExtensions=true`


