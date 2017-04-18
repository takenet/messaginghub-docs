### FAQ

To use the FAQ template, you must first configure Artificial Intelligence. You can access through the link as shown in the image below or through the side menu called *Artificial Intelligence*

<Img width = "600px" src = "https://github.com/takenet/messaginghub-docs/raw/master/docs/pt/templates/faq1.png" />

<Img width = "600px" src = "https://github.com/takenet/messaginghub-docs/raw/master/docs/en/templates/faq2.png" />

Once you have configured artificial intelligence, you need to create the knowledge base. For this you will have to register questions and answers through the "NEW ANSWER" button as shown in the image below.

<Img width = "600px" src = "https://github.com/takenet/messaginghub-docs/raw/master/docs/en/templates/faq3.png" />

You will be presented with a screen where you can register the questions and the corresponding answer. You can enter more than one question for the same answer.

<Img width = "600px" src = "https://github.com/takenet/messaginghub-docs/raw/master/docs/en/templates/faq4.png" />

After registering a question, the "TRAIN CHATBOT" button will be enabled. This will occur whenever a response is created, deleted, or edited.
Comments:
1 - If you are using the Natural Language Classifier you must have at least 5 answers registered.
2 - If you are using Conversation in the free template, a maximum of 25 responses can be registered.
 
 <Img width = "600px" src = "https://github.com/takenet/messaginghub-docs/raw/master/docs/en/templates/faq5.png" />
 
After completing the answers, click on "TRAIN CHATBOT" and wait for the training to finish.

<Img width = "600px" src = "https://github.com/takenet/messaginghub-docs/raw/master/docs/en/templates/faq6.png" />

The "TRAIN CHATBOT" button will be disabled and once the training is finished the PUBLISH button will be enabled.
 
 <Img width = "600px" src = "https://github.com/takenet/messaginghub-docs/raw/master/docs/en/templates/faq7.png" />
 
Click the "PUBLISH" button.

<Img width = "600px" src = "https://github.com/takenet/messaginghub-docs/raw/master/docs/en/templates/faq8.png" />

To check the results, it is necessary to publish your chatbot in any of the available channels through the Publications menu.

<Img width = "600px" src = "https://github.com/takenet/messaginghub-docs/raw/master/docs/en/templates/faq9.png" />

After sending messages through channels, you can check the amount of questions answered and unanswered, in addition to the amount of intentions that were used. These graphs can be found in the Data Analysis menu as shown in the figure below.
<Img width = "600px" src = "https://github.com/takenet/messaginghub-docs/raw/master/docs/en/templates/faq10.png" />

During the conversation, the scenario where the client sends a question that is not registered may occur. These questions can be checked in the Settings > Unidentified Questions menu. In this screen you have the possibility to link the question to a previously registered answer.

<Img width = "600px" src = "https://github.com/takenet/messaginghub-docs/raw/master/docs/en/templates/faq11.png" />

To do this simply click on the "Associate a question" field, select the desired question and click on the "Confirm"

<Img width = "600px" src = "https://github.com/takenet/messaginghub-docs/raw/master/docs/en/templates/faq12.png" />

<Img width = "600px" src = "https://github.com/takenet/messaginghub-docs/raw/master/docs/en/templates/faq13.png" />
 
After linking a new question to a previously recorded response, you will need to perform the chatbot training and posting process again for the changes to be updated.


#### Artificial intelligence menu

##### IBM Watson Natural Language Classifier

The Natural Language Classifier is a service that allows the understanding of natural language, using machine learning, to respond in a manner similar to a human. Understanding natural language is accomplished by interpreting intentions from texts and returning a ranking with confidence levels, allowing some action to be triggered such as answering a question. For more information on the Natural Language Classifier go to: https: //www.ibm.com/watson/developercloud/nl-classifier.html

To set up you need to create an account on Bluemix (https://console.ng.bluemix.net/).
After the creation of the account is necessary to create a Service, for this access the Bluemix and in the lateral menu click on "Services", as demonstrated in the image below, and click on "Create Watson service"

<Img width = "600px" src = "https://github.com/takenet/messaginghub-docs/raw/master/docs/en/templates/faq14.png" />

Select the "Watson" option as shown below

<Img width = "600px" src = "https://github.com/takenet/messaginghub-docs/raw/master/docs/en/templates/faq15.png" />

Search for Natural Language Classifier, select the Natural Language Classifier option and create your service

<Img width = "600px" src = "https://github.com/takenet/messaginghub-docs/raw/master/docs/en/templates/faq16.png" />

After creating the service, you must obtain the credentials to configure in BLiP. To do so, click on the "Service credentials" menu and then on "View credentials" as shown below.

<Img width = "600px" src = "https://github.com/takenet/messaginghub-docs/raw/master/docs/en/templates/faq17.png" />

From the information displayed, copy the contents of "username" and enter in the "USER NAME" field in the BLiP and copy the content of "password" and enter in the "PASSWORD" field in the BLiP as demonstrated below and click save.

<Img width = "600px" src = "https://github.com/takenet/messaginghub-docs/raw/master/docs/en/templates/faq18.png" />

##### IBM Watson Conversation Configuration

IBM Watson Conversation features Dialog Natural Language Classifier (NLC) features and a few other features that allow you to understand natural language to respond in a human-like way. IBM Watson Conversation has a Free version, however there are some restrictions such as the limit of 1000 requests per month, up to 3 classifiers (the BLiP requires 2 classifiers per chatbot) and up to 25 registered intentions. For more information go to: https://www.ibm.com/watson/developercloud/conversation.html

To set up you need to create an account on Bluemix (https://console.ng.bluemix.net/). After the creation of the account is necessary to create a Service, for this access the Bluemix and in the lateral menu click on "Services", as demonstrated in the image below, and click on "Create Watson service"

<Img width = "600px" src = "https://github.com/takenet/messaginghub-docs/raw/master/docs/en/templates/faq19.png" />
 
Select the "Watson" option as shown below

<Img width = "600px" src = "https://github.com/takenet/messaginghub-docs/raw/master/docs/en/templates/faq20.png" />

Search for Conversation, select Conversation and create your service

<Img width = "600px" src = "https://github.com/takenet/messaginghub-docs/raw/master/docs/en/templates/faq21.png" />

After creating the service, you must obtain the credentials to configure in BLiP. To do so, click on the "Service credentials" menu and then on "View credentials" as shown below.

<Img width = "600px" src = "https://github.com/takenet/messaginghub-docs/raw/master/docs/en/templates/faq22.png" />

From the information displayed, copy the contents of "username" and enter in the "USER NAME" field in the BLiP and copy the content of "password" and enter in the "PASSWORD" field in the BLiP as demonstrated below and click save.

<Img width = "600px" src = "https://github.com/takenet/messaginghub-docs/raw/master/docs/en/templates/faq23.png" />

After performing the Artificial Intelligence configuration, you can go back to the Settings> Knowledge Base menu and register the FAQ questions and answers.
