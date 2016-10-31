### Controlador de eventos
| Endereço              | URI base     | Permissões requeridas   | C#                 |
|-----------------------|--------------|-------------------------|--------------------|
| postmaster@msging.net (endereço padrão, não é necessário informar) | /event-track | Nenhuma | [EventTrackerExtension](https://github.com/takenet/messaginghub-client-csharp/blob/master/src/Takenet.MessagingHub.Client/Extensions/EventTracker/EventTrackerExtension.cs) |

A extensão **controlador de eventos** permite o contato registrar eventos no **Blip Messaging Hub** permitindo assim extrair relatorios. 

Caso seja registrado o mesmo evento/ação uma segunda vez no mesmo dia sera somado um contador.

#### Exemplos
1 - Registrando um evento:
```json
{  
  "id": "1",
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
  "id": "1",
  "from": "postmaster@msging.net/#irismsging1",
  "to": "contact@msging.net/default"
}
```


2 - Recuperando eventos por dia:

Possíveis filtros via querystring:
|QueryString        |Observação                                   |
|---|---| 
|take              |Quantidade de items retornados               |
|filterDate         |Buscar eventos anteriores a essa data   |

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
