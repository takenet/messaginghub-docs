### Criando o cliente

Para instanciar o cliente, basta iniciar a classe `MessagingHubClient`, informando a `URI` do servidor e o *transporte* para conexão.

```javascript

// e.g.
var client = new MessagingHubClient('ws://msging.net:8081', new Lime.WebSocketTransport());
```

Para se conectar com uma chave de acesso, basta executar o método `connectWithKey` informando o `identifier` e `accessKey` gerados no portal. É importante frisar que o processo de conexão, envio e recebimento de mensagens e notificações ocorre e forma assíncrona e portanto, a maior parte dos métodos retornam uma `promise`, que permite que as continuações sejam encadeadas para execução após a completude da execução.

### Connect
```javascript
client.connectWithKey(identifier, key).then(/* handle connection */);
```
