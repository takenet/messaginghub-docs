### Controlador de eventos
| Endereço              | URI base     | Permissões requeridas   | C#                 |
|-----------------------|--------------|-------------------------|--------------------|
| postmaster@msging.net (endereço padrão, não é necessário informar) | /event-track | Nenhuma | [EventTrackExtension](https://github.com/takenet/messaginghub-client-csharp/blob/master/src/Takenet.MessagingHub.Client/Extensions/EventTrack/EventTrackExtension.cs) |

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
  "id": "1",
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

Possíveis filtros via querystring:

| QueryString        | Observação                                |
|--------------------|-------------------------------------------| 
| take               | Quantidade de items retornados            |
| filterDate         | Buscar eventos anteriores a essa data     |
```json
{  
  "id": "1",
  "method": "get",
  "uri": "/event-track/boleto"
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
