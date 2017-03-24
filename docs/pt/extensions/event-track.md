### Análise de eventos
| Endereço              | URI base     | Permissões requeridas   | C#                 |
|-----------------------|--------------|-------------------------|--------------------|
| postmaster@msging.net (endereço padrão, não é necessário informar) | /event-track | Nenhuma | [EventTrackExtension](https://github.com/takenet/messaginghub-client-csharp/blob/master/src/Takenet.MessagingHub.Client/Extensions/EventTrack/EventTrackExtension.cs) |

A extensão **análise de eventos** permite o chatbot registrar eventos no **BLiP Messaging Hub** permitindo assim extrair relatórios. 

Caso seja registrado o mesmo evento/ação uma segunda vez no mesmo dia será somado um ao valor atual do contador.

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
    "action": "Vencido"
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
  "method": "get",
  "status": "success",
  "id": "1",
  "from": "postmaster@msging.net/#irismsging1",
  "to": "contact@msging.net/default",
  "resource": [{
      "category": "Boleto"
  },
  {
      "category": "Cartão"
  }]
}
```


3 - Recuperando contadores do evento:

Possíveis filtros via *querystring*:

| QueryString        | Observação                                |
|--------------------|-------------------------------------------| 
| take               | Quantidade de items retornados            |
| filterDate         | Buscar eventos anteriores a essa data     |
```json
{  
  "id": "57aa0ac2-158c-4012-9f18-b8eedaede85c",
  "method": "get",
  "uri": "/event-track/boleto"
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
  "resource": [{
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
```
