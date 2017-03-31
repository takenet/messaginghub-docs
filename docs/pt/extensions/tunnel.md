### Túnel
| Endereço                     | URI base      | Permissões requeridas   | C#              |
|------------------------------|---------------|-------------------------|-----------------|
| postmaster@tunnel.msging.net | N/A | Nenhuma | [TunnelExtension](https://github.com/takenet/messaginghub-client-csharp/blob/master/src/Takenet.MessagingHub.Client/Extensions/Tunnel/TunnelExtension.cs) |

> Este documento é apenas uma proposta de implementação que não necessariamente está disponível na plataforma

A extensão **túnel** permite o encaminhamento e troca de mensagens e notificações entre diferentes *chatbots* da plataforma BLiP. Desta forma, um bot **emissor** consegue encaminhar mensagens recebidas para um bot **receptor** de maneira transparente, sendo que a mecânica de recebimento para este é exatamente a mesma das mensagens vindas dos canais externos (Messenger, Telegram, SMS, BLiP Chat, etc.). Portanto, o bot receptor **não precisa ser implementado de maneira específica** para receber mensagens encaminhadas, sendo que as notificações e mensagens de respostas geradas pelos receptores são encaminhadas automaticamente para o emissor.

Este recurso é útil para o **isolamento de diferentes partes da navegação em bots independentes** com apenas uma publicação no canal. Por exemplo, imagine que você queira ter, em uma mesma página do Facebook, um chatbot que tenha uma navegação parte automática (respostas estáticas), parte peguntas e respostas e parte atendendimento feito por um atendente. Você precisaria então de um bot **principal** (SDK/Webhook) que agirá como um *switcher* e três **sub-bots** - o primeiro com template do tipo SDK/Webhook, o segundo FAQ e o último Atendimento Manual. Estes três últimos **não seriam publicados diretamente nos canais**, mas apenas receberiam as mensagens do bot principal, este sim - publicado no Facebook e em outros canais. O bot principal seria o **emissor** e os demais os **receptores** do túnel.

Para criar um tunel entre dois *chatbots*, basta o **emissor** enviar uma mensagem para um endereço utilizando a seguinte regra:

```
[identifier-do-receptor]@tunnel.msging.net/[endereco-do-originador]
```
Onde:
- **identifier-do-receptor** - O identificador do bot de destino
- **endereco-do-originador** - Endereço original da mensagem externa utilizando codificação *URL encode* (ex: substituindo o '@' por '%40')


#### Exemplo

1 - Imagine um cenário onde existam dois bots: **flow** e **operator**, sendo o primeiro responsável por apresentar uma navegação automática e o segundo receber o transbordo de um eventual atendimento manual. Somente o bot **flow** está publicado no *Messenger* e este, em determinado ponto do seu fluxo, precisa encaminhar as mensagens ao bot **operator** que faz o controle do atendimento manual.

O caminho completo de uma mensagem deste o canal externo até o bot de atendimento é o seguinte:

a) O bot principal recebe uma mensagem de um usuário do Messenger.
```json
{
    "id": "1",
    "from": "1654804277843415@messenger.gw.msging.net",
    "to": "flow@msging.net/instance",
    "type": "text/plain",
    "content": "Hi"
}
```

b) De acordo com suas regras internas, o bot principal decide encaminhar esta mensagem ao bot de atendimento. Para isso, ele troca o destinatário da mensagem como abaixo:

```json
{
    "id": "1",
    "from": "flow@msging.net/instance",
    "to": "operator@tunnel.msging.net/1654804277843415%40messenger.gw.msging.net",
    "type": "text/plain",
    "content": "Hi"
}
```
