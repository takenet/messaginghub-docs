# Notificações

Uma **notificação** provê informações de uma mensagem enviada. 

Cada notificação possui:
- **id**: Identificador da mensagem relacionada. 
- **from**: Endereço do originador da notificação. Uma notificação pode ser gerada pelo servidor (`postmaster@msging.net`) ou pelo cliente final, dependendo do **evento**.
- **to**: Endereço do destinatário da mensagem.
- **event**: Evento relacionado a mensagem. Alguns eventos dependem da capacidade do canal. Os valores válidos são:
  * Accepted: A mensagem foi aceita pelo servidor.
  * Dispatched: A mensagem saiu do servidor e foi despachada ao destinatário.
  * Received: O destinatário recebeu a mensagem.
  * Consumed: O destinatário consumiu (leu) a mensagem.
  * Failed: A mensagem falhou. Neste caso, a propriedade **reason** deve estar presente.
- **reason**: Motivo da falha da mensagem.

Abaixo a representação JSON de uma notificação de recebimento no destinatário:

```json

{
  "id": "65603604-fe19-479c-c885-3195b196fe8e",
  "from": "551199991111@0mn.io/182310923192",
  "to": "mycontact@msging.net",
  "event": "received"
}

```
E uma falha no servidor:

```json

{
  "id": "65603604-fe19-479c-c885-3195b196fe8e",
  "from": "postmaster@msging.net/server1",
  "to": "mycontact@msging.net",
  "event": "failed",
  "reason": {
    "code": 42,
    "description": "Destination not found"
  }
}

```
