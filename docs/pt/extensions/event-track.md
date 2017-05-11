### Análise de eventos
| Endereço              | URI base     | Permissões requeridas   | C#                 |
|-----------------------|--------------|-------------------------|--------------------|
| postmaster@msging.net (endereço padrão, não é necessário informar) | /event-track | Nenhuma | [EventTrackExtension](https://github.com/takenet/messaginghub-client-csharp/blob/master/src/Takenet.MessagingHub.Client/Extensions/EventTrack/EventTrackExtension.cs) |

A extensão **análise de eventos** permite o chatbot registrar eventos no **BLiP Messaging Hub** permitindo assim extrair relatórios. Os relatórios podem ser gerados através do [portal](https://portal.blip.ai), na opção *Painel* -> *Análise de dados*.

Cada evento informado deve possuir as seguintes propriedades:

| Propriedade  | Descrição                                                          | Exemplo |
|--------------|--------------------------------------------------------------------|---------|
| **category** | Categoria para agregação de eventos relacionados.                  | Boleto  |
| **action**   | Ação relacionada ao evento. A contagem é feita a partir das ações. | Pago    |
| **extras**   | Informações extras opcionais para armazenamento junto ao evento.   | {"customerId": "41231", "paymentId": "ca82jda"} |

Caso seja registrado uma mesma categoria/ação uma segunda vez no mesmo dia será somado um ao valor atual do contador.

#### Exemplos
1 - Registrando um evento:
```json
{  
  "id": "9494447a-2581-4597-be6a-a5dff33af156",
  "method": "set",
  "type": "application/vnd.iris.eventTrack+json",
  "uri": "/event-track",
  "resource": {  
    "category": "Boleto",
    "action": "Vencido",
    "extras": {
      "expiration": "2015-12-30",
      "customerId": "199213"
    }
  }
}
```
Resposta em caso de sucesso:
```json
{
  "method": "set",
  "status": "success",
  "id": "9494447a-2581-4597-be6a-a5dff33af156",
  "from": "postmaster@msging.net/#irismsging1",
  "to": "contact@msging.net/default"
}
```


2 - Recuperando lista de eventos:
```json
{  
  "id": "1",
  "method": "get",
  "uri": "/event-track"
}
```
Resposta em caso de sucesso:
```json
{  
  "id": "1",
  "from": "postmaster@msging.net/#irismsging1",
  "to": "contact@msging.net/default",
  "method": "get",
  "status": "success",
  "type": "application/vnd.lime.collection+json",
  "resource": {
    "itemType": "application/vnd.iris.eventTrack+json",
    "items": [{
        "category": "Boleto"
    },
    {
        "category": "Cartão"
    }]
  }
}
```

3 - Obtendo os contadores do evento:

Possíveis filtros via *querystring*:

| QueryString  | Observação                          |
|--------------|-------------------------------------| 
| $take        | Limite de itens a serem retornados  |
| startDate    | Buscar eventos a partir desta data  |
| endDate      | Buscar eventos até esta data        |

```json
{  
  "id": "57aa0ac2-158c-4012-9f18-b8eedaede85c",
  "method": "get",
  "uri": "/event-track/Boleto?startDate=2016-01-01&$take=10"
}
```

Resposta em caso de sucesso:
```json
{
  "id": "57aa0ac2-158c-4012-9f18-b8eedaede85c",
  "from": "postmaster@msging.net/#irismsging1",
  "to": "contact@msging.net/default",
  "method": "get",
  "status": "success",  
  "type": "application/vnd.lime.collection+json",
  "resource": {
    "itemType": "application/vnd.iris.eventTrack+json",
    "items": [{
        "category": "Boleto",
        "action": "Vencido",
        "storageDate": "2016-01-01",
        "count": 10
    },
    {
        "category": "Boleto",
        "action": "Vencido",
        "storageDate": "2016-01-02",
        "count": 20
    }]
  }
}
```

4 - Obtendo os detalhes dos eventos para uma categoria e ação:

Possíveis filtros via *querystring*:

| QueryString  | Observação                                       |
|--------------|--------------------------------------------------| 
| $skip        | Número de itens a serem ignorados para paginação |
| $take        | Limite de itens a serem retornados               |
| startDate    | Buscar eventos a partir desta data               |
| endDate      | Buscar eventos até esta data                     |

```json
{  
  "id": "57aa0ac2-158c-4012-9f18-b8eedaede85c",
  "method": "get",
  "uri": "/event-track/Boleto/Vencido?startDate=2016-01-01&$take=10"
}
```

Resposta em caso de sucesso:
```json
{
  "method": "get",
  "status": "success",
  "id": "57aa0ac2-158c-4012-9f18-b8eedaede85c",
  "from": "postmaster@msging.net/#irismsging1",
  "to": "contact@msging.net/default",
  "type": "application/vnd.lime.collection+json",
  "resource": {
    "itemType": "application/vnd.iris.eventTrack+json",
    "items": [{
        "category": "Boleto",
        "action": "Vencido",
        "storageDate": "2016-01-01T12:30:00.000Z",
        "extras": {
          "expiration": "2015-12-30",
          "customerId": "199213"
        }      
    },
    {
        "category": "Boleto",
        "action": "Vencido",
        "storageDate": "2016-01-02T09:15:00.000Z",
        "extras": {
          "expiration": "2016-01-01",
          "customerId": "4123123"
        }  
    }]
  }
}
```

