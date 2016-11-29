### Encaminhamento

Em situações em que uma intervenção humana for necessária, como por exemplo em serviços de atendimento ao usuário, existe a possibilidade de utilizar
o applicativo [BLiP Mensagens](https://play.google.com/store/apps/details?id=net.take.omni) para receber e responder mensagens de usuários interagindo com a aplicação.
Todas as mensagens respondidas a partir do aplicativo serão entregues para os usuários como se tivessem sido geradas pelo seu contato, de forma transparente. 
Obviamente, é necessário que a pessoa que receberá e responderá as mensagens, que será chamada de atendente daqui em diante, instale o aplicativo e esteja online.

Para encaminhar uma mensagem recebida para o atendente, utilize o método de extensão `ForwardMessageAsync`, informando o número celular do atendente (configurado ao instalar o aplicativo Blip Mensagens).
Observe que o número deve ser informado com o código internacional (55) e DDD. Veja abaixo um exemplo de utilização:

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
        // (...)
        // Alguma lógica do fluxo da conversa, determinando que 
        // deve encaminhar a mensagem para o atendente
        await _sender.ForwardMessageAsync(message, "5511XXXXXXXXX", cancellationToken);
    }
}
```

As mensagens respondidas pelo atendente são entregues novamente para seu contato, que **DEVE** repassar para o usuário. Para tanto é necessário registrar um  
**MessageReceiver** com filtro para o *mediaType* `application/vnd.omni.attendance+json`. Veja abaixo um exemplo:

```json
{
  "messageReceivers": [
    {
      "type": "ForwardReplyMessageReceiver",
      "mediaType": "application/vnd.omni.attendance+json"
    },
    // Demais MessageReceivers
  ]
}
```

A classe utilizada no exemplo chama-se `ForwardReplyMessageReceiver`, e deve ser adicionada ao projeto. 

Para repassar a mensagem para o usuário, utilize o método de extensão `ForwardReplyAsync`. É interessante verificar também se a mensagem veio realmente do atendente, como medida de segurança, o que pode ser feito com o método
de extensão `FromForwarder`. Abaixo está um exemplo de todo o código necessário na implementação desta classe.

```csharp
public class ForwardReplyMessageReceiver : IMessageReceiver
{
    private readonly IMessagingHubSender _sender;

    public PlainTextMessageReceiver(IMessagingHubSender sender)
    {
        _sender = sender;
    }

    public async Task ReceiveAsync(Message message, CancellationToken cancellationToken)
    {
        if (message.FromForwarder(_operator))
        {
            await _sender.ForwardReplyAsync(message, cancellationToken);
        }
    }
}
```


