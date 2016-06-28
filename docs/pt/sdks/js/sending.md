### Enviar

O envio de mensagens e notificações só é possível após o estabelecimento da sessão.

Abaixo um exemplo da realização da conexão e posteriormente o envio de uma mensagem:

```javascript
client.connectWithKey(identifier, key)
    .then(function(session) {
      // O cliente está conectado, portanto é possível realizar envios a partir daqui
      var msg = { type: "application/json", content: "Hello, world", to: "my@friend.com" };
      client.sendMessage(msg);
    });
```

Neste exemplo, o cliente foi conectado com uma chave de acesso e após a realização da conexão, o foi realizado o envio de uma mensagem através do método `sendMessage`. Para enviar uma notificação, utilize o método `sendNotification`, como no exemplo abaixo:

```javascript
client.connectWithKey(identifier, key)
    .then(function(session) {
      // send a "received" notification to some user
      var notification = { id: "ef16284d-09b2-4d91-8220-74008f3a5788", to: "my@friend.com", event: Lime.NotificationEvent.RECEIVED };
      client.sendNotification(notification);
    });
```

Cada instância do cliente representa uma conexão independente com o servidor e por este motivo, as instâncias devem ser reutilizadas para envios posteriores.
