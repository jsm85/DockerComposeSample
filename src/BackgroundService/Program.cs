using System;
using System.Threading;
using EasyNetQ;

namespace BackgroundService
{
    public class Program
    {
        private static ManualResetEvent _quitEvent = new ManualResetEvent(false);

        public static void Main(string[] args)
        {
            var bus = RabbitHutch.CreateBus("host=rabbit");
            
            Console.CancelKeyPress += (sender, eArgs) =>
            {
                _quitEvent.Set();
                eArgs.Cancel = true;
            };
            
            bus.Subscribe<string>("sub_id", msg =>
            {
               System.Console.WriteLine(string.Format("Message Received: {0}", msg)); 
            });
            
            _quitEvent.WaitOne();
            
            bus.Dispose();
        }
    }
}
