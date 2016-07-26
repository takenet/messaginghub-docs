### Messenger
| FQDN                     | Tipo de identificador                                         |
|--------------------------|---------------------------------------------------------------|
| @messenger.gw.msging.net | Interno (cliente por página) / MSISDN (via customer matching) |

O canal **Messenger** é o canal da plataforma de mensagens do [Facebook](https://www.messenger.com/) e que é acessível através da web e dos aplicativos móveis para Android, iOS e Windows.

#### Tipos de mensagens suportados

| Nome            | MIME                                  | Suporte   | Observação                                                   |
|-----------------|---------------------------------------|-----------|--------------------------------------------------------------|
| Texto           | text/plain                            | Sim       |                                                              |
| MediaLink       | application/vnd.lime.media-link+json  | Sim       |                                                              |
| WebLink         | application/vnd.lime.web-link+json    | Sim       |                                                              |
| Select          | application/vnd.lime.select+json      | Sim       | Com botões ou quick reply, dependendo do valor de `scope`    |
