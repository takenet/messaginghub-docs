### Resources
| Endereço              | URI base     | Permissões requeridas       | C#              |
|-----------------------|--------------|-----------------------------|------------------
| postmaster@msging.net (endereço padrão, não é necessário informar) | /resources | Nenhuma | [ResourceExtension](https://github.com/takenet/messaginghub-client-csharp/blob/master/src/Takenet.MessagingHub.Client/Extensions/Resource/ResourceExtension.cs) |

A extensão **recursos** permite o armazenamento de documentos no servidor em um espaço isolado de cada chatbot, de forma semelhante à extensão **armazenamento**. A diferença principal é que estes documentos podem ser mapeados como **conteúdo de mensagens** enviadas aos clientes da plataforma, através do **identificador** de cada recurso. Isso significa que o desenvolvedor do chatbot pode optar em **armazenar o conteúdo de suas mensagens no servidor**, ao invés de manter no lado da aplicação. 

Para realizar o envio de uma mensagem de recurso, o desenvolvedor deve utilizar o tipo de conteúdo **Recurso**. Para mais informações, 

O portal **BLiP** oferece uma interface para gerenciamento destes recursos, o que auxilia em caso de edições destes conteúdos, dispensando a necessidade de atualizar o código no lado da aplicação em caso de mudanças no conteúdo das mensagens do chatbot.

#### Exemplos
1 - Armazenando um recurso do tipo **link de mídia** com o identificador **xyz1234**:
```json
{  
  "id": "1",
  "method": "set",
  "uri": "/resources/xyz1234",
  "type": "application/vnd.lime.media-link+json",
  "resource": {
    "title": "Gato",
    "text": "Segue uma imagem de um gato",
    "type": "image/jpeg",
    "uri": "http://2.bp.blogspot.com/-pATX0YgNSFs/VP-82AQKcuI/AAAAAAAALSU/Vet9e7Qsjjw/s1600/Cat-hd-wallpapers.jpg",
    "size": 227791,
    "previewUri": "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcS8qkelB28RstsNxLi7gbrwCLsBVmobPjb5IrwKJSuqSnGX4IzX",
    "previewType": "image/jpeg"
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

2 - Armazenando um documento do tipo customizado **application/x-my-type+json** com o identificador **abcd9876** e expiração de 30000 ms (30 segundos):
```json
{  
  "id": "2",
  "method": "set",
  "uri": "/resources/abcd9876?expiration=30000",
  "type": "application/x-my-type+json",
  "resource": {  
    "myTypeKey1": "value1",
    "myTypeKey2": 2
  }
}
```
Resposta em caso de sucesso:
```json
{
  "id": "2",
  "from": "postmaster@msging.net/#irismsging1",
  "to": "contact@msging.net/default",
  "method": "set",
  "status": "success"
}
```
