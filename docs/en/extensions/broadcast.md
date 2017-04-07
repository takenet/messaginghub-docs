### Envio em massa
| Address                         | Base URI     | Required permissions    | C#                     |
|---------------------------------|--------------|-------------------------|------------------------|
| postmaster@broadcast.msging.net | /lists       | Send Messages           | [BroadcastExtension](https://github.com/takenet/messaginghub-client-csharp/blob/master/src/Takenet.MessagingHub.Client/Extensions/Broadcast/BroadcastExtension.cs) |

The extension ** broadcast ** allows creation and management of distribution lists and their members for sending broadcast. Thus, a chatbot that needs to send the same message for more than one recipient can create a list with address of recipients and perform the braodcast only once, to the address list.

Each distribution list has a unique address in the format `list-name@broadcast.msging.net` in addition to the members, who are the recipients of messages sent to this list. Only the chatbot that created a remote list has permissions to send messages to it.

Notifications are forwarded to the chatbot when received by the extension.

#### Default lists

BLiP automatically creates a distribution list with all addresses that have already contacted your chatbot. Its address is `[identifier] + senders @ broadcast.msging.net`, being `identifier` the identifier of your chatbot, which is used with the access key for authentication.

For example, for a chatbot with identifier `mychatbot`, this list address would be `mychatbot+senders@broadcast.msging.net`.

#### Examples

1 - Creating a distribution list:
```json
{  
  "id": "1",
  "to": "postmaster@broadcast.msging.net",
  "method": "set",
  "type": "application/vnd.iris.distribution-list+json",
  "uri": "/lists",
  "resource": {  
    "identity": "news@broadcast.msging.net"
  }
}
```
Response on success:
```json
{
  "id": "1",
  "from": "postmaster@broadcast.msging.net/#irismsging1",
  "to": "contact@msging.net/default",
  "method": "set",
  "status": "success"
}
```

2 - Adding a member to the existing distribution list:
```json
{  
  "id": "2",
  "to": "postmaster@broadcast.msging.net",
  "method": "set",
  "uri": "/lists/news@broadcast.msging.net/recipients",
  "type": "application/vnd.lime.identity",
  "resource": "551100001111@0mn.io"
}
```
Response on success:
```json
{
  "id": "2",
  "from": "postmaster@broadcast.msging.net/#irismsging1",
  "to": "contact@msging.net/default",
  "method": "set",
  "status": "success"
}
```

3 - Removing a member from the existing distribution list:
```json
{  
  "id": "3",
  "to": "postmaster@broadcast.msging.net",
  "method": "delete",
  "uri": "/lists/noticias@broadcast.msging.net/recipients/551100001111@0mn.io"
}
```
Response on success:
```json
{
  "id": "3",
  "from": "postmaster@broadcast.msging.net/#irismsging1",
  "to": "contact@msging.net/default",
  "method": "set",
  "status": "success"
}
```

4 - Sending a message to the distribution list:
```json
{  
  "id": "4",
  "to": "news@broadcast.msging.net",
  "type": "text/plain",
  "content": "Hello participants of this list!"
}
```
Notifications sent by extension **distribution list**:
```json
{
  "id": "4",
  "from": "postmaster@broadcast.msging.net/#irismsging1",
  "to": "contact@msging.net/default",
  "event": "received"
}
```
```json
{
  "id": "4",
  "from": "postmaster@broadcast.msging.net/#irismsging1",
  "to": "contact@msging.net/default",
  "event": "consumed"
}
```
Notifications sent by list members to the distribution list and forwarded to the list owner (the recipient address is encoded in the notification originator instance):

```json
{
  "id": "4",
  "from": "news@broadcast.msging.net/551100001111%400mn.io%2Fdefault",
  "to": "contact@msging.net/default",
  "event": "received"
}
```

#### Delegation
This extension already has send permissions on behalf of chatbotos, so it is not necessary to perform delegation.

#### Availability

The Broadcast service is available in the following domains:

|Domain     |Available  |Observation                                            |
|---	      |---	      |---                                                    |
|Messenger  |x          |Needed initial user interaction with chatbot           |
|BLiP App   |x          |Not necessary initial user interaction with chatbot    |
|Skype      |x          |Needed initial user interaction with chatbot           |
|SMS        |x          |Not necessary initial user interaction with chatbot    |
|Telegram   |x          |Needed initial user interaction with chatbot           |
