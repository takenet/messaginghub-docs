### Texto
| MIME type                | C#                                  |
|--------------------------|-------------------------------------|
| text/plain               | [Lime.Messaging.Contents.PlainText](https://github.com/takenet/lime-csharp/blob/master/src/Lime.Messaging/Contents/PlainText.cs) |

Permite o envio e recebimento de mensagens de texto simples.

#### Exemplo

Enviando uma mensagem para um destinatário do Messenger:

```json
{
    "id": "1",
    "to": "128271320123982@messenger.gw.msging.net",
    "type": "text/plain",
    "content": "Seja bem-vindo ao nosso serviço! Como podemos te ajudar?"
}
```
Em C# é possivel usar a classe ``PlainText`` ou enviar diretamente a string: 
```csharp
    var to = "128271320123982@messenger.gw.msging.net";
    var plaiText = new PlainText() { Text = "Seja bem-vindo ao nosso serviço! Como podemos te ajudar" };
    await _sender.SendMessageAsync(plaiText, to);
    // or 
    await _sender.SendMessageAsync("Seja bem-vindo ao nosso serviço! Como podemos te ajudar", to);
```

Para mais detalhes, consulte a especificação do [protocolo LIME](http://limeprotocol.org/content-types.html#text).

#### Suporte a spinning syntax

O BLiP suporta o envio de textos no formato `spinning syntax` (ou `spintax`), que permite variações do texto que é entregue ao destinatário de forma a tornar a conversa um pouco mais natural. Os valores alternativos são definidos no texto entre chaves (`{` e `}`) separados pelo caracter `|`. A cada entrega da mensagem, uma variação é escolhida de forma aleatória para a construção do texto final.

Por exemplo, o texto `{Oi|Ola}, seja bem-vindo! Como {posso|podemos} te ajudar?` poderá ser enviado ao cliente das seguintes formas:

- `Oi, seja bem-vindo! Como posso te ajudar?`
- `Olá, seja bem-vindo! Como posso te ajudar?`
- `Oi, seja bem-vindo! Como podemos te ajudar?`
- `Olá, seja bem-vindo! Como podemos te ajudar?`

Para utilizar esta sintaxe, basta incluir o valor `#message.spinText` com o valor `true` nos metadados da mensagem, como no exemplo abaixo:

```json
{
    "id": "1",
    "to": "128271320123982@messenger.gw.msging.net",
    "type": "text/plain",
    "content": "{Oi|Ola}, seja bem-vindo! Como {posso|podemos} te ajudar?",
    "metadata": {
        "#message.spinText": "true"
    }
}
```

#### Mapeamento nos canais

| Canal              | Tipo                    | 
|--------------------|-------------------------|
| BLiP Chat          | Texto                   |
| Messenger          | [Text message](https://developers.facebook.com/docs/messenger-platform/send-api-reference/text-message)|
| SMS                | Texto                   |
| Skype              | [Activity](https://docs.botframework.com/en-us/skype/chat/#sending-messages-1)|
| Telegram           | [Message](https://core.telegram.org/bots/api#message)|

