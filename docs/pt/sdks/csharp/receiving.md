### Recebendo

O recebimento de mensagens e notificações é feito através das interfaces de `IMessageReceiver` e `INotificationReceiver` respectivamente.

Um `IMessageReceiver` pode ser definido da seguinte forma;

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

E um `INotificationReceiver` pode ser definido da seguinte forma:

```csharp
public class ConsumedNotificationReceiver : INotificationReceiver
{
    public async Task ReceiveAsync(Notification notification, CancellationToken cancellationToken)
    {
        // Write the received notification to the console
        Console.WriteLine(notification.ToString());
    }
}
```

O registro das implementações destas interfaces deve ser feito no arquivo `application.json` do projeto. Para maiores detalhes, consulte a seção **Instalação**.
