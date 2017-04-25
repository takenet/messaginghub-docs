### Recurso
| MIME type                            | 
|--------------------------------------|
| application/vnd.iris.resource+json   |

Permite o envio de mensagens onde o conteúdo é um **recurso** armazenado no servidor. O recurso deve ser armazenado através da [extensão **recursos**](https://portal.blip.ai/#/docs/extensions/resource). O servidor realiza automaticamente a substituição do conteúdo, caso o **identificador** fornecido seja válido para o chatbot que originou a mensagem.

#### Exemplos
Enviando uma mensagem do recurso com identificador **welcome-message**.
```json
{
    "id": "1",
    "to": "1042221589186385@messenger.gw.msging.net",
    "type": "application/vnd.iris.resource+json",
    "content": {
        "id": "welcome-message"
    }
}
```
Caso exista um recurso com este identificador, o servidor realiza a substituição do conteúdo da mensagem e encaminha para o desntinatário. Suponhando que o recurso com o identificador **welcome-message** seja do tipo `text/plain` com valor `Seja bem vindo a nosso serviço`, a mensagem final ficaria da seguinte forma:

```json
{
    "id": "1",
    "to": "1042221589186385@messenger.gw.msging.net",
    "type": "text/plain",
    "content": "Seja bem vindo a nosso serviço"
}
```

### Mapeamento nos canais

O tipo de conteúdo é suportado em todos os canais.

