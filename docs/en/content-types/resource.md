### Resource
| MIME type                            | 
|--------------------------------------|
| application/vnd.iris.resource+json   |

Allows sending a message where the content is a **resource** stored in the server. The resource should be stored thought the [**resources** extension](https://portal.blip.ai/#/docs/extensions/resource). The server automatically replaces the content with the stored resource, in the case the resource **key** exists for the caller chatbot.

#### Examples
Sending a resource message with the **welcome-message** identifier:
```json
{
    "id": "1",
    "to": "1042221589186385@messenger.gw.msging.net",
    "type": "application/vnd.iris.resource+json",
    "content": {
        "key": "welcome-message"
    }
}
```
In case there is a resource with this key, the server replaces the content and forward to the destination. Imagining that the resource with **welcome-message** key is a `text/plain` document with value `Welcome to our service`, the final message would be like this:

```json
{
    "id": "1",
    "to": "1042221589186385@messenger.gw.msging.net",
    "type": "text/plain",
    "content": "Welcome to our service"
}
```

### Channel mapping

This content type is supported on all channels.

