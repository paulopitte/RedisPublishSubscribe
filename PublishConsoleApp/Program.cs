using StackExchange.Redis;
using System;
using System.Threading;

namespace RedisPublisher;
    class Program
    {
        static void Main(string[] args)
        {
            var connection = ConnectionMultiplexer.Connect("127.0.0.1:6379");

            var publisher = connection.GetSubscriber();

            int orderNum = 1;
            while (true)
            {
                publisher.Publish("order", "{ order: " + orderNum + ", price: 123.23}");

                Console.WriteLine("{ order: " + orderNum + ", price: 123.23}");
                orderNum++;
                Thread.Sleep(1000);
            }
        }
    }
