### Messages

One **message** allows the content exchange between customers and chatbots.

Each message has:

- **id**: Unique identifier. The *id* is used as reference for notifications, thus **avoid to reuse the same id**. One way to guarantee its uniqueness is using a new [UUID](https://en.wikipedia.org/wiki/Universally_unique_identifier) for each message.
- **from**: Originator’s address. This value may be omitted if the originator does not have interest on notifications, even in case of failures.
- **to**: Recipient’s address. This value must be present.
- **type**: Statement with content type, in MIME format. It can be of **plain** type (for example, `text/plain` ) or **JSON** (for example, `application/vnd.lime.media-link+json`). Check the **Content Types** section for more information.
- **content**: Message content.

See below the JSON representation of one message:

```json

{
  "id": "65603604-fe19-479c-c885-3195b196fe8e",
  "from": "551199991111@0mn.io/182310923192",
  "to": "mycontact@msging.net",
  "type": "text/plain",
  "content": "Hello World"
}

```

For more information, check the [LIME protocol](http://limeprotocol.org/index.html#message) specification.
