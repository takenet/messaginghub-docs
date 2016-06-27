# Mensagens

Uma **mensagem** permite a troca de conteúdo entre clientes e contatos.

Cada mensagem possui:
- **from**: Endereço do originador da mensagem.
- **to**: Endereço do destinatário da mensagem.
- **type**: Declaração do tipo do conteúdo da mensagem, no formato MIME. O mesmo pode ser do tipo **plain** (por exemplo, *text/plain*) ou JSON (por exemplo, *application/vnd.lime.media-link+json*). 
- **content**: Conteúdo da mensagem.

```json

{
  "from": "551199991111@0mn.io/182310923192",
  "to": "mycontact@msging.net",
  "type": "text/plain",
  "content": "Olá mundo"
}

```

