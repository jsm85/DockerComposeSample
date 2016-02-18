using System;
using EasyNetQ;
using Microsoft.AspNet.Mvc;

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
