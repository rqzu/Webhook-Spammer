using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Spammer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.Title = "[Webhook Spammer] by Ascii Services | Service: Spammer";

            Console.WriteLine("[?] What is the webhook URL: ");
            string webhook = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("[?] Username: ");
            string username = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("[?] Avatar URL: ");
            string avatar = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("[?] Message to spam: ");
            string message = Console.ReadLine();

            Console.Clear();

            WebClient client = new WebClient();

            NameValueCollection values = new NameValueCollection();

            values.Add("content", message);
            values.Add("avatar_url", avatar);
            values.Add("username", username);

            while (true)
            {
                try
                {
                    byte[] responseArray = client.UploadValues(webhook, values);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"[!] Sent a message");
                    Console.ResetColor();
                    Thread.Sleep(500);
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    //Console.WriteLine(e);
                    Console.WriteLine($"[!] Rate Limited\nWaiting 10 Seconds");
                    Console.ResetColor();
                    Thread.Sleep(10000);
                }
            } 
        }
    }
}
