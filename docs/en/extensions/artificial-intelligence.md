### Artificial Intelligence
| Endereço                          | URI base    | C#                     |
|-----------------------------------|-------------|------------------------|
| postmaster@talkservice.msging.net | /analysis   | [TalkServiceExtension](https://github.com/takenet/messaginghub-client-csharp/blob/master/src/Takenet.MessagingHub.Client/Extensions/ArtificialIntelligence/TalkServiceExtension.cs) |

The **Artificial Intelligence** extension (also known as **TalkService**) enables the implementation of chatbots with the capability of processing natural language messages using an IA model. The extension processes the input and returns the **intention** behind the text, with a confidence score, defined by the IA Provider. The input must be provided encoded in the request command URI.

This extension abstracts the IA provider, allowing the selection of the most appropriate solution for each case. Before using the extension, the IA provider (Watson Conversation, Watson Natural language Classifier, etc.) should be configured in the portal for the chatbot. 


#### Examples

1 - Sentence analysis:
```json
{  
  "id": "1",
  "to": "postmaster@talkservice.msging.net",
  "method": "get",
  "uri": "/analysis?sentence=Ol%C3%A1%20chatbot%20inteligente",
}
```
Response on success:
```json
{
  "id": "1",
  "from": "postmaster@talkservice.msging.net/#irismsging1",
  "to": "contact@msging.net/default",
  "method": "get",
  "status": "success",
  "type" : "application/vnd.talkservice.analysis+json",
  "resource": {
        "identifier": "fc092222-46d3-492a-84f7-bda27b949fea",
        "sentence": "Olá chatbot inteligente",
        "classifier": "Greeting",
        "confidence": 0.81459628343582153,
        "uncertain": false,
        "answer": "Hello my friend, I'm a a smart chatbot that understands natural language.",
        "guessname": [
            "ByeBye",
            "WhatsUrName"
        ],
        "guessconfidence": [
            "0,47",
            "0,40"
        ],
        "guessanswer": [
            "It was nice talk to you, goodbye!",
            "My name is TalkService =)"
        ],
        "diagnostic": "",
        "status": "Succeeded"
    }
}
```
