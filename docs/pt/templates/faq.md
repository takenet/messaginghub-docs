### FAQ

Para utilizar o modelo FAQ, é necessário inicialmente Configurar inteligência artificial. Você pode acessar através do link como demonstrado na imagem abaixo ou através do menu lateral chamado *Inteligência Artificial*

<img width="500px" src="https://github.com/takenet/messaginghub-docs/raw/master/docs/pt/templates/faq1.png" />

<img width="500px" src="https://github.com/takenet/messaginghub-docs/raw/master/docs/pt/templates/faq2.png" />

Após ter configurado a inteligência artificial, é necessário criar a base de conhecimento. Para isso você terá que cadastrar perguntas e respostas através do botão “NOVA RESPOSTA” como demonstrado na imagem abaixo.

<img width="500px" src="https://github.com/takenet/messaginghub-docs/raw/master/docs/pt/templates/faq3.png" />

Será exibida uma tela onde será possível cadastrar as perguntas e a resposta correspondente. Você pode cadastrar mais de uma pergunta para a mesma resposta.

<img width="500px" src="https://github.com/takenet/messaginghub-docs/raw/master/docs/pt/templates/faq4.png" />

Após cadastrar uma pergunta, o botão “TREINAR CHATBOT” será habilitado. Isso irá ocorrer sempre que uma resposta for criada, excluída ou editada.
Observações: 
1 - Caso esteja utilizando o Natural Language Classifier é necessário ter no mínimo 5 respostas cadastradas.
2 - Caso esteja utilizando o Conversation no modelo gratuito, podem ser cadastradas no máximo 25 respostas.
 
 <img width="500px" src="https://github.com/takenet/messaginghub-docs/raw/master/docs/pt/templates/faq5.png" />
 
Após finalizar o cadastro das respostas, clique em “TREINAR CHATBOT” e aguarde a finalização do treinamento.  

<img width="500px" src="https://github.com/takenet/messaginghub-docs/raw/master/docs/pt/templates/faq6.png" />

O botão “TREINAR CHATBOT” ficará desabilitado e assim que o treinamento for finalizado o botão PUBLICAR será habilitado. 
 
 <img width="500px" src="https://github.com/takenet/messaginghub-docs/raw/master/docs/pt/templates/faq7.png" />
 
Clique no botão “PUBLICAR”.

<img width="500px" src="https://github.com/takenet/messaginghub-docs/raw/master/docs/pt/templates/faq8.png" />

Para verificar os resultados é necessário realizar a publicação do seu chatbot em algum dos canais disponíveis através do menu Publicações.

<img width="500px" src="https://github.com/takenet/messaginghub-docs/raw/master/docs/pt/templates/faq9.png" />

Após o envio de mensagens através dos canais, é possível verificar a quantidade de perguntas respondidas e não respondidas, além da quantidade intenções que foram utilizadas. Esses gráficos podem ser encontrados no menu Análise de Dados como demonstra a figura abaixo.  
<img width="500px" src="https://github.com/takenet/messaginghub-docs/raw/master/docs/pt/templates/faq10.png" />

Durante a conversa pode acontecer o cenário em que o cliente envia uma pergunta que não está cadastrada. Essas perguntas podem ser verificadas no menu Configurações > Perguntas não identificadas. Nesta tela você tem a possibilidade de vincular a pergunta a alguma resposta previamente cadastrada.  

<img width="500px" src="https://github.com/takenet/messaginghub-docs/raw/master/docs/pt/templates/faq11.png" />

Para isso basta clicar no campo “Associe a uma pergunta”, selecionar a pergunta desejada e clicar no ícone “Confirmar”

<img width="500px" src="https://github.com/takenet/messaginghub-docs/raw/master/docs/pt/templates/faq12.png" />

<img width="500px" src="https://github.com/takenet/messaginghub-docs/raw/master/docs/pt/templates/faq13.png" />
 
Após vincular uma nova pergunta a uma resposta previamente cadastrada, será necessário realizar o processo de treinamento e publicação do chatbot novamente para que as alterações sejam atualizadas. 


#### Menu inteligência artificial

##### Configuração IBM Watson Natural Language Classifier

