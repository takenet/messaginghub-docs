### Event analysis
| Address               | Base URI     |  C#                 |
|-----------------------|--------------|---------------------|
| postmaster@msging.net (default address - not required) | /event-track | [EventTrackExtension](https://github.com/takenet/messaginghub-client-csharp/blob/master/src/Takenet.MessagingHub.Client/Extensions/EventTrack/EventTrackExtension.cs) |

The **event analysis** extension allows the registration of chatbot's events for creation of analytics reports in the portal. The events are agregated by category, action and day.

#### Exemples
1 - Registering an event:
```json
{  
  "id": "9494447a-2581-4597-be6a-a5dff33af156",
  "method": "set",
  "type": "application/vnd.iris.eventTrack+json",
  "uri": "/event-track",
  "resource": {  
    "category": "Bill",
    "action": "Paid"
  }
}
```
Response on success:
```json
{
  "method": "set",
  "status": "success",
  "id": "9494447a-2581-4597-be6a-a5dff33af156",
  "from": "postmaster@msging.net/#irismsging1",
  "to": "contact@msging.net/default"
}
```


2 - Retrieving stored events:
```json
{  
  "id": "1",
  "method": "get",
  "uri": "/event-track"
}
```
Response on success:
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


3 - Retrieving event counters:

Available *querystring* filters:

| QueryString        | Description                               |
|--------------------|-------------------------------------------| 
| take               | Quantidade de items retornados            |
| filterDate         | Get events from dates res a essa data     |
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
