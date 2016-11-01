### Controlador de eventos
| Endereço              | URI base     | Permissões requeridas   | C#                 |
|-----------------------|--------------|-------------------------|--------------------|
| postmaster@msging.net (endereço padrão, não é necessário informar) | /event-track | Nenhuma | [EventTrackExtension](https://github.com/takenet/messaginghub-client-csharp/blob/master/src/Takenet.MessagingHub.Client/Extensions/EventTrack/EventTrackExtension.cs) |

A extensão **controlador de eventos** permite o contato registrar eventos no **Blip Messaging Hub** permitindo assim extrair relatórios. 

Caso seja registrado o mesmo evento/ação uma segunda vez no mesmo dia será somado um ao valor atual do contador.

#### Exemplos
1 - Registrando um evento:
```json
{  
  "id": "9494447a-2581-4597-be6a-a5dff33af156",
  "method": "set",
  "type": "application/vnd.lime.event-tracker+json",
  "uri": "/event-track",
  "resource": {  
    "event": "SeriesBreakingBad",
    "action": "Play"
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


2 - Recuperando eventos por dia:

Possíveis filtros via *querystring*:

| QueryString        | Observação                                |
|--------------------|-------------------------------------------| 
| take               | Quantidade de items retornados            |
| filterDate         | Buscar eventos anteriores a essa data     |
```json
{  
  "id": "57aa0ac2-158c-4012-9f18-b8eedaede85c",
  "method": "get",
  "uri": "/event-track"
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
      "event": "SeriesBreakingBad",
      "action": "Play",
      "storageDate": "2016-01-01",
      "count": 10
  },
  {
      "event": "SeriesBreakingBad",
      "action": "Play",
      "storageDate": "2016-01-02",
      "count": 20
  }]
}
```
