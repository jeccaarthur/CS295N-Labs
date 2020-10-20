using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JeccaArthurSite.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JeccaArthurSite.Controllers
{
    public class NewController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            Message model = new Message();
            User sender = new User();
            User recipient = new User();
            model.Sender = sender;
            model.Recipient = recipient;
            return View(model);
        }

        public IActionResult New()
        {
            return View();
        }

        // invoke the view with a form for entering a message
        public IActionResult Message()
        {
            return View();
        }

        public IActionResult SingleView(Message model)
        {
            return View(model);
        }

        [HttpPost]
        public IActionResult Message(Message model)
        {
            return View(model);
        }
    }
}
