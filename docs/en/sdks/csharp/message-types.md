### Message Types

**BLiP Messaging Hub** define message types (**cannonical types**) that are automatically parsed to the best available representation on each channel. For more details check the *Concepts > Messages* section of documentation.

For see how to use each **BLiP Messaging Hub** message type check the [Message Types](https://github.com/takenet/messaginghub-client-csharp/tree/master/src/Samples/MessageTypes) chatbot.

### Text Message (PlainText)

Simple text messages are supported for any channel. However, each channel can have restrictions as for sample the message length.

*Example:*

The sample follow show how to reply a received message with a simple text message.
```csharp
public async Task ReceiveAsync(Message message, CancellationToken cancellationToken)
{
    var document = new PlainText {Text = "... Inspiration, and a cup of coffe! It's enough!"};
    await _sender.SendMessageAsync(document, message.From, cancellationToken);
}
```
*Limitations:*

- Facebook Messenger: Max size of 320 characters. If your chatbot send messages with more than 320 characters, on this channel, your message will not be delivered.

### Links to media files and web pages (MediaLink e WebLink)

To send media links, the message sent must have a MediaLink document as follow:
```csharp
public async Task ReceiveAsync(Message message, CancellationToken cancellationToken)
{
    var imageUri = new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/4/45/A_small_cup_of_coffee.JPG/200px-A_small_cup_of_coffee.JPG", UriKind.Absolute);

    var document = new MediaLink
    {
        Text = "Coffe, what else ?",
        Size = 6679,
        Type = MediaType.Parse("image/jpeg"),
        PreviewUri = imageUri,
        Uri = imageUri
    };
    await _sender.SendMessageAsync(document, message.From, cancellationToken);
}
```
To send a web page link use the WebLink type:
```csharp
public async Task ReceiveAsync(Message message, CancellationToken cancellationToken)
{
    var url = new Uri("https://pt.wikipedia.org/wiki/Caf%C3%A9");
    var previewUri =
        new Uri(
            "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c5/Roasted_coffee_beans.jpg/200px-Roasted_coffee_beans.jpg");

    var document = new WebLink
    {
        Text = "Coffe, the god's drink!",
        PreviewUri = previewUri,
        Uri = url
    };

    await _sender.SendMessageAsync(document, message.From, cancellationToken);
}
```
### Sending an options list (Select)

Send an options list to give your client the choice between multiple answers using Select type:
```csharp
public async Task ReceiveAsync(Message message, CancellationToken cancellationToken)
{
    var document = new Select
    {
        Text = "Choice an option:",
        Options = new []
        {
            new SelectOption
            {
                Order = 1,
                Text = "An inspire text!",
                Value = new PlainText { Text = "1" }
            },
            new SelectOption
            {
                Order = 2,
                Text = "A motivational image!",
                Value = new PlainText { Text = "2" }
            },
            new SelectOption
            {
                Order = 3,
                Text = "An interesting link!",
                Value = new PlainText { Text = "3" }
            }
        }
    };

    await _sender.SendMessageAsync(document, message.From, cancellationToken);
}
```
**Note:**
- `Value` field is optional, if informed your value will be sent to the chatbot when the user choice the option.
- If `Value` field is not provided, will must provide one of the fields: `Order` or `Text`. The `Order` field will be used only if `Value` and `Text` is not provided.

**Limitations:**
- Facebook Messenger: Limite of 3 options, in other case your message will not be delivered. If is nedded to send more than 3 options is necessary send multiple messages.
- Tangram SMS: The `Value` field will be ignored. Only the `Order` field will be sent if the option be selected.

### Geolocation (Location)

A chatbot can send and receive a location entity. For this cases use Location type:
```csharp
public async Task ReceiveAsync(Message message, CancellationToken cancellationToken)
{
    var document = new Location
    {
        Latitude = -22.121944,
        Longitude = -45.128889,
        Altitude = 1143
    };

    await _sender.SendMessageAsync(document, message.From, cancellationToken);
}
```

### Processing Payments (Invoice, InvoiceStatus and PaymentReceipt)

In order to realize a payment on your chatbot is necessary use the payment channel. For now, only the PagSeguro channel is supported and to request a payment the chatbot must send a message of type Invoice to the payment channel informing the user address using the format bellow:
```csharp
var toPagseguro = $"{Uri.EscapeDataString(message.From.ToIdentity().ToString())}@pagseguro.gw.msging.net"; // Ex: 5531988887777%400mn.io@pagseguro.gw.msging.net
```
Check a complete example of payment request:
```csharp
public async Task ReceiveAsync(Message message, CancellationToken cancellationToken)
{
    var document = new Invoice
    {
        Currency = "BLR",
        DueTo = DateTime.Now.AddDays(1),
        Items =
            new[]
            {
                new InvoiceItem
                {
                    Currency = "BRL",
                    Unit = 1,
                    Description = "Some product",
                    Quantity = 1,
                    Total = 1
                }
            },
        Total = 1
    };

    var toPagseguro = $"{Uri.EscapeDataString(message.From.ToIdentity().ToString())}@pagseguro.gw.msging.net";

    await _sender.SendMessageAsync(document, toPagseguro, cancellationToken);
}
```
**Importante:**
- Para que esta solicitação de pagamento seja processada, o canal de pagamento PagSeguro deve ser habilitado para a seu Chat Bot no portal do Messaging Hub.

Ao receber esta mensagem, o PagSeguro enviará ao cliente um link para realização do pagamento. Uma vez realizado ou cancelado o pagamento, uma mensagem do tipo InvoiceStatus será recebida pelo seu Chat Bot. Para isso, um *Receiver* para o MediaType `application/vnd.lime.invoice-status+json` deve ser registrado no arquivo `application.json` da seguinte forma:

Ao receber esta mensagem, o PagSeguro enviará ao cliente um link para realização do pagamento. Uma vez realizado ou cancelado o pagamento, uma mensagem do tipo InvoiceStatus será recebida pelo seu Chat Bot. Para isso, um Receiver para o MediaType application/vnd.lime.invoice-status+json, o qual deve ser registrado no arquivo application.json da seguinte forma:
```js
"messageReceivers": [
{
    {
        "type": "InvoiceStatusReceiver",
        "mediaType": "application/vnd.lime.invoice-status\\+json"
    }
}
```
Tal receiver deve ser definido da seguinte forma:
```csharp
public class InvoiceStatusReceiver : IMessageReceiver
{
    private readonly IMessagingHubSender _sender;

    public InvoiceStatusReceiver(IMessagingHubSender sender)
    {
        _sender = sender;
    }

    public async Task ReceiveAsync(Message message, CancellationToken cancellationToken)
    {
        var invoiceStatus = message.Content as InvoiceStatus;
        switch (invoiceStatus?.Status)
        {
            case InvoiceStatusStatus.Cancelled:
                await _sender.SendMessageAsync("Tudo bem, não precisa pagar nada.", message.From, cancellationToken);
                break;
            case InvoiceStatusStatus.Completed:
                await _sender.SendMessageAsync("Obrigado pelo seu pagamento, mas como isso é apenas um teste, você pode pedir o ressarcimento do valor pago ao PagSeguro. Em todo caso, segue o seu recibo:", message.From, cancellationToken);
                var paymentReceipt = new PaymentReceipt
                {
                    Currency = "BLR",
                    Items =
                        new[]
                        {
                            new InvoiceItem
                            {
                                Currency = "BRL",
                                Unit = 1,
                                Description = "Serviços de Teste de Tipos Canônicos",
                                Quantity = 1,
                                Total = 1
                            }
                        },
                    Total = 1
                };
                await _sender.SendMessageAsync(paymentReceipt, message.From, cancellationToken);
                break;
            case InvoiceStatusStatus.Refunded:
                await _sender.SendMessageAsync("Pronto. O valor que você me pagou já foi ressarcido pelo PagSeguro!", message.From, cancellationToken);
                break;
        }
    }
}
```
Como pode ser visto no exemplo acima, seu Chat Bot deve estar preparado para reagir aos 3 statuses disponíveis como resposta ao seu pedido de pagamento, e deve enviar um recibo de pagamento (tipo PaymentReceipt) como resposta ao cliente.

### Mensagens Compostas (DocumentCollection e DocumentContainer)

Mensagens compostas podem ser enviadas utilizando os tipos DocumentCollection e DocumentContainer, conforme o exemplo a seguir:

```csharp
public async Task ReceiveAsync(Message message, CancellationToken cancellationToken)
{
    var imageUrl = new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/4/45/A_small_cup_of_coffee.JPG/200px-A_small_cup_of_coffee.JPG");
    var url = new Uri("https://pt.wikipedia.org/wiki/Caf%C3%A9");
    var previewUrl = new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/c/c5/Roasted_coffee_beans.jpg/200px-Roasted_coffee_beans.jpg");

    var document = new DocumentCollection
    {
        ItemType = DocumentContainer.MediaType,
        Items = new[]
        {
            new DocumentContainer
            {
                Value = new PlainText {Text = "... Inspiração, e um pouco de café! E isso me basta!"}
            },
            new DocumentContainer
            {
                Value = new MediaLink
                {
                    Text = "Café, o que mais seria?",
                    Size = 6679,
                    Type = MediaType.Parse("image/jpeg"),
                    PreviewUri = imageUrl,
                    Uri = imageUrl
                }
            },
            new DocumentContainer
            {
                Value = new WebLink
                {
                    Text = "Café, a bebida sagrada!",
                    PreviewUri = previewUrl,
                    Uri = url
                }
            }
        }
    };

    await _sender.SendMessageAsync(document, message.From, cancellationToken);
}
```
