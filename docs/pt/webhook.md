### Webhook

O contato do tipo **Webhook** consiste em um serviço que será customizado pelo usuário através de uma integração por **endpoints HTTP** para troca de mensagens e notificações.

### Envio de mensagens

Para enviar mensagens, a aplicação deverá fazer um POST HTTP na url exibida nas configurações do contato. A requisição deve conter um cabeçalho de autorização(*Authorization*) com o tipo *Basic* utilizando os dados de acesso do usuário ao portal.

Abaixo um exemplo de montagem do cabeçalho:

Suponha que meu login de acesso ao portal seja **messaginghub@takenet.com.br** e minha senha seja **1234**

O primeiro passo é juntar os 2 valores separados por :
```
messaginghub@takenet.com.br:1234
```
Aplicar codificação base64:
```
bWVzc2FnaW5naHViQHRha2VuZXQuY29tLmJyOjEyMzQ=
```
O cabeçalho fica, então:
```
Authorization: Basic bWVzc2FnaW5naHViQHRha2VuZXQuY29tLmJyOjEyMzQ=
```
Além do cabeçalho, os dados da mensagem devem ser enviados no corpo da requisição. A mensagem deve ser um *JSON* no formato determinado pelo protocolo LIME. Para mais detalhes, veja [a documentação do protocolo](http://limeprotocol.org/#message).

Suponha que exista um contato com o identificador **messaginghubapp**
Veja como seria o envio completo, incluindo os cabeçalhos e a mensagem:
```
POST https://api.messaginghub.io/applications/messaginghubapp/messages HTTP/1.1
Content-Type: application/json
Authorization: Basic bWVzc2FnaW5naHViQHRha2VuZXQuY29tLmJyOjEyMzQ=
Content-Length: 131

{
  "id": "7438EF90-2E9A-4B18-B84E-0C5C68536176",
  "to": "user@0mn.io",
  "type": "text/plain",
  "content": "Hello World!"
}
```
### Recebimento de mensagens e notificações

Para receber as mensagens, a url deve ser configurada, que é o endereço onde o MessagingHub irá postar as mensagens para o contato customizado.

O MessagingHub fará um POST Http com a mensagem no formato JSON, também no formato definido pelo [protocolo LIME](http://limeprotocol.org/#notification), conforme o exemplo abaixo:
```
{
  "id": "52198482-0FD5-4572-8E04-649691ACAA9C",
  "from": "user@0mn.io/4ac58r6e3"
  "to": "messaginghubapp@msging.net",
  "type": "text/plain",
  "content": "Hello World!"
}
```
Opcionalmente, uma url de notificações pode ser configurada, que será onde o MessagingHub entregará o status das mensagens enviadas.

Nesse caso também será realizado um POST HTTP com a informação no formato Json. Veja um exemplo:
```
{
  "id": "7438EF90-2E9A-4B18-B84E-0C5C68536176",
  "from": "user@0mn.io/4ac58r6e3",
  "to": "messaginghubapp@msging.net/7a8fr233x",
  "event": "received"
}
```
### Configuração

| Nome                | Descrição                                                                               |
|---------------------|-----------------------------------------------------------------------------------------|
| Url de envio de mensagem                | Endereço onde o MessagingHub irá postar as mensagens                                                      |
| Url de envio de notificação     | Endereço onde o MessagingHub irá postar as notificações                               |
