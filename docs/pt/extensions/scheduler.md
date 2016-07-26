### Scheduler
| Endereço                        | URI base     | Permissões requeridas   | 
|---------------------------------|--------------|-------------------------|
| postmaster@scheduler.msging.net | /schedule    | Envio de mensagens      |

A extensão **scheduler** permite o agendamento do envio de mensagens em nome dos contatos.

#### Delegação
Para dar as permissões requeridas pela extensão, é necessário enviar um comando de delegação:

```json
{  
  "id": "985ae07e-84eb-40fb-a3e1-6e9f20a29eb7",
  "method": "set",
  "type": "application/vnd.lime.delegation+json",
  "uri": "/delegations",
  "resource": {  
    "target": "postmaster@scheduler.msging.net",
    "envelopeTypes": [  
      "message"
    ]
  }
}
```
Resposta em caso de sucesso:
```json
{
  "method": "set",
  "status": "success",
  "id": "985ae07e-84eb-40fb-a3e1-6e9f20a29eb7",
  "from": "postmaster@msging.net/#irismsging1",
  "to": "contact@msging.net/default"
}
```

#### Exemplos
Agendando uma nova mensagem:
```json
{  
  "id": "456bf289-9f12-4de2-9852-21538a47bf57",
  "to": "postmaster@scheduler.msging.net",
  "method": "set",
  "uri": "/schedules",
  "type": "application/vnd.iris.schedule+json",
  "resource": {  
    "message": {  
      "id": "ad19adf8-f5ec-4fff-8aeb-2e7ebe9f7a67",
      "to": "destination@msging.net",
      "type": "text/plain",
      "content": "Teste agendamento"
    },
    "when": "2016-07-25T17:50:00.000Z"
  }
}
```

Resposta em caso de sucesso:
```json
{  
  "method": "set",
  "status": "success",
  "id": "456bf289-9f12-4de2-9852-21538a47bf57",
  "from": "postmaster@scheduler.msging.net/#irismsging1",
  "to": "contact@msging.net/default"
}
```
