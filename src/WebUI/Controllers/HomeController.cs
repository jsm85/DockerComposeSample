using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyNetQ;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IBus _bus = RabbitHutch.CreateBus("host=rabbit");

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(string messageTextBox)
        {
            _bus.Publish(messageTextBox);

            return View("Sent");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
