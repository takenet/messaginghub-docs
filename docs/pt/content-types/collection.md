### Coleção
| MIME type                            | 
|--------------------------------------|
| application/vnd.lime.collection+json |

Permite o envio de **múltiplos conteúdos* em uma única mensagem. Alguns canais suportam este tipo de agregação com layouts especiais (por exemplo, no Facebook Messenger uma coleção de **menu multimídia** é exibido como um *carousel*). Nos demais canais, são enviadas múltiplas mensagens.

#### Exemplos
Uma coleção de **menu multimídia**

```json
{
    "id": "message-id",
    "to": "%messengerIdentity",
    "type": "application/vnd.lime.collection+json",
    "content": {
        "itemType": "application/vnd.lime.document-select+json",
        "items": [
            {
                "header": {
                    "type": "application/vnd.lime.media-link+json",
                    "value": {
                        "title": "First element",
                        "text": "First element text",
                        "type": "image/jpeg",
                        "uri": "http://www.isharearena.com/wp-content/uploads/2012/12/wallpaper-281049.jpg"
                    }
                },
                "options": [
                    {
                        "label": {
                            "type": "application/vnd.lime.web-link+json",
                            "value": {
                                "title": "First weblink",
                                "uri": "https://server.com/first/link1"
                            }
                        }
                    },
                    {
                        "label": {
                            "type": "text/plain",
                            "value": "First text"
                        },
                        "value": {
                            "type": "application/json",
                            "value": {
                                "key1": "value1",
                                "key2": 2
                            }
                        }
                    }
                ]
            },
            {
                "header": {
                    "type": "application/vnd.lime.media-link+json",
                    "value": {
                        "title": "Second element",
                        "text": "Second element text",
                        "type": "image/jpeg",
                        "uri": "http://www.freedigitalphotos.net/images/img/homepage/87357.jpg"
                    }
                },
                "options": [
                    {
                        "label": {
                            "type": "application/vnd.lime.web-link+json",
                            "value": {
                                "title": "Second",
                                "text": "Weblink",
                                "uri": "https://server.com/second/link2"
                            }
                        }
                    },
                    {
                        "label": {
                            "type": "text/plain",
                            "value": "Second text"
                        },
                        "value": {
                            "type": "application/json",
                            "value": {
                                "key3": "value3",
                                "key4": 4
                            }
                        }
                    },
                    {
                        "label": {
                            "type": "text/plain",
                            "value": "Second text 2"
                        },
                        "value": {
                            "type": "application/json",
                            "value": {
                                "key5": "value5",
                                "key6": 6
                            }
                        }
                    }
                ]
            }
        ]
    }
}
```
