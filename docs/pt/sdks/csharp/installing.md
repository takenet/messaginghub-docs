### Instalação

O SDK C# do BLiP permite a construção de chatbots escaláveis de maneira simples e ágil. O seu código está [aberto no Github](https://github.com/takenet/blip-sdk-csharp) e utiliza como base o .NET Core 2.0, que suporta diversas plataformas, como **Windows**, **Linux** e **Mac**. 

A versão requerida do SDK do .NET Core é a 2.0 ou superior, que está disponível para instalação [aqui](https://dot.net/core).

Para verificar a versão do .NET Core instalada, execute o seguinte comando no shell do sistema operacional:

```
dotnet --version
```

O resultado deve ser `2.0.0` ou uma versão mais recente.

#### Instalando o template de projeto

O BLiP utiliza templates do `dotnet` para acelerar a criação dos projetos. Para utilizar os templates é necessário, antes de tudo, instalar os templates do BLiP em sua máquina. Utilize o seguinte comando para isso:

```
dotnet new -i Take.Blip.Client.Templates::*
```

A partir daí, é possível criar projetos utilizando os templates do BLiP. Os templates suportados são:

- `blip-console` - Executa a aplicação como um `console application`
- `blip-web` - Executa a aplicação como um `ASP.NET Core application` (experimental)

O próximo passo é criar o diretório para seu chatbot e criar um novo projeto a partir do template:

```
mkdir MeuBot
cd MeuBot
dotnet new blip-console
```

Desta forma, é criado um projeto `MeuBot.csproj` e todos os arquivos necessários para o funcionamento da sua aplicação. Utilize seu editor favorito para continuar o desenvolvimento.

> É recomendado utilizar o Visual Studio 2017.3 (Windows) ou Visual Studio Code (Windows, Mac, Linux)

Na pasta do projeto, é criado o arquivo `application.json` que define todas as configurações da sua aplicação.

Você precisará de um identificador e uma chave de acesso para poder se conectar ao Messaging Hub. Para obtê-los:
- Acesse o [Painel BLiP](https://portal.blip.ai).
- Na aba `Chatbots` clique em `Criar chatbot`.
- Etapa escolha a opção `SDK` e preencha as informações solicitadas
- Pronto, seu chatbot foi criado e o identificador e chave de acesso serão exibidos.

O identificador e a chave de acesso devem ser definidos no arquivo `application.json` do seu projeto.
