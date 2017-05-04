
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
    "name": "João da Silva"
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


#### Substituição de variáveis das mensagems

Os campos da agenda de contatos podem ser utilizados para substituir variáveis de mensagens enviadas pelo chatbot.
