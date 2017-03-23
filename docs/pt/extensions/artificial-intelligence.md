### Inteligência artificial
| Endereço                        | URI base     | Permissões requeridas   | C#                     |
|---------------------------------|--------------|-------------------------|------------------------|
| postmaster@talkservice.msging.net | /analysis       | Análise de Sentença      | [TalkServiceExtension](https://github.com/takenet/messaginghub-client-csharp/blob/master/src/Takenet.MessagingHub.Client/Extensions/ArtificialIntelligence/TalkServiceExtension.cs) |

A extensão **TalkService** permite que você crie um chatbot que entenda a entrada em linguagem natural e use um modelo treinado para responder aos clientes de uma forma que simula uma conversa entre humanos, é necessario configurar previamente no portal do BLiP a API de interpretação de linguagem natural (ex.: Watson Conversation, Watson Natural language Classifier, Luis).

O TalkService abstrai a API de NLP permitindo que voce utilize a que melhor te atenda, os pedidos de análise de uma sentença retorna a intenção por trás do texto e retorna uma pontuação de confiança.

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