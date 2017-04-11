### Installation

> Is necessary the *Visual Studio 2015 Update 1* and the *.NET Framework 4.6.1* or above.

On Visual Studio, create a new *Class library* project.

Go to Package Manager Console and install a BLiP chatbot template package using:

    Install-Package Takenet.MessagingHub.Client.Template


This package install all nedded dependences and create a `application.json` file that define all application settings.

You will need an `identifier` and a `access key` to connect a chatbot to **BLiP Messaging Hub**. To get thems:
- Go to [Painel BLiP](http://portal.blip.ai/).
- Click in `Chatbots` and then click in `Create chatbot`.
- Choice `SDK` template option
- Ok, `identifier` and `access key` will be displayed

The `identifier` and a `access key` must be defined on `application.json` file of your project.
