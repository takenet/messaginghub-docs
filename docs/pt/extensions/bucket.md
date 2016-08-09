### Armazenamento
| Endereço              | URI base     | Permissões requeridas   | 
|-----------------------|--------------|-------------------------|
| postmaster@msging.net (endereço padrão, não é necessário informar) | /buckets | Nenhuma                 |

A extensão **armazenamento** permite o armazenamento de documentos JSON no servidor em um espaço isolado de cada contato. Para cada documento existe um identificador definido no momento da criação que deve ser utilizada para acesso posterior. É possível definir uma data de expiração opcional para o documento. Tanto o identificador quanto a expiração devem ser definidos na **URI** do comando.

#### Exemplos
Armazenando um documento JSON genérico com o identificador **xyz1234**:

```json
{  
  "id": "1",
  "method": "set",
  "type": "application/json",
  "uri": "/buckets/xyz1234",
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

Armazenando um documento do tipo customizado **application/x-my-type+json** com o identificador **abcd9876** e expiração de 30000 ms (30 segundos):

```json
{  
  "id": "2",
  "method": "set",
  "type": "application/x-my-type+json",
  "uri": "/buckets/abcd9876?expiration=30000",
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

Obtendo um documento existente com o identificador **xyz1234**:

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
