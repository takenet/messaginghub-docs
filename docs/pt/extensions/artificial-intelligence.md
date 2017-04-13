### Inteligência artificial
| Endereço                        | URI base     | Permissões requeridas   | C#                     |
|---------------------------------|--------------|-------------------------|------------------------|
| postmaster@talkservice.msging.net | /analysis       | Análise de Sentença      | [TalkServiceExtension](https://github.com/takenet/messaginghub-client-csharp/blob/master/src/Takenet.MessagingHub.Client/Extensions/ArtificialIntelligence/TalkServiceExtension.cs) |

A extensão **TalkService** permite que você crie um chatbot que entenda mensagens recebidas em linguagem natural, utilizando um modelo treinado para responder aos clientes a partir de uma base de conhecimento. Com isto, seu chatbot poderá simular uma conversa entre humanos. Antes de consultar esta API, é necessario configurar previamente no portal do BLiP o provedor da solução de interpretação de linguagem natural (NLP) que será utilizada pelo chatbot (ex.: Watson Conversation, Watson Natural language Classifier, Luis).

O TalkService permite desenvolver o chatbot abstraindo-se do provedor de NLP, permitindo que você utilize a solução que melhor  atenda. O pedido de análise de uma sentença retorna a intenção por trás do texto, com uma pontuação de confiança definida pelo provedor do NLP.

#### Exemplos

1 - Análise de uma sentença:
```json
{  
  "id": "1",
  "to": "postmaster@talkservice.msging.net",
  "method": "get",
  "uri": "/analysis?sentence=Ol%C3%A1%20chatbot%20inteligente",
}
```
Resposta em caso de sucesso:
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
        "answer": "Olá amigo, eu sou um chatbot inteligente que entende linguagem natural.",
        "guessname": [
            "ByeBye",
            "WhatsUrName"
        ],
        "guessconfidence": [
            "0,47",
            "0,40"
        ],
        "guessanswer": [
            "Foi um prazer conversar com vc, adeus!",
            "Meu nome é TalkService =)"
        ],
        "diagnostic": "",
        "status": "Succeeded"
    }
}
```
