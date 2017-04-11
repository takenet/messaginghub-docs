### Configuring

The configuration of your chatbot is made on `application.json` file. Basically this file define all `receivers` and others control properties.

Check a example of how to set your `application.json` file:

```json
{
  "identifier": "xpto",
  "accessKey": "cXkzT1Rp",
  "messageReceivers": [
    {
      "type": "PlainTextMessageReceiver",
      "mediaType": "text/plain"
    }
  ]
}
```

For this case the client was configured to use a chatbot with `xpto` identifier with `cXkzT1Rp` accessKey. Besides that was registered a **MessageReceiver** with name `PlainTextMessageReceiver` and a filter for messages with `text/plain` **media type**.

Through of `application.json` file the developer can realize a tranparent run of the application. All the other tasks are managed by `mhh.exe` BLiP tool, installed with the template package.

All possible properties of the `application.json` file:

| Property | Description                                                                        | Example                 | Default Value |
|-------------|----------------------------------------------------------------------------------|-------------------------|--------------|
| identifier     | Chatbot identifier. Found this property on [BLiP Portal](http://portal.blip.ai). | myapplication           | null |
| domain      | The **lime** domain to connect. Now only `msging.net` is supported.| msging.net              | msging.net |
| hostName    | The host addres to connect with BLiP server.                                  | msging.net              | msging.net |
| accessKey   | The access key for authentication (using token mode), on **base64** format. Found this property on [BLiP Portal](http://portal.blip.ai).         | MTIzNDU2                 |null |
| password    | The password for authentication (using password mode), on **base64** format.                   | MTIzNDU2                 | null |
| sendTimeout | The timeout value to send messages (in milliseconds).                              | 30000                   | 20000 |
| sessionEncryption | Enchryptation mode.                              | None/TLS                   | TLS |
| sessionCompression | Session compression mode.                              | None                   | None |
| startupType | The name of .NET type that must be started on application load. This type must implements the `IStartable` interface. If the type is located on a different **assembly** of `application.json` file please provide a qualify name with **assembly**.    | Startup (or MyAssemblyName.Startup)     | null |
| serviceProviderType | A type to be used as a service provider for dependency injection. This type must implements the `IServiceProvider` interface. | ServiceProvider | null |
| settings    | General settings of application with key-value format. This value is injected on created types (like **receivers** or **startupType**). To receive the values the constructor of the types must have a instance of `IDictionary<string, object>` type. | { "myApiKey": "abcd1234" }   | null |
| settingsType | The name of .NET type that must be used to deserialize the settings. If the type is located on a different **assembly** of `application.json` file please provide a qualify name with **assembly**.    | ApplicationSettings (or MyAssemblyName.ApplicationSettings)    | null |
| messageReceivers | Array of **message receivers**, used to receive messages. | *See bellow* | null |
| notificationReceivers | Array of **notification receivers**, used to receive notifications. | *See bellow* | null |
| throughput | Envelopes processed limit by second. | 20 | 10 |
| maxConnectionRetries | Reconnection retry limit with server host (1-5). | 3 | 5 |
| routingRule | Routing rule of messages | Instance | Identity |
| disableNotify | Disable automatic notification for messages received and consumed by chatbot | false | false |
| channelCount | Conections count between chatbot and server | 1 | 5 | 
| receiptEvents | Define the events type that the server will foward to the chatbot | [ Accepted, Dispatched, Received, Consumed, Failed ] | [ Received ] |

Each **message receiver** can have the follow properties:

| Property | Description                                                                        | Example                 |
|-------------|----------------------------------------------------------------------------------|-------------------------|
| type        | Nome do tipo .NET para recebimento de mensagens. O mesmo deve implementar a interface `IMessageReceiver`. Pode ser o nome simples do tipo (se estiver na mesma **assembly** do arquivo `application.json`) ou o nome qualificado com **assembly**. | PlainTextMessageReceiver |
| mediaType   | Define um filtro de tipo de mensagens que o **receiver** pode processar. Apenas mensagens do tipo especificado serão entregues a instância criada. | text/plain |
| content     | Define uma expressão regular para filtrar os conteúdos de mensagens que o **receiver** pode processar. Apenas mensagens que satisfaçam a expressão serão entregues a instância criada. | Olá mundo |
| sender     | Define uma expressão regular para filtrar os originadores de mensagens que o **receiver** pode processar. Apenas mensagens que satisfaçam a expressão serão entregues a instância criada. | sender@domain.com |
| destination     | Define uma expressão regular para filtrar os destinatários de mensagens que o **receiver** pode processar. Apenas mensagens que satisfaçam a expressão serão entregues a instância criada. | destination@domain.com |
| settings    | Configurações gerais do receiver, no formato chave-valor. Este valor é injetado na instância criada. Para receber os valores, a implementação deve esperar uma instância do tipo `IDictionary<string, object>` no construtor. | { "mySetting": "xyzabcd" }   |
| settingsType | Nome do tipo .NET que será usado para deserializar as configurações. Pode ser o nome simples do tipo (se estiver na mesma **assembly** do arquivo `application.json`) ou o nome qualificado com **assembly**.    | PlainTextMessageReceiverSettings     |
| priority | Prioridade em relação aos outros receivers, valores menores tem mais prioridade. | 0 |
| state | Estado necessário do originador para o recebimento de mensagem.  | default |
| outState | Define um estado para o originador depois que a mensagem for processada | default |

Each **notification receiver** can have the follow properties:

| Property | Description                                                                        | Example                 |
|-------------|----------------------------------------------------------------------------------|-------------------------|
| type        | Nome do tipo .NET para recebimento de notificações. O mesmo deve implementar a interface `INotificationReceiver`. Pode ser o nome simples do tipo (se estiver na mesma **assembly** do arquivo `application.json`) ou o nome qualificado com **assembly**. | NotificationReceiver |
| settings    | Configurações gerais do receiver, no formato chave-valor. Este valor é  injetado na instância criada. Para receber os valores, a implementação deve esperar uma instância do tipo `IDictionary<string, object>` no construtor. | { "mySetting": "xyzabcd" }   |
| eventType   | Define um filtro de tipo de eventos que o **receiver** pode processar. Apenas notificações do evento especificado serão entregues a instância criada. | received |
| settingsType | Nome do tipo .NET que será usado para deserializar as configurações. Pode ser o nome simples do tipo (se estiver na mesma **assembly** do arquivo `application.json`) ou o nome qualificado com **assembly**.    | NotificationReceiverSettings     |
| sender     | Define uma expressão regular para filtrar os originadores da notificação que o **receiver** pode processar. Apenas notificações que satisfaçam a expressão serão entregues a instância criada. | sender@domain.com |
| destination     | Define uma expressão regular para filtrar os destinatários da notificação que o **receiver** pode processar. Apenas notificações que satisfaçam a expressão serão entregues a instância criada. | destination@domain.com |
| state | Estado necessário do originador para o recebimento de mensagem.  | default |
| outState | Define um estado para o originador depois que a mensagem for processada | default |
