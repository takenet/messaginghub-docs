### Menu
| MIME type                                 | C#                                        |
|-------------------------------------------|-------------------------------------------|
| application/vnd.lime.select+json | [Lime.Messaging.Contents.Select](https://github.com/takenet/lime-csharp/blob/master/src/Lime.Messaging/Contents/Select.cs) |

Allows sending an option menu to customers to make a choice. The header and the options are kind of type, it is possible to define a document that may be delivered to the chatbot when the customer makes a choice (depending on the channel support). The options can be optionally numbered.

Some channels support the options scope limitation, which determines for how much time they are valid for the user selection. For example, in some cases, the sent options can only be selected by the customer at that time and may disappear after the choice. In this case, the scope is **immediate**. In others, the options are valid for the selection at any time, and the scope is **persistent**.

For more details, check the [LIME protocol](http://limeprotocol.org/content-types.html#select) specification.

#### Example
Menu with numbered options
```json
{
    "id":"311F87C0-F938-4FF3-991A-7C5AEF7771A5",
    "to":"1042221589186385@messenger.gw.msging.net",
    "type":"application/vnd.lime.select+json",
    "content":{
        "text":"Choice an option",
        "options":[
            {
                "order":1,
                "text":"First option"
            },
            {
                "order":2,
                "text":"Second option"
            },
            {
                "order":3,
                "text":"Third option",
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
When the user selects one option, a message returns according to the rule:

- If the option contains the field 'value' it will be returned.
- In the opposite case, the 'order' filed value will be returned if it is fulfilled.
- If none of the mentioned values is fulfilled, field 'text' will be returned.

Return example of the above mentioned menu:

When selecting the first option:
```json
{
    "id": "f8cf7a7a-be4f-473a-8516-60d55534b5a6",
    "from": "1042221589186385@messenger.gw.msging.net",
    "to": "blipcontact@msging.net",
    "type": "text/plain",
    "content": "1"
}
```
When selecting the second option:
```json
{
    "id": "76CB408D-39E6-4212-8AA1-7435B42A6993",
    "from": "1042221589186385@messenger.gw.msging.net",
    "to": "blipcontact@msging.net",
    "type": "text/plain",
    "content": "2"
}
```
Least, when selecting the third option:
```json
{
    "id": "035E675C-D25B-437D-80BD-057AD6F70671",
    "from": "1042221589186385@messenger.gw.msging.net",
    "to": "blipcontact@msging.net",
    "type": "application/json",
    "content": {
        "key1":"value1",
        "key2":2
    }
}
```

The return message *type* will always be the same of the chosen option. When a value for the field *value* is not defined, the type will be `text/plain`.

#### Mapping on Channels

| Channel              | Type                    | 
|--------------------|-------------------------|
| BLiP App           | Menu (Note: The property 'value' of each one of 'options' can assing pode any type of Document, with exception of DocumentContainer)     |
| Messenger          | [Button template](https://developers.facebook.com/docs/messenger-platform/send-api-reference/button-template) (on default scope) e [Quick replies](https://developers.facebook.com/docs/messenger-platform/send-api-reference/quick-replies) (on *immediate* scope)|
| SMS                | Text                  |
| Skype              | [Activity](https://docs.botframework.com/en-us/skype/chat/#sending-messages-1)|
| Telegram           | [Message](https://core.telegram.org/bots/api#message)|
