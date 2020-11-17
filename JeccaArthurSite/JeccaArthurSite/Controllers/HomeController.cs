using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Winterfell.Models;

namespace Winterfell.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        MessageContext context;

        // any controller that needs to access the db must have an instance of the context object
        // passed to its constructor as a param (MessageContext c)
        public HomeController(ILogger<HomeController> logger, MessageContext c)
        {
            _logger = logger;

            context = c;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        // invoke the view with a form for entering a message
        public IActionResult Message()
        {
            return View();
        }

        // return form input
        [HttpPost]
        public IActionResult Message(Message model)
        {
            model.Date = DateTime.Now;

            // add the model to the database and save changes
            context.Messages.Add(model);
            context.SaveChanges();

            return View(model);
        }

        // gets data from database
        public IActionResult Messages()
        {
            // use var - implicit variable
            var messageList = context.Messages.Include(message => message.Sender)
                .Include(message => message.Recipient)
                .ToList<Message>();

            return View(messageList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
