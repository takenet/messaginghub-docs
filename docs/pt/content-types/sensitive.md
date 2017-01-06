### Informação sensível

| MIME type                            | C#                                 |
|--------------------------------------|------------------------------------|
| application/vnd.lime.sensitive+json  | [Lime.Messaging.Contents.SensitiveContainer](https://github.com/takenet/lime-csharp/blob/master/src/Lime.Messaging/Contents/SensitiveContainer.cs) |

Encapsula um conteúdo com sua declaração de tipo MIME, de forma a sinalizar a informação como *sensível* ou *confidencial*. Desta forma, o servidor trata a mesma de maneira diferente, não armazenando-a em nenhum momento.

Importante: O não armazenamento é **restrito ao servidores do BLiP**, podendo um canal externo (*Messenger*, *Telegram*, etc.) armazenar a mesma de alguma maneira.

#### Exemplo
Enviando uma senha no formato texto a um usuário do Messenger:
```json
{
  "to": "1334448251684655@messenger.gw.msging.net",
  "type": "application/vnd.lime.sensitive+json",
  "content": {
    "type": "text/plain",
    "value": "A sua senha é 123456"
  }
}

```
