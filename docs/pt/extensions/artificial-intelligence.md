### Inteligência artificial
| Endereço                        | C#                                 |
|---------------------------------|------------------------------------|
| postmaster@ai.msging.net        | [ArtificialIntelligenceExtension](https://github.com/takenet/messaginghub-client-csharp/blob/master/src/Takenet.MessagingHub.Client/Extensions/ArtificialIntelligence/ArtificialIntelligenceExtension.cs) |

A extensão **Inteligência Artificial** permite a criação, treinamento e publicação de modelos de inteligência artificial nos provedores associados ao chatbot, além de realizar a análise de sentenças para identificação de intenções e entidades. A configuração dos provedores do chatbot é feita através do menu **Inteligência artificial** no [portal do BLiP](https://portal.blip.ai).

É possível associar **documentos de resposta** ao modelo que devem ser enviados quando reconhecida uma intenção. Além disso, a extensão pode ser utilizada para aprimoramento do modelo através da associação de perguntas às intenções.

O treinamento do modelo é realizado simultâneamente em todos os provedores de IA associados ao chatbot. Neste momento, é armazenado um *snapshot* do modelo que pode ser recuperado posteriormente para comparação da sua efetividade com outras versões. Para utilizar um modelo treinado, é necessária a publicação do mesmo.

Toda a manipulação do modelo pode ser feita através do portal do BLiP, podendo esta extensão ser utilizada apenas para realizar a **análise de sentenças** dos usuários do chabot. 

#### Recursos

| URI                               | Método   | Descrição                                  |
|-----------------------------------|----------|--------------------------------------------|
| `/intentions`                     | `set`    | Cria uma nova intenção. O `id` da intenção é retornado na resposta do comando. |
| `/intentions`                     | `get`    | Pesquisa em todas as intenções associadas ao chatbot. É possível paginar através dos parâmetros opcionais `$skip` e `$take`. |
| `/intentions/{id}`                | `get`    | Recupera uma intenção pelo `id`.           |
| `/entities`                       | `set`    | Cria uma nova entidade. O `id` da entidade é retornado na resposta do comando. |
| `/entities`                       | `get`    | Pesquisa em todas as entidades associadas ao chatbot. É possível paginar através dos parâmetros opcionais `$skip` e `$take`. |
| `/entities/{id}`                  | `get`    | Recupera uma entidade pelo `id`.           |
| `/intentions/{id}/questions`      | `set`    | Cria perguntas associadas à intenção `id`. |
| `/intentions/{id}/questions`      | `get`    | Pesquisa em todas as perguntas associadas à intenção `id`. É possível paginar através dos parâmetros opcionais `$skip` e `$take`. |
| `/intentions/{id}/questions/{qid}`| `delete` | Remove uma pergunta com id `qid`.          |
| `/intentions/{id}/answers`        | `set`    | Cria respostas associadas à intenção `id`. |
| `/intentions/{id}/answers`      | `get`      | Pesquisa em todas as respostas associadas à intenção `id`. É possível paginar através dos parâmetros opcionais `$skip` e `$take`. |
| `/intentions/{id}/answers/{aid}`  | `delete` | Remove uma resposta com id `aid`.          |
| `/models`                         | `set`    | Realiza o treinamento ou publicação de um modelo. A ação depende do tipo do recurso enviado (veja na tabela abaixo). |
| `/models`                         | `get`    | Pesquisa em todos os modelos treinados e/ou publicados. |
| `/analysis`                       | `set`    | Realiza a análise de uma sentença do usuário através de um modelo publicado. |

Os tipos dos recursos são:

| Nome           | MIME Type                                             | Descrição                                   |
|----------------|-------------------------------------------------------|---------------------------------------------|
| Intenção       | `application/vnd.iris.ai.intention+json`              | Intenção expressada através de uma sentença. |
| Entidade       | `application/vnd.iris.ai.entity+json`                 | Entidade identificada em uma intenção, com seus sinônimos. |
| Pergunta       | `application/vnd.iris.ai.question+json`               | Pergunta de um usuário associada a uma intenção para treinamento do modelo. |
| Resposta       | `application/vnd.iris.ai.answer+json`                 | Resposta que pode ser enviada no caso de identificada uma intenção. |
| Treinamento    | `application/vnd.iris.ai.model-training+json`         | Solicitação de treinamento de modelo. |
| Publicação     | `application/vnd.iris.ai.model-publishing+json`       | Solicitação de publicação de um modelo. |
| Pedido de análise | `application/vnd.iris.ai.analysis-request+json`    | Solicitação de análise de sentença. |
| Resposta de análise | `application/vnd.iris.ai.analysis-response+json` | Resultado de análise de uma sentença. |


#### Exemplos

1 - Criando uma entidade:
```json
{  
  "id":"1",
  "to":"postmaster@ai.msging.net",
  "method":"set",
  "uri":"/entities",
  "type":"application/vnd.iris.ai.entity+json",
  "resource":{  
    "name":"Sabor",
    "values":[  
      {  
        "name":"Marguerita",
        "synonymous":[  
          "Marguerita",
          "Margerita",
          "Margarita",
          "Margarida"
        ]
      },
      {  
        "name":"Pepperoni",
        "synonymous":[  
          "Pepperoni",
          "Peperoni",
          "Peperone"
        ]
      }
    ]
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
  "type": "application/vnd.iris.ai.entity+json",
  "resource": {
      "id": "838e14f5-0ca1-42a3-924e-962ff1b363e6"
  }
}
```

2 - Criando uma intenção:
```json
{  
  "id": "2",
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
  "id": "2",
  "from": "postmaster@ai.msging.net/#irismsging1",
  "to": "contact@msging.net/default",
  "method": "set",
  "status": "success",
  "type": "application/vnd.iris.ai.intention+json",
  "resource": {
      "id": "55c00a71-7005-448d-b5e4-62fbb4ebb763"
  }  
}
```

3 - Recuperando as primeiras 10 intenções:
```json
{  
  "id": "3",
  "to": "postmaster@ai.msging.net",
  "method": "get",
  "uri": "/intentions?$skip=0&$take=10"
}
```
Resposta em caso de sucesso:
```json
{
  "id": "3",
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

4 - Associando perguntas a uma intenção:
```json
{  
  "id": "4",
  "to": "postmaster@ai.msging.net",
  "method": "set",
  "uri": "/intentions/55c00a71-7005-448d-b5e4-62fbb4ebb763/questions",
  "type": "application/vnd.lime.collection+json",
  "resource": {
    "itemType": "application/vnd.iris.ai.question+json",
    "items":[
      {
        "text": "Quero uma pizza"
      },
      {
        "text": "Gostaria de pedir uma pizza"
      },
      {
        "text": "Me da uma pizza"
      }
    ]
  }  
}
```
Resposta em caso de sucesso:
```json
{
  "id": "4",
  "from": "postmaster@ai.msging.net/#irismsging1",
  "to": "contact@msging.net/default",
  "method": "set",
  "status": "success"
}
```

5 - Associando respostas a uma intenção:
```json
{  
  "id": "5",
  "to": "postmaster@ai.msging.net",
  "method": "set",
  "uri": "/intentions/55c00a71-7005-448d-b5e4-62fbb4ebb763/answers",
  "type": "application/vnd.lime.collection+json",
  "resource": {
    "itemType": "application/vnd.iris.ai.answer+json",
    "items":[
      {
        "type":"text/plain",
        "value":"Qual sabor você deseja?"
      }
    ]
  }  
}
```
Resposta em caso de sucesso:
```json
{
  "id": "5",
  "from": "postmaster@ai.msging.net/#irismsging1",
  "to": "contact@msging.net/default",
  "method": "set",
  "status": "success"
}
```

6 - Treinando o modelo em todos provedores cadastrados no portal:
```json
{  
  "id": "6",
  "to": "postmaster@ai.msging.net",
  "method": "set",
  "uri": "/models",
  "type": "application/vnd.iris.ai.model-training+json",
  "resource": {  
  }  
}
```
Resposta em caso de sucesso:
```json
{
  "id": "6",
  "from": "postmaster@ai.msging.net/#irismsging1",
  "to": "contact@msging.net/default",
  "method": "set",
  "status": "success"
}
```

7 - Recuperando os modelos treinados:
```json
{  
  "id": "7",
  "to": "postmaster@ai.msging.net",
  "method": "get",
  "uri": "/models"
}
```
Resposta em caso de sucesso:
```json
{
  "id": "7",
  "from": "postmaster@ai.msging.net/#irismsging1",
  "to": "contact@msging.net/default",
  "method": "set",
  "status": "success",
  "type": "application/vnd.lime.collection+json",
  "resource": {
      "total": 1,
      "itemType": "application/vnd.iris.ai.model+json",
      "items": [
        {
          "id":"d3190b46-c723-4831-b9e8-fe43c1816f80",
          "provider":"Watson",
          "externalId":"b518633d-26f6-454c-bd17-890b426f2d40",
          "storageDate":"2017-07-07T18:13:00.000Z",
          "trainingDate":"2017-07-07T18:13:00.000Z"
        },
        {
          "id":"fa0aa23b-5c62-4b90-9c13-986148c0d171",
          "provider":"Luis",
          "externalId":"713331f2-0375-462d-aa58-ff9b8c5075be",
          "storageDate":"2017-07-07T18:13:00.000Z",
          "trainingDate":"2017-07-07T18:13:00.000Z"
        }        
      ]
  }
}
```

8 - Analisando uma sentença no modelo padrão (definido no portal):
```json
{  
  "id": "8",
  "to": "postmaster@ai.msging.net",
  "method": "set",
  "uri": "/analysis",
  "type": "application/vnd.iris.ai.analysis-request+json",
  "uri": {
    "text":"Quero uma pizza marguerita"
  }
}
```
Resposta em caso de sucesso:
```json
{
  "id": "8",
  "from": "postmaster@ai.msging.net/#irismsging1",
  "to": "contact@msging.net/default",
  "method": "set",
  "status": "success",
  "type": "application/vnd.iris.ai.analysis-response+json",
  "resource": {
    "text":"Quero uma pizza marguerita",
    "intentions":[
      {
        "name":"Pedir pizza",
        "score": 0.95
      }
    ],
    "entities":[
      {
        "name":"Sabor",
        "value": "Marguerita"
      }
    ]
  }
}
```

9 - Analisando uma sentença em um modelo específico:
```json
{  
  "id": "9",
  "to": "postmaster@ai.msging.net",
  "method": "set",
  "uri": "/analysis",
  "type": "application/vnd.iris.ai.analysis-request+json",
  "uri": {
    "text":"Quero uma pizza marguerita",
    "modelId":"fa0aa23b-5c62-4b90-9c13-986148c0d171"
  }
}
```
Resposta em caso de sucesso:
```json
{
  "id": "9",
  "from": "postmaster@ai.msging.net/#irismsging1",
  "to": "contact@msging.net/default",
  "method": "set",
  "status": "success",
  "type": "application/vnd.iris.ai.analysis-response+json",
  "resource": {
    "text":"Quero uma pizza marguerita",
    "intentions":[
      {
        "name":"Pedir pizza",
        "score": 0.95
      }
    ],
    "entities":[
      {
        "name":"Sabor",
        "value": "Marguerita"
      }
    ]
  }
}
```