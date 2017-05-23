### Redirecionamento
| MIME type                          | 
|------------------------------------|
| application/vnd.lime.redirect+json |

Realiza o redirecionamento de uma conversa em particular do seu chatbot para um novo endereço. Na prática, torna possível o **transbordo** de uma conversa entre chatbots diferentes, que pode ser de qualquer modelo (FAQ, Atendimento Manual) ou SDKs / Webhook.

No momento, o redirecionamento é suportado apenas em chatbots configurados como serviços no [**modelo master**](https://portal.blip.ai/#/docs/templates/master). Este pode ser feito utilizando o endereço do chatbot (identificador) ou o nome do serviço definido nas configurações do modelo master no portal.

É possível informar um documento que representa o **contexto** da conversa e que será recebido pelo chatbot para qual a conversa foi direcionada. O contexto é útil para definição de um fluxo específico no chatbot de destino, por exemplo.

#### Exemplos
1 - Redirecionando para o serviço *atendimento*
```json
{
    "id": "1",
    "to": "54f1dd2e-42d2-43f2-9100-68fbbabb9c83@tunnel.msging.net",
    "type": "application/vnd.iris.redirect+json",
    "content": {
        "address": "atendimento"
    }
}
```
A partir deste momento, as mensagens enviadas pelo cliente `54f1dd2e-42d2-43f2-9100-68fbbabb9c83@tunnel.msging.net` serão encaminhadas para o chatbot configurado como serviço *atendimento* na aba configurações do modelo master.

2 - Redirecionando para o chatbot com identificador *mysdkbot*, passando um documento como contexto da conversa.
```json
{
    "id": "2",
    "to": "54f1dd2e-42d2-43f2-9100-68fbbabb9c83@tunnel.msging.net",
    "type": "application/vnd.iris.redirect+json",
    "content": {
        "address": "mysdkbot@msging.net",
        "context": {
            "type": "text/plain",
            "value": "Iniciar"
        }
    }
}
```
Neste exemplo, o chatbot com identificador `mysdkbot` passará a receber as mensagens enviadas pelo cliente, além de receber uma mensagem com o conteúdo definido no contexto, como se tivesse sido enviada pelo cliente:

```json
{
    "id": "3",
    "from": "54f1dd2e-42d2-43f2-9100-68fbbabb9c83@tunnel.msging.net",
    "to": "mysdkbot@msging.net",
    "type": "text/plain",
    "content": "Iniciar"
}
```

### Mapeamento nos canais

O redirecionamento no momento é suportado somente por chatbots configurados como serviços do modelo master. Neste caso, todas as mensagens terão o domínio @tunnel.msging.net, já que o modelo master utiliza a [extensão túnel](https://portal.blip.ai/#/docs/tunnel) para comunicação com os serviços (sub-bots).

