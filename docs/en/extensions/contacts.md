### Contacts
| Address               | Base URI     | C#              |
|-----------------------|--------------|-----------------|
| postmaster@msging.net (default address - not required)) | /contacts | Nenhuma | [ContactExtension](https://github.com/takenet/messaginghub-client-csharp/blob/master/src/Takenet.MessagingHub.Client/Extensions/Contacts/ContactExtension.cs) |

The **contacts** extension allows the management of the chatbot's roster, which can be used to store data of the chatbot clients. It is possible to save information like name, address, gender and generic information, using the `extras` property.

For more information about all the supported fields, please refer to the [protocolo Lime](http://limeprotocol.org/resources.html#contact) documentation.

#### Examples
1 - Adding a Messenger contact:
```json
{  
  "id": "1",
  "method": "set",
  "uri": "/contacts",
  "type": "application/vnd.lime.contact+json",
  "resource": {
    "identity": "11121023102013021@messenger.gw.msging.net",
    "name": "John Deer",
    "gender":"male",
    "extras": {
      "plan":"Gold",
      "code":"1111"      
    }
  }
}
```
Response on success:
```json
{
  "id": "1",
  "from": "postmaster@msging.net/#irismsging1",
  "to": "contact@msging.net/default",
  "method": "set",
  "status": "success"
}
```

2 - Getting a contact:
```json
{  
  "id": "2",
  "method": "get",
  "uri": "/contacts/11121023102013021@messenger.gw.msging.net"
}
```

Response on success:
```json
{
  "id": "2",
  "from": "postmaster@msging.net/#irismsging1",
  "to": "contact@msging.net/default",
  "method": "get",
  "status": "success",
  "type": "application/vnd.lime.contact+json",
  "resource": {
    "identity": "11121023102013021@messenger.gw.msging.net",
    "name": "John Deer",
    "gender":"male",
    "extras": {
      "plan":"Gold",
      "code":"1111"      
    }
  }  
}
```

3 - Getting 3 contacts in the roster with paging:
```json
{  
  "id": "3",
  "method": "get",
  "uri": "/contacts?$skip=0&$take=3"
}
```
Response on success:
```json
{
  "id": "3",
  "from": "postmaster@msging.net/#irismsging1",
  "to": "contact@msging.net/default",
  "method": "get",
  "status": "success",
  "type": "application/vnd.lime.collection+json",
  "resource": {
    "itemType":"application/vnd.lime.contact+json",
    "total":10,
    "items": [
      {"identity": "11121023102013021@messenger.gw.msging.net","name": "John Deer","gender":"male","extras":{"plan":"Gold","code":"1111"}},
      {"identity": "213121@telegram.gw.msging.net","name": "Joseph from Telegram","email":"ze@gmail.com"},
      {"identity": "5511999990000@take.io","name": "Mary"}
    ]    
  }  
}
```

#### Message variable replacement

The contacts fields can be used to replace variables on messages sent by the chatbot. To active the replacement in a message, the `metadata` key `#message.replaceVariables` should be present with the value `true` and the message text should have variables in the  `${contact.<propertyName>}` format, where `<propertyName>` is the contact property for replacement.

Os campos da agenda de contatos podem ser utilizados para substituir variáveis de mensagens enviadas pelo chatbot. Para ativar a substituição, é necessário informar no campo `metadata` da mensagem a chave `#message.replaceVariables` com valor `true` e incluir no texto da mensagem as variáveis no formato `${contact.<propertyName>}`, onde `<propertyName>` é a propriedade do contato para substituição. É possível a substituição de todos os campos do contato, inclusive de chaves na propriedade `extras`. Neste caso, basta utilizar a convenção `${contact.extras.<extraPropertyName>}`, sendo `<extraPropertyName>` o valor para substituição.

#### Exemplos

1 - Enviando uma mensagem incluindo o nome do contato:
```json
{  
  "id": "1",
  "to": "11121023102013021@messenger.gw.msging.net",
  "type": "text/plain",
  "value": "Olá, ${contact.name}, seja bem vindo ao plano ${contact.extras.plan}!",
  "metadata": {
    "#message.replaceVariables": "true"
  }
}
```

Neste exemplo, a mensagem final que será entregue ao cliente será:
```json
{  
  "id": "1",
  "to": "11121023102013021@messenger.gw.msging.net",
  "type": "text/plain",
  "value": "Olá, João da Silva, seja bem vindo ao plano Gold!",
  "metadata": {
    "#message.replaceVariables": "true"
  }
}
```
