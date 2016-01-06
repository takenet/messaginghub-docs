# Domains

**Domains** are message networks connected to the Messaging Hub where **applications** can receive and send messages. Each domain has an identifier, which is normally a [FQDN](https://pt.wikipedia.org/wiki/FQDN).

In order to traffic envelopes (messages, commands and notifications) in a domain, an application must be published to it, being the publication done through the [portal](http://messaginghub.io). At the time of the publication, specific settings of the application may be required. These settings can be used in the translation of the application address (*myapplication@msging.net*), in case of the domain doesn't support federation.
