### Envio em massa
| Endereço                        | URI base     | Permissões requeridas   | 
|---------------------------------|--------------|-------------------------|
| postmaster@broadcast.msging.net | /lists       | Envio de mensagens      |

A extensão **envio em massa** permite a criação e gestão de listas de distribuição e seus membros para o envio de mensagem em massa. Desta forma, um contato que precisa enviar uma mesma mensagem para mais de um destinatário pode criar uma lista com os endereços dos destinatários e realizar o envio apenas uma vez, para o endereço da lista.

Cada lista de distribuição possui um endereço único no formato `nome-da-lista@broadcast.msging.net` além dos membros, que são os destinatários de mensagens enviadas a esta lista. Somente o contato que criou uma determinada lista tem permissões de enviar mensagens a mesma.

As notificações são encaminhadas ao contato quando recebidas pela extensão.

#### Exemplos

##### Criando uma nova lista de distribuição:
```json
{  
  "id": "1",
  "to": "postmaster@broadcast.msging.net",
  "method": "set",
  "type": "application/vnd.iris.distribution-list+json",
  "uri": "/lists",
  "resource": {  
    "identity": "noticias@broadcast.msging.net"
  }
}
```
Resposta em caso de sucesso:
```json
{
  "id": "1",
  "from": "postmaster@broadcast.msging.net/#irismsging1",
  "to": "contact@msging.net/default",
  "method": "set",
  "status": "success"
}
```

##### Adicionando um membro a lista de distribuição existente:
```json
{  
  "id": "2",
  "to": "postmaster@broadcast.msging.net",
  "method": "set",
  "uri": "/lists/noticias@broadcast.msging.net/recipients",
  "type": "application/vnd.lime.identity",
  "resource": "551100001111@0mn.io"
}
```
Resposta em caso de sucesso:
```json
{
  "id": "2",
  "from": "postmaster@broadcast.msging.net/#irismsging1",
  "to": "contact@msging.net/default",
  "method": "set",
  "status": "success"
}
```

##### Removendo um membro a lista de distribuição existente:
```json
{  
  "id": "3",
  "to": "postmaster@broadcast.msging.net",
  "method": "delete",
  "uri": "/lists/noticias@broadcast.msging.net/recipients/551100001111@0mn.io"
}
```
Resposta em caso de sucesso:
```json
{
  "id": "3",
  "from": "postmaster@broadcast.msging.net/#irismsging1",
  "to": "contact@msging.net/default",
  "method": "set",
  "status": "success"
}
```

##### Enviando uma mensagem para a lista de distribuição:
```json
{  
  "id": "4",
  "to": "noticias@broadcast.msging.net",
  "type": "text/plain",
  "content": "Olá participantes desta lista!"
}
```
Notificações enviadas pela extensão **lista de distribuição**:
```json
{
  "id": "4",
  "from": "postmaster@broadcast.msging.net/#irismsging1",
  "to": "contact@msging.net/default",
  "event": "received"
}
```
```json
{
  "id": "4",
  "from": "postmaster@broadcast.msging.net/#irismsging1",
  "to": "contact@msging.net/default",
  "event": "consumed"
}
```
Notificações enviadas pelos membros da lista à lista de distribuição e encaminhadas ao proprietário da lista (o endereço do destinatário está codificado na instância do originador da notificação):

```json
{
  "id": "4",
  "from": "noticias@broadcast.msging.net/551100001111%400mn.io%2Fdefault",
  "to": "contact@msging.net/default",
  "event": "received"
}
```

#### Delegação
Para dar as permissões requeridas pela extensão, é necessário enviar um comando de delegação:
```json
{  
  "id": "5",
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
  "id": "5",
  "from": "postmaster@msging.net/#irismsging1",
  "to": "contact@msging.net/default",
  "method": "set",
  "status": "success"
}
```

#### Disponibilidade

O serviço de Broadcast está disponível nos seguintes domínios:

|Domínio    |Disponível |Observação                                             |
|---	    |---	    |---                                                    |
|Messenger  |x          |Necessário interação prévia do usuário com o serviço   |
|Omni       |x          |Não precisa de interação do usuário                    |
|Skype      |x          |Necessário interação prévia do usuário com o serviço   |
|SMS        |x          |Não precisa de interação do usuário                    |
|Telegram   |x          |Necessário interação prévia do usuário com o serviço   |
