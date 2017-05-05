### Contatos
| Endereço              | URI base     | Permissões requeridas   | C#              |
|-----------------------|--------------|-------------------------|-----------------|
| postmaster@msging.net (endereço padrão, não é necessário informar) | /contacts | Nenhuma | [ContactExtension](https://github.com/takenet/messaginghub-client-csharp/blob/master/src/Takenet.MessagingHub.Client/Extensions/Contacts/ContactExtension.cs) |

A extensão **contatos** permite o gerenciamento da agenda de contatos do chatbot, que pode ser utilizada para armazenamento dos dados dos clientes do bot. É possível salvar informações como nome, endereço, sexo além de informações genéricas, dentro da propriedade `extras`.

Para informações sobre todos os campos suportados, consulte a documentação do [protocolo Lime](http://limeprotocol.org/resources.html#contact). 

#### Exemplos
1 - Adicionando um contato do Messenger:
```json
{  
  "id": "1",
  "method": "set",
  "uri": "/contacts",
  "type": "application/vnd.lime.contact+json",
  "resource": {
    "identity": "joao@messenger.gw.msging.net",
    "name": "João da Silva",
    "gender":"male",
    "extras": {
      "plan":"Gold",
      "code":"1111"      
    }
  }
}
```
Resposta em caso de sucesso:
```json
{
  "id": "1",
  "from": "postmaster@msging.net/#irismsging1",
  "to": "contact@msging.net/default",
  "method": "set",
  "status": "success"
}
```

2 - Consultando um contato:
```json
{  
  "id": "2",
  "method": "get",
  "uri": "/contacts/joao@messenger.gw.msging.net"
}
```
Resposta em caso de sucesso:
```json
{
  "id": "2",
  "from": "postmaster@msging.net/#irismsging1",
  "to": "contact@msging.net/default",
  "method": "get",
  "status": "success",
  "type": "application/vnd.lime.contact+json",
  "resource": {
    "identity": "joao@messenger.gw.msging.net",
    "name": "João da Silva",
    "gender":"male",
    "extras": {
      "plan":"Gold",
      "code":"1111"      
    }
  }  
}
```

3 - Buscando 3 contatos da agenda de maneira paginada:
```json
{  
  "id": "3",
  "method": "get",
  "uri": "/contacts?$skip=0&$take=3"
}
```
Resposta em caso de sucesso:
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
      {"identity": "joao@messenger.gw.msging.net","name": "João da Silva","gender":"male","extras":{"plan":"Gold","code":"1111"}},
      {"identity": "jose@telegram.gw.msging.net","name": "Zezim do Telegram","email":"ze@gmail.com"},
      {"identity": "5511999990000@take.io","name": "Maria"}
    ]    
  }  
}
```

#### Substituição de variáveis das mensagems

Os campos da agenda de contatos podem ser utilizados para substituir variáveis de mensagens enviadas pelo chatbot.
