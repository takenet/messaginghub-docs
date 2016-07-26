### Broadcast
| Endereço                        | URI base     | Permissões requeridas   | 
|---------------------------------|--------------|-------------------------|
| postmaster@broadcast.msging.net | /lists       | Envio de mensagens      |

A extensão **broadcast** permite o gerenciamento de listas de distribuição e o envio de mensagem em massa.

#### Delegação
Para dar as permissões requeridas pela extensão, é necessário enviar um comando de delegação:

```json
{  
  "id": "985ae07e-84eb-40fb-a3e1-6e9f20a29eb7",
  "method": "set",
  "type": "application/vnd.lime.delegation+json",
  "uri": "/delegations",
  "resource": {  
    "target": "postmaster@broadcast.msging.net",
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
