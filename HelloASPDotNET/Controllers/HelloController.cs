using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloASPDotNET.Controllers
{
    [Route("/helloworld")]
    public class HelloController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            string html = "<form method='post' action='/helloworld'>" +
                "<input type='text' name='name' />" +
                "<select name='language'>" +
                "<option value='en'>English</option>" +
                "<option value='fr'>French</option>" +
                "<option value='pl'>Polish</option>" +
                "<option value='de'>German</option>" +
                "<option value='cn'>Chinese</option>" +
                "</select>" +
                "<input type='submit' value='Greet Me!' />" +
                "</form>";

            return Content(html, "text/html");
        }

        // GET: /<controller>/welcome?name=value or GET: /<controller>/welcome/name
        // POST: /<controller>/welcome
        [HttpGet("welcome/{name?}")]
        [HttpPost]
        public IActionResult Welcome(string language, string name = "World")
        {
            return Content($"<h1>{CreateMessage(name, language)}</h1>", "text/html");
        }

        // CreateMessage method
        // inputs: name and language
        // output: a greeting in the given language
        public static string CreateMessage(string name, string language)
        {
            // use a conditional to select a greeting based on the language
            // if language is 'en', then output "Hello, {name}" (solution in last recording and book)

            // But what if we used a dictionary? We could have each key be 
            // a language, and each value be the greeting in that language
            // Then, all we would have to is pass the chosen language
            // to this Dictionary as a key, and we would get back the greeting value.
            Dictionary<string, string> greetings = new Dictionary<string, string>();
            greetings.Add("en", $"Hello, {name}!");
            greetings.Add("fr", $"Bonjour, {name}!");
            greetings.Add("pl", $"Witam, {name}!");
            greetings.Add("de", $"Hallo, {name}!");
            greetings.Add("cn", $"Ni hao, {name}!");

            return greetings[language];
        }
    }
}
