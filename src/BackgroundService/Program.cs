using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EasyNetQ;

namespace BackgroundService
{
    public class Program
    {
        private static readonly ManualResetEvent QuitEvent = new ManualResetEvent(false);

        public static void Main(string[] args)
        {
            var bus = RabbitHutch.CreateBus("host=rabbit");

            Console.CancelKeyPress += (sender, eArgs) =>
            {
                QuitEvent.Set();
                eArgs.Cancel = true;
            };

            bus.Subscribe<string>("sub_id", msg =>
            {
                Console.WriteLine(string.Format("Message Received: {0}", msg));
            });

            QuitEvent.WaitOne();

            bus.Dispose();
        }
    }
}
