---
layout: page
title: Services
---

**Service** are *building blocks* for messaging applications that encapsulates common functionality for they construction. They are like *special* applications which instead of having a simple identifier (*name@msging.net*) they have a subdomain within the Messaging Hub (*anything@myservice.msging.net*) receiving all messages, notifications and commands addressed to it.

The service be found on the [portal](http://messaginghub.io) where each one's documentation is available. To use a service in a aplication, it must be activated in the portal. A service may require specific configurations and permission send in its behalf as well. For example, a ```broadcast``` service may need of the ```windowSize``` besides the permission to send in behalf of the application. Both settings and permissions are provided at the time of the activation in the portal.

After the activation, the application can interact with the service through messages and commands. Each service mechanics is different and should be specified on its documentation. Continuing the previous example, a service "broadcast" can support commands to add receipts to a distribution list and can receive messages addressed to ```distribution-list-name@broadcast.msging.net``` and forward it to the list members.
