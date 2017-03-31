### Túnel
| Endereço                     | URI base      | Permissões requeridas   | C#              |
|------------------------------|---------------|-------------------------|-----------------|
| postmaster@tunnel.msging.net | N/A | Nenhuma | [TunnelExtension](https://github.com/takenet/messaginghub-client-csharp/blob/master/src/Takenet.MessagingHub.Client/Extensions/Tunnel/TunnelExtension.cs) |

> Este documento é apenas uma proposta de implementação que não necessariamente está disponível

A extensão **túnel** permite o encaminhamento e troca de mensagens e notificações entre diferentes *chatbots* da plataforma BLiP. Desta forma, um bot **emissor** consegue encaminhar mensagens recebidas para um bot **receptor** de maneira transparente, sendo que a mecânica de recebimento para este é exatamente a mesma das mensagens vindas dos canais externos (Messenger, Telegram, SMS, BLiP Chat, etc.). Portanto, o bot receptor **não precisa ser implementado de maneira específica** para receber mensagens encaminhadas, sendo que as notificações e mensagens de respostas geradas pelos receptores são encaminhadas automaticamente para o emissor.

Este recurso é útil para o **isolamento de diferentes partes da navegação em bots independentes** com apenas uma publicação no canal. Por exemplo, imagine que você queira ter, em uma mesma página do Facebook, um chatbot que tenha uma navegação parte automática (respostas estáticas), parte peguntas e respostas e parte atendendimento feito por um atendente. Você precisaria então de um bot **principal** (SDK/Webhook) que agirá como um *switcher* e três **sub-bots** - o primeiro com template do tipo SDK/Webhook, o segundo FAQ e o último Atendimento Manual. Estes três últimos **não seriam publicados diretamente nos canais**, mas apenas receberiam as mensagens do bot principal, este sim - publicado no Facebook e em outros canais.

