using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Session10.Consumer.WebMVC.Controllers
{
    public class PersonController : Controller
    {
        private readonly ILogger<PersonController> logger;

        public PersonController(ILogger<PersonController> logger)
        {
            this.logger = logger;
        }

        public IActionResult Index(string identityt)
        {
            logger.LogInformation("run person controller -> index action ");
            return Ok(RouteData.Values[nameof(identityt)]);
        }
    }
}