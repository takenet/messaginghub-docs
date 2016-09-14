### Mensagens

Uma **mensagem** permite a troca de conteúdos entre clientes e contatos.

Cada mensagem possui:
- **id**: Identificador único da mensagem. O *id* é utilizado como referência para notificações, portanto **não reutilize o mesmo *id* da mensagem**. Este valor pode ser omitido caso o originador não tenha interesse em notificações, mesmo em caso de falhas.
- **from**: Endereço do originador da mensagem. Este valor pode ser omitido nas mensagens, sendo que por padrão é considerado o endereço do contato conectado.
- **to**: Endereço do destinatário da mensagem. Este valor deve estar presente.
- **type**: Declaração do tipo do conteúdo da mensagem, no formato MIME. O mesmo pode ser do tipo **plain** (por exemplo, `text/plain`) ou **JSON** (por exemplo, `application/vnd.lime.media-link+json`). Consulte a seção **Tipos de conteúdo** para maiores informações.
- **content**: Conteúdo da mensagem.

Abaixo temos a representação JSON de uma mensagem:

```json

{
  "id": "65603604-fe19-479c-c885-3195b196fe8e",
  "from": "551199991111@0mn.io/182310923192",
  "to": "mycontact@msging.net",
  "type": "text/plain",
  "content": "Olá mundo"
}

```
Para mais detalhes, consulte a especificação do [protocolo LIME](http://limeprotocol.org/index.html#message).
