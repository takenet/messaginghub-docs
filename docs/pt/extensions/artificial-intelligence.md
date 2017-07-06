### Inteligência artificial
| Endereço                        | URIs base     | C#                     |
|---------------------------------|---------------|------------------------|
| postmaster@ai.msging.net        | `/intentions`, `/entities` e `/analysis`   | [ArtificialIntelligenceExtension](https://github.com/takenet/messaginghub-client-csharp/blob/master/src/Takenet.MessagingHub.Client/Extensions/ArtificialIntelligence/ArtificialIntelligenceExtension.cs) |

A extensão **Inteligência Artificial** permite a criação, treinamento e publicação de modelos de inteligência artificial nos provedores associados ao chatbot, além de realizar a análise de sentenças para identificação de intenções e entidades.

É possível incluir no modelo **documentos de resposta** que podem ser enviados pelo bot quando reconhecida uma intenção. Além disso, a extensão pode ser utilizada para aprimoramento do modelo através da associação de perguntas às intenções.

O treinamento do modelo é realizado simultâneamente em todos os provedores de AI associados ao chatbot. Neste momento, é armazenado um *snapshot* do mesmo que pode ser recuperado posteriormente para comparação da sua efetividade com outras versões. Para utilizar um modelo treinado, é necessária a publicação do mesmo.

#### Exemplos

1 - Criando uma intenção
```json
{  
  "id": "1",
  "to": "postmaster@ai.msging.net",
  "method": "set",
  "uri": "/intentions",
  "type": "application/vnd.iris.ai.intention+json",
  "resource": {
      "name": "Pedir pizza"
  }  
}
```
Resposta em caso de sucesso:
```json
{
  "id": "1",
  "from": "postmaster@ai.msging.net/#irismsging1",
  "to": "contact@msging.net/default",
  "method": "set",
  "status": "success",
  "type": "application/vnd.iris.ai.intention+json",
  "resource": {
      "id": "55c00a71-7005-448d-b5e4-62fbb4ebb763",
      "name": "Pedir pizza"
  }  
}
```

2 - Recuperando as primeiras 10 intenções
```json
{  
  "id": "2",
  "to": "postmaster@ai.msging.net",
  "method": "get",
  "uri": "/intentions?$skip=0&$take=10"
}
```
Resposta em caso de sucesso:
```json
{
  "id": "2",
  "from": "postmaster@ai.msging.net/#irismsging1",
  "to": "contact@msging.net/default",
  "method": "get",
  "status": "success",
  "type": "application/vnd.lime.collection+json",
  "resource": {
      "total": 2,
      "itemType": "application/vnd.iris.ai.intention+json",
      "items": [
        {
          "id": "55c00a71-7005-448d-b5e4-62fbb4ebb763",
          "name": "Pedir pizza"
        },
        {
          "id": "dca16c56-b74e-4aec-b153-f9efa2795319",
          "name": "Escolher sabor"
        }
      ]
  }
}
```