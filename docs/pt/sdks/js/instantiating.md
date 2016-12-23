### Instanciando o cliente

Para instanciar o cliente, utilize a classe `ClientBuilder`, informando as opções para conexão, como `identificador` e `chave de acesso` obtidas no portal do BLiP.

```javascript

// Cria uma instância do cliente, informando o identifier e accessKey do seu chatbot 
var client = new ClientBuilder()
    .withIdentifier(identifier)
    .withAccessKey(accessKey)
    .build();

// Registra um receiver para mensagens do tipo 'text/plain'
client.addMessageReceiver('text/plain', function(message) {
  // TODO: Processe a mensagem recebida
});

// Registra um receiver para qualquer notificação
client.addNotificationReceiver(true, function(notification) {
  // TODO: Processe a notificação recebida
});

// Conecta com o servidor de forma assíncrona. 
// A conexão ocorre via websocket, na porta 8081.
client.connect() // O retorno deste método é uma 'promise'.
    .then(function(session) { 
        // Conexão bem sucedida. A partir deste momento, é possível enviar e receber envelopes do servidor. */ 
        })  
    .catch(function(err) { /* Falha de conexão. */ }); 

```

Cada instância de `client` representa uma conexão com o servidor, por isso deve ser reutilizada. Para fechar a conexão:

```javascript

client.close()
    .then(function() { /* Desconectado com sucesso */ })  
    .catch(function(err) { /* Falha ao fechar a conexão */ }); 

```
