using StackExchange.Redis;
using System;
using System.Threading;

namespace RedisPublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = ConnectionMultiplexer.Connect("127.0.0.1:6379");

            var publisher = connection.GetSubscriber();

            int orderNum = 1;
            while (true)
            {

                var random = new Random();
                var price = Math.Round((decimal)(random.NextDouble() * (1000 - 1) + 1), 2);
                publisher.Publish("order", $"{{ order: {orderNum}, price: {price} }}");

                Console.ForegroundColor = ConsoleColor.Green; 
                Console.WriteLine("{ order: " + orderNum + ", price: " + price + "}");
                Console.ResetColor(); 

                orderNum++;
                Thread.Sleep(1000);
            }
        }
    }
}