using StackExchange.Redis;

namespace RedisSubscriber;
class Program
{
    static void Main(string[] args)
    {
        var connection = ConnectionMultiplexer.Connect("127.0.0.1:6379");
        var subscriber = connection.GetSubscriber();
        Console.ForegroundColor = ConsoleColor.Blue;
        subscriber.Subscribe("order", (channel, message) =>
            {
                Console.WriteLine($"{DateTime.UtcNow:o} => {message}");
            }, CommandFlags.None);

        Console.ReadLine();
    }
}
