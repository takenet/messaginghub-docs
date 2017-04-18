### Bucket
| Endereço              | URI base     | C#              |
|-----------------------|--------------|-----------------|
| postmaster@msging.net (default address - not required) | /buckets | [BucketExtension](https://github.com/takenet/messaginghub-client-csharp/blob/master/src/Takenet.MessagingHub.Client/Extensions/Bucket/BucketExtension.cs) |

The **bucket** extension allows the storage of documents in the server on a private chatbot's container. This extensions is useful to store information about the clients that have interacted with the chatbot, like preferences and navigation state.

Each document have an **identifier** which is provided during the write operation and this identifier should be used for retrieving the value later. It is possible to set an optional **expiration date** for the document. Both the identifier and the expiration date are specified in the **URI** of the command which is sent to the extension.

#### Exemples
1 - Armazenando um documento JSON genérico com o identificador **xyz1234**:
```json
{  
  "id": "1",
  "method": "set",
  "uri": "/buckets/xyz1234",
  "type": "application/json",
  "resource": {  
    "key1": "value1",
    "key2": 2,
    "key3": [  
      "3a", "3b", "3c"
    ]
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
  "uri": "/buckets/abcd9876?expiration=30000",
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

3 - Obtendo um documento existente com o identificador **xyz1234**:
```json
{  
  "id": "3",
  "method": "get",
  "uri": "/buckets/xyz1234"
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
  "type": "application/json",
  "resource": {  
    "key1": "value1",
    "key2": 2,
    "key3": [  
      "3a", "3b", "3c"
    ]
  }  
}
```
