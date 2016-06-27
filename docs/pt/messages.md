# Mensagens

Uma **mensagem** permite a troca de conteúdos entre clientes e contatos.

Cada mensagem possui:
- **id**: Identificador único da mensagem. O *id* é utilizado como referência para notificações. Este valor pode ser omitido, caso o originador não tenha interesse em notificações, mesmo em caso de falhas.
- **from**: Endereço do originador da mensagem.
- **to**: Endereço do destinatário da mensagem.
- **type**: Declaração do tipo do conteúdo da mensagem, no formato MIME. O mesmo pode ser do tipo **plain** (por exemplo, *text/plain*) ou **JSON** (por exemplo, *application/vnd.lime.media-link+json*). 
- **content**: Conteúdo da mensagem.

Abaixo a representação JSON de uma mensagem:

```json

{
  "id": "65603604-fe19-479c-c885-3195b196fe8e",
  "from": "551199991111@0mn.io/182310923192",
  "to": "mycontact@msging.net",
  "type": "text/plain",
  "content": "Olá mundo"
}

```

## Tipos de mensagem

O Messaging Hub possui uma infraestrutura que permite que os Chat Bots sejam construídos usando uma linguagem canônica, que é devidamente traduzida para as mensagens específicas de cada um dos canais disponíveis, como Facebook Messenger, Skype, SMS.

Os tipos canônicos disponíveis são:

- **PlainText:** - MIME: `text/plain` - Este é o tipo de mensagem padrão e é utilizado para o envio de mensagens de texto simples.
- **MediaLink:** - MIME: `application/vnd.lime.media-link+json` - O tipo MediaLink é usado para enviar imagens, sons, vídeos e outros arquivos de mídia. Em canais que não suportam essas mídias, um link para um endereço web contendo o arquivo será enviado.
- **WebLink:** - MIME: `application/vnd.lime.web-link+json` - Um WebLink pode ser usado para enviar links para paginas web. Alguns canais, como o OMNI e o Facebook, fazem um excelente tratamento desse tipo, exibindo uma miniatura da página dentro da própria thread de mensagens.
- **Select:** - MIME: `application/vnd.lime.select+json` -Um Select permite o envio ao cliente do Chat Bot de uma lista de opções, da qual ele pode selecionar uma delas como resposta.
- **Location:** - MIME: `application/vnd.lime.location+json` - O tipo Location pode ser usado pelo canal para enviar ao Chat Bot a localização geográfica do cliente, ou para que o Chat Bot envie ao cliente uma determinada localização.
- **Invoice:** - MIME: `application/vnd.lime.invoice+json` - O tipo Invoice pode ser usado pelo Chat Bot para solicitar um pagamento a um canal de pagamento, como por exemplo o PagSeguro.
- **InvoiceStatus:** - MIME: `application/vnd.lime.invoice-status+json` - InvoiceStatus são mensagens recebidas pelo Chat Bot, a partir do canal de pagamento, comunicando o status do pagamento solicitado.
- **PaymentReceipt:** - MIME: `application/vnd.lime.payment-receipt+json` - Um PaymentReceipt é o tipo de mensagem que deve ser enviado ao cliente que realizou um pagamento.
- **DocumentCollection:** - MIME: `application/vnd.lime.documentcollection+json` - DocumentCollections permitem que múltiplas mensagens sejam enviadas dentro de uma única mensagem.
- **DocumentContainer:** - MIME: `application/vnd.lime.documentcontainer+json` - Encapsula um conteúdo de forma a ser utilizado junto ao DocumentCollection para envio de multiplos conteúdos diferentes. Util para mandar conteúdos compostos (texto + imagem).