O Natural Language Classifier é um serviço que permite a compreensão da linguagem natural, utilizando aprendizagem de máquina, para responder de uma forma semelhante a um humano. A compreensão da linguagem natural é realizada através da interpretação de intenções a partir de textos e retornando uma classificação com níveis de confiança, permitindo que possa ser disparada alguma ação como por exemplo responder a uma pergunta. Para mais informações sobre o Natural Language Classifier acesse:https://www.ibm.com/watson/developercloud/nl-classifier.html

Para configurar é necessário criar uma conta no Bluemix (https://console.ng.bluemix.net/).
Após a criação da conta é necessário criar um Serviço, para isso acesse o Bluemix e no menu lateral clique em “Serviços”, como demonstrado na imagem abaixo, e clique em “Criar serviço Watson”

<img width="500px" src="https://github.com/takenet/messaginghub-docs/raw/master/docs/pt/templates/faq14.png" />

Selecione a opção “Watson” como demonstrado abaixo

<img width="500px" src="https://github.com/takenet/messaginghub-docs/raw/master/docs/pt/templates/faq15.png" />

Pesquise por Natural Language Classifier, selecione a opção Natural Language Classifier e crie o seu serviço

<img width="500px" src="https://github.com/takenet/messaginghub-docs/raw/master/docs/pt/templates/faq16.png" />

Após criar o serviço, é necessário obter as credenciais para configurar no BLiP. Para isso clique no menu “Credenciais de serviço” e depois em “Visualizar credenciais” como demonstrado abaixo. 

<img width="500px" src="https://github.com/takenet/messaginghub-docs/raw/master/docs/pt/templates/faq17.png" />

Das informações exibidas, copie o conteúdo de “username” e insira no campo “NOME DE USUÁRIO” no BLiP e copie o conteúdo de “password” e insira no campo “SENHA” no BLiP como demonstrado abaixo e clique em salvar.

<img width="500px" src="https://github.com/takenet/messaginghub-docs/raw/master/docs/pt/templates/faq18.png" />

##### Configuração IBM Watson Conversation

IBM Watson Conversation possui funcionalidades do Natural Language Classifier (NLC), do Dialog e algumas outras funcionalidades que permitem a compreensão da linguagem natural para responder de uma forma semelhante a um humano. O IBM Watson Conversation possui uma versão Free, porém existem algumas restrições como o limite de 1000 requisições por mês, até 3 classificadores (o BLiP necessita de 2 classificadores por chatbot) e até 25 intenções cadastradas. Para mais informações acesse: https://www.ibm.com/watson/developercloud/conversation.html

Para configurar é necessário criar uma conta no Bluemix (https://console.ng.bluemix.net/). Após a criação da conta é necessário criar um Serviço, para isso acesse o Bluemix e no menu lateral clique em “Serviços”, como demonstrado na imagem abaixo, e clique em “Criar serviço Watson”

<img width="500px" src="https://github.com/takenet/messaginghub-docs/raw/master/docs/pt/templates/faq19.png" />
 
Selecione a opção “Watson” como demonstrado abaixo

<img width="500px" src="https://github.com/takenet/messaginghub-docs/raw/master/docs/pt/templates/faq20.png" />

Pesquise por Conversation, selecione a opção Conversation e crie o seu serviço

<img width="500px" src="https://github.com/takenet/messaginghub-docs/raw/master/docs/pt/templates/faq21.png" />

Após criar o serviço, é necessário obter as credenciais para configurar no BLiP. Para isso clique no menu “Credenciais de serviço” e depois em” Visualizar credenciais” como demonstrado abaixo.

<img width="500px" src="https://github.com/takenet/messaginghub-docs/raw/master/docs/pt/templates/faq22.png" />

Das informações exibidas, copie o conteúdo de “username” e insira no campo “NOME DE USUÁRIO” no BLiP e copie o conteúdo de “password” e insira no campo “SENHA” no BLiP como demonstrado abaixo e clique em salvar.

<img width="500px" src="https://github.com/takenet/messaginghub-docs/raw/master/docs/pt/templates/faq23.png" />

Após realizar a configuração da Inteligência artificial, você já pode voltar ao menu Configurações > Base de Conhecimento e cadastrar as perguntas e respostas do FAQ.
