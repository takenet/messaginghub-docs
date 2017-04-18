### Event analysis
| Address               | Base URI     |  C#                 |
|-----------------------|--------------|---------------------|
| postmaster@msging.net (default address - not required) | /event-track | [EventTrackExtension](https://github.com/takenet/messaginghub-client-csharp/blob/master/src/Takenet.MessagingHub.Client/Extensions/EventTrack/EventTrackExtension.cs) |

The **event analysis** extension allows the registration of chatbot's events for creation of analytics reports in the portal. The events are agregated by category, action and day.

#### Exemples
1 - Registering an event:
```json
{  
  "id": "9494447a-2581-4597-be6a-a5dff33af156",
  "method": "set",
  "type": "application/vnd.iris.eventTrack+json",
  "uri": "/event-track",
  "resource": {  
    "category": "billing",
    "action": "payment"
  }
}
```
Response on success:
```json
{
  "method": "set",
  "status": "success",
  "id": "9494447a-2581-4597-be6a-a5dff33af156",
  "from": "postmaster@msging.net/#irismsging1",
  "to": "contact@msging.net/default"
}
```


2 - Retrieving stored events:
```json
{  
  "id": "1",
  "method": "get",
  "uri": "/event-track"
}
```
Response on success:
```json
{
  "method": "get",
  "status": "success",
  "id": "1",
  "from": "postmaster@msging.net/#irismsging1",
  "to": "contact@msging.net/default",
  "resource": [{
      "category": "billing"
  },
  {
      "category": "account"
  }]
}
```


3 - Retrieving event counters:

Available *querystring* filters:

| QueryString        | Description                               |
|--------------------|-------------------------------------------| 
| filterDate         | Limit date for retrieving the items       |
| take               | Limit of total of items to be returned    |

```json
{  
  "id": "57aa0ac2-158c-4012-9f18-b8eedaede85c",
  "method": "get",
  "uri": "/event-track/billing"
}
```

Response on success:
```json
{
  "method": "get",
  "status": "success",
  "id": "57aa0ac2-158c-4012-9f18-b8eedaede85c",
  "from": "postmaster@msging.net/#irismsging1",
  "to": "contact@msging.net/default",
  "resource": [{
      "category": "billing",
      "action": "payment",
      "storageDate": "2016-01-01",
      "count": 10
  },
  {
      "category": "billing",
      "action": "payment",
      "storageDate": "2016-01-02",
      "count": 20
  }]
}
```
