using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Threading;
using ResumeBot.Services;

namespace ResumeBot.Controllers
{
    public class MessagesController : ApiController
    {
        private readonly WebClientService webClientService;

        public MessagesController()
        {
            webClientService = new WebClientService(new Uri("https://msging.net/messages"), "<your-api-key-here>");
        }
        
        // POST api/messages
        public async Task<IHttpActionResult> Post(JObject message)
        {
            Console.WriteLine($"Message Received: {message}");

            var content = message["content"].Value<string>();
            var from = message["from"].Value<string>();
            var messageContent = "";

            switch (content.Trim())
            {
                case "info":
                case "informação":
                case "about":
                    messageContent = "Meu nome é Jonh Lorem Foo, eu tenho 25 anos. \n\nVocê pode me encontrar por telefone: +55 31 99827 1039 ou através do meu email: loremfoo@ipsum.com";
                    break;

                case "formação":
                case "formacao":
                case "education":
                    messageContent = "*Mestre em Física Nuclear pela NASA\n*Graduado em Economia pela Faculdade de Harvard - USA";
                    break;

                case "experiência":
                case "experiencia":
                case "experience":
                    messageContent = "Possuo 10 anos de experiência em análise de dados complexos. Meus últimos trabalhos foram para:\n\nGoogle\nFacebook\nNSA\nMicrosoft";
                    break;

                case "habilidade":
                case "skills":
                    messageContent = "Principais habilidades: \n\nComunicador\nExtrovertido\nGosta de trabalhar em equipe\nProgramação Android";
                    break;

                default:
                    //default message if user send a unknow command
                    messageContent = "Oi, eu sou o chat bot do Jonh :) \nPosso lhe passar várias informações profissionais sobre ele. \n\nSe quiser saber mais me mande um dos comandos abaixo: \n\nabout\neducation\nexperience\nskills!";
                    break;
            }

            var replyMessage = new
            {
                id = Guid.NewGuid(),
                to = from,
                type = "text/plain",
                content = messageContent
            };

            await ReplyMessageAsync(replyMessage);

            return Ok();
        }

        private async Task ReplyMessageAsync(object message)
        {
            var response = await webClientService.SendMessageAsync(message);
        }
    }
}
