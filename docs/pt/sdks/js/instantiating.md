### Instanciando o cliente

Para instanciar o cliente, basta iniciar a classe `MessagingHubClient`, informando a `URI` do servidor e o *transporte* para conexão.

```javascript

var client = new MessagingHubClient('ws://msging.net:8081', new Lime.WebSocketTransport());
```

Para se conectar com uma chave de acesso, basta executar o método `connectWithKey` informando o `identifier` e `accessKey` gerados no portal. 

O processo de conexão, envio e recebimento de mensagens e notificações pelo cliente ocorre de forma assíncrona e portanto, a maior parte dos métodos retornam uma `promise`, que permite que as continuações sejam encadeadas para execução após a completude da execução.

```javascript
client.connectWithKey(identifier, key).then(/* handle connection */);
```
