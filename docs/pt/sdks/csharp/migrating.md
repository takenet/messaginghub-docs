### Migrando do antigo SDK

A migração de um chatbot que utiliza a versão anterior do SDK (baseada no pacote `Takenet.MessagingHub.Client`) é simples, bastando a alteração de alguns nomes de interfaces e classes, além de substituir alguns métodos específicos. 

Abaixo estão mapeados alguns componentes do SDK antigo com os respectivos no novo SDK:

**Interfaces**:

| Antigo                                                      | Novo                                                |
|-------------------------------------------------------------|-----------------------------------------------------|
| `Takenet.MessagingHub.Client.Sender.IMessagingHubSender`    | `Take.Blip.Client.ISender`                          |
| `Takenet.MessagingHub.Client.Listener.IMessageReceiver`     | `Take.Blip.Client.IMessageReceiver`                 |

> Nota: Na maior parte dos métodos da nova versão, é obrigatório informar um `cancellationToken` para garantir o cancelamento correto das operações assíncronas e evitar o congelamento do processo.
