### Webhook

Um contato do tipo **Webhook** permite ao desenvolvedor realizar a integração através **endpoints HTTP** para troca de mensagens, notificações e comandos.

#### Envio de mensagens

Para enviar mensagens, a aplicação deverá fazer um `HTTP POST` na URL exibida nas configurações do contato. A requisição deve conter um cabeçalho de autorização (`Authorization`) com o tipo `Key`, conforme exibido nas configurações do contato.

Os dados da mensagem devem ser enviados no corpo da requisição. A mensagem deve ser um *JSON* no formato determinado pelo protocolo LIME. Para mais detalhes, consulte [a documentação do protocolo](http://limeprotocol.org/#message).

Suponha que exista um contato com o identificador **messaginghubapp**, veja como seria o envio completo, incluindo os cabeçalhos e a mensagem:
```
POST https://msging.net/messages HTTP/1.1
Content-Type: application/json
Authorization: Key bWVzc2FnaW5naHViQHRha2VuZXQuY29tLmJyOjEyMzQ=
Content-Length: 131

{
  "id": "7438EF90-2E9A-4B18-B84E-0C5C68536176",
  "to": "user@0mn.io",
  "type": "text/plain",
  "content": "Hello World!"
}
```
#### Recebimento de mensagens e notificações

A URL de mensagens configurada receberá um `HTTP POST` com a mensagem no formato JSON, também no formato definido pelo [protocolo LIME](http://limeprotocol.org/#message), conforme o exemplo abaixo:
```
{
  "id": "52198482-0FD5-4572-8E04-649691ACAA9C",
  "from": "user@0mn.io/4ac58r6e3",
  "to": "messaginghubapp@msging.net",
  "type": "text/plain",
  "content": "Hello World!"
}
```
Caso seja configurado a URL de notificações, será entregue nessa URL as notificações contendo os status das mensagens.

Nesse caso também será realizado um `HTTP POST` com a informação no formato JSON, conforme formato definido pelo [protocolo LIME](http://limeprotocol.org/#notification). Veja um exemplo:
```
{
  "id": "7438EF90-2E9A-4B18-B84E-0C5C68536176",
  "from": "user@0mn.io/4ac58r6e3",
  "to": "messaginghubapp@msging.net/7a8fr233x",
  "event": "received"
}
```

#### Envio de notificações

Para que a situação das mensagens no histórico seja feita adequadamente e o correto funcionamento dos canais seja garantido, após cada mensagem recebida deve ser enviada uma notificação. 

Se o bot processou corretamente a mensagem deve ser enviada notificação com evento `consumed`. Em caso de erros inesperados deve ser enviada notificação com evento `failed`. A requisição também deve conter um cabeçalho de autorização (`Authorization`) com o tipo `Key`, conforme exibido nas configurações do contato.

Suponha que exista um contato com o identificador **messaginghubapp**, veja como seria o envio completo, incluindo os cabeçalhos e o corpo da requisição, para uma mensagem com Id **7438EF90-2E9A-4B18-B84E-0C5C68536176** processada corretamente:
```
POST https://msging.net/notifications HTTP/1.1
Content-Type: application/json
Authorization: Key bWVzc2FnaW5naHViQHRha2VuZXQuY29tLmJyOjEyMzQ=
Content-Length: 131

{
  "id": "7438EF90-2E9A-4B18-B84E-0C5C68536176",
  "from": "messaginghubapp@msging.net/7a8fr233x",
  "to": "user@0mn.io/4ac58r6e3",
  "event": "consumed"
}
```

#### Configuração

| Nome                | Descrição                                                                               |
|---------------------|-----------------------------------------------------------------------------------------|
| Url de envio de mensagem                | Endereço onde o MessagingHub irá postar as mensagens                 |
| Url de envio de notificação     | Endereço onde o MessagingHub irá postar as notificações                       |
