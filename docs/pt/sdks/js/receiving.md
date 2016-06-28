### Receber

O recebimento pelo cliente se dá através do registro de `receivers` para mensagens e notificações. É possível definir filtros para cada `receiver` no momento do registro.

Adicionando um receiver de mensagem para o tipo `text/plain`:

```javascript
client.addMessageReceiver("text/plain", function(message) {
  // Processe a mensagem recebida
});

```
Adicionando um receiver de notificação para o evento `received`:

```javascript
client.addNotificationReceiver("received", function(notification) {
  // Processe a notificação recebida
});

```

É possível ainda informar uma função para o filtro das mensagens e notificações:

Adicionando um receiver de mensagem com um filtro de originador:

```javascript
client.addMessageReceiver(function(message) { message.from === "553199990000@0mn.io" }, function(message) {
  // Processe a mensagem recebida
});

// Utilizando uma expressão lambda
client.addNotificationReceiver(() => true, function(message) {
  // Processe a notificação recebida
});

```
