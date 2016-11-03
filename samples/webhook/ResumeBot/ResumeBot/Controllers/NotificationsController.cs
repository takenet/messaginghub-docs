using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ResumeBot.Controllers
{
    public class NotificationsController : ApiController
    {
        // POST api/values
        public void Post([FromBody]JObject jsonObject)
        {
            Console.WriteLine($"Received Notification  {jsonObject}");
        }
    }
}
