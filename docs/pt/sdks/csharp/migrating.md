### Migrando do antigo SDK

O novo SDK C# do BLiP permite a criação de chatbots multiplataforma (Windows, Linux e Mac) que podem ser facilmente hospedados na nuvem, inclusive em [containers Docker](https://www.docker.com/), graças a portabilidade do [.NET Core](https://dot.net/core) no qual o mesmo é baseado.

Para realizar a migração de um chatbot que utiliza a versão antiga do SDK (baseada no pacote `Takenet.MessagingHub.Client`) é necessário realizar os seguintes passos:

- Criar um novo projeto utilizando o template do BLiP, utilizando o comando `dotnet new blip-console` (como descrito no tópico **Instalação** desta documentação)
- Copiar as classes e o arquivo `application.json` para o novo projeto e instalar as demais dependências (exceto do SDK do BLiP, que já está instalada no template)
- Substituir o nome das interfaces e classes antigas para o SDK novo (mapeado abaixo)
- Ajustar as chamadas dos métodos com assinaturas alteradas (mapeado abaixo)

Não é possível reutilizar os projetos antigos pois os mesmos se baseiam na versão antiga do `.csproj` do .NET, que é incompatível com projetos .NET Standard / .NET Core utilizados no novo SDK do BLiP.

Abaixo estão mapeados alguns componentes do SDK antigo com os respectivos no novo SDK:

**Interfaces**:

| Antigo                                                      | Novo                                                |
|-------------------------------------------------------------|-----------------------------------------------------|
| `Takenet.MessagingHub.Client.Sender.IMessagingHubSender`    | `Take.Blip.Client.ISender`                          |
| `Takenet.MessagingHub.Client.Listener.IMessageReceiver`     | `Take.Blip.Client.IMessageReceiver`                 |

> Nota: Na maior parte dos métodos da nova versão, é obrigatório informar um `cancellationToken` para garantir o cancelamento correto das operações assíncronas e evitar o congelamento do processo.
