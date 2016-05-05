Os **domínios** são redes de mensagem conectadas ao Messaging Hub de onde as **aplicações** podem receber e enviar mensagens. Cada domínio tem um identificador, que normalmente é um [FQDN](https://pt.wikipedia.org/wiki/FQDN).

Para poder trafegar envelopes (mensagens, comandos e notificações) em um domínio, uma aplicação deve estar publicada no mesmo, sendo que esta publicação é feita através do [portal](http://messaginghub.io). No momento da publicação, podem ser requeridas configurações específicas da aplicação no domínio. Estas configurações podem ser utilizadas para fazer a tradução do endereço da aplicação (*myapplication@msging.net*) neste domínio, caso o mesmo não suporte federação. 

## OMNI

O [OMNI](http://letsomni.com.br/business/) é um App diponível na [Google Play](https://play.google.com/store/apps/details?id=net.take.omni) para que empresas possam conversar com seus clientes e gerenciar seu perfil de serviços.

Após ativar o domínio OMNI para sua aplicação, você pode personalizá-la acessando o [Portal do Let´s OMNI](http://letsomni.com.br/business)

Observação: *Aplicações do Messaging Hub* são chamadas de *Serviços* pelo aplicativo OMNI.

## Tangram

O domínio Tangram, desenvolvido e mantido pela [Take.net](http://take.net), permite que suas aplicações usem *SMS* para enviar e receber mensagens. Para configurar sua aplicação para usar este domínio, acesse o [Portal do Messaging Hub](http://messaginghub.io/applications), selecione a sua aplicação, clique em *Detalhes* e em seguinda no botão *Ativar* para o domínio Tangram. Após ativado, seu número *SMS* será exibido no campo *Id da Aplicação*.

## Facebook

Para publicar sua aplicação no *Facebook Messenger*, vá ao site [Facebook for Developers](http://developers.facebook.com), crie sua aplicação e tome nota dos parâmetros *VerifyToken*, *PageId* e *PageAccessToken*. Agora cesse o [Portal do Messaging Hub](http://messaginghub.io/applications), selecione sua aplicação, clique em *Detalhes* e em seguida no botão *Ativar* para o domínio Facebook. Após ativado, seus identificador do *Facebook* será exibido no campo *Id da Aplicação*. Para finalizar a ativação da sua *aplicação*, vá novamente em [Facebook for Developers](http://developers.facebook.com) e informe o endereço do webhookda sua aplicação. Esse endereço será: [http://msginig.net:8089/webhook/SEU_ID_DE_APLICACAO](http://msginig.net:8089/webhook/SEU_ID_DE_APLICACAO).
