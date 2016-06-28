### Recebendo

O recebimento de mensagens e notificações é feito através das interfaces de `IMessageReceiver` e `INotificationReceiver` respectivamente.

Um `MessageReceiver` pode ser definido da seguinte forma;

```csharp
public class PlainTextMessageReceiver : IMessageReceiver
{
    public async Task ReceiveAsync(Message message, CancellationToken cancellationToken)
    {
        // Write the received message to the console
        Console.WriteLine(message.Content.ToString());
    }
}
```

O registro das implementações destas interfaces deve ser feito no arquivo `application.json` do projeto. Para maiores detalhes, consulte a seção **Instalação**.
