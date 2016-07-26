### Telegram
| FQDN                     | Tipo de identificador                  | 
|--------------------------|----------------------------------------|
| @telegram.gw.msging.net  | Chat ID                                |


O canal **Tekegram** permite o envio de mensagens através do aplicativo [Telegram Messenger](https://telegram.org/) disponível para Android, iOS e Windows.


#### Tipos de mensagens suportados
| Nome               | MIME                                          | Suporte | Observação                          |
|--------------------|-----------------------------------------------|---------|-------------------------------------|
| Texto              | text/plain                                    | Sim     |                                     |
| MediaLink          | application/vnd.lime.media-link+json          | Sim     | Texto com link                      |
| WebLink            | application/vnd.lime.web-link+json            | Sim     | Texto com link                      |
| Select             | application/vnd.lime.select+json              | Sim     | Texto com opções                    |
| Location           | application/vnd.lime.location+json            | Não     |                                     |
| Invoice            | application/vnd.lime.invoice+json             | Não     |                                     |
| PaymentReceipt     | application/vnd.lime.payment-receipt+json     | Sim     | Texto com informações               |
| DocumentCollection | application/vnd.lime.document-collection+json | Não     |                                     |
| DocumentContainer  | application/vnd.lime.document-container+json  | Não     |                                     |


