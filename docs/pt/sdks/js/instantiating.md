### Criando o cliente

Para instanciar o cliente, basta iniciar a classe `MessagingHubClient`

```javascript
var client = new MessagingHubClient(uri, transport);

// e.g.
var client = new MessagingHubClient('ws://msging.net:8081', new Lime.WebSocketTransport());
```
