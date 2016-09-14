### Estado da conversa
| MIME type                                 | C#                                        |
|-------------------------------------------|-------------------------------------------|
| application/vnd.lime.chatstate+json | [Lime.Messaging.Contents.ChatState](https://github.com/takenet/lime-csharp/blob/master/src/Lime.Messaging/Contents/ChatState.cs) |

Permite o envio e recebimento de informação sobre o estado atual da conversa. Os estados possíveis são:

| Estado        | Descrição                          |
|---------------|------------------------------------|
| *starting*    | Iniciando nova conversa |
| *composing*   | Digitando/preparando uma mensagem  |
| *paused*      | Digitação de nova mensagem foi interrompida (e não enviada)  |
| *deleting*    | Apagando mensagem (que estava sendo preparada) |
| *gone*        | Saiu/terminou a conversa  |

Para mais detalhes, consulte a especificação do [protocolo LIME](http://limeprotocol.org/content-types.html#chatstate).

####Exemplo
Enviando estado *digitando* para usuário do Telegram:
```json
{
    "id":"311F87C0-F938-4FF3-991A-7C5AEF7771A5",
    "to":"104222@telegram.gw.msging.net",
    "type":"application/vnd.lime.chatstate+json",
    "content": {
        "state": "composing"
    }
}
```

### Mapeamento nos canais

| Canal              | Tipo      | Estados suportados      | 
|--------------------|-----------|-------------------------|
| Omni               | Estado da Conversa | Todos |
| Messenger          | [Sender Actions](https://developers.facebook.com/docs/messenger-platform/send-api-reference/sender-actions) | *composing* e *paused* (somente envio) |
| SMS                | - | Nenhum |
| Skype              | - | Nenhum |
| Telegram           | [SendChatAction](https://core.telegram.org/bots/api#sendchataction) | *composing* (somente envio) |
