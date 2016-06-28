### Enviar

Para o envio de mensagens e notificações, deve-se utilizar uma instância de `IMessagingHubSender`, que é injetada automaticamente nos construtores dos `receivers` registrados no projeto, além da classe `Startup`.

Abaixo um exemplo de como responder a uma mensagem recebida:

```csharp
public class PlainTextMessageReceiver : IMessageReceiver
{
    private readonly IMessagingHubSender _sender;

    public PlainTextMessageReceiver(IMessagingHubSender sender)
    {
        _sender = sender;
    }

    public async Task ReceiveAsync(Message message, CancellationToken cancellationToken)
    {
        // Write the received message to the console
        Console.WriteLine(message.Content.ToString());
        // Responds to the received message
        _sender.SendMessageAsync("Hi. I just received your message!", message.From, cancellationToken);
    }
}
```
