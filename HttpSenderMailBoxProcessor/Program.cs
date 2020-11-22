using System;
using HttpSenderMailBoxProcessorClient;

namespace HttpSenderMailBoxProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            Agent.Add(new Dto.Message<object>("http://ya.ru", new ExampleMessage()
            {
                Guid = Guid.NewGuid(),
                Name = "Test"
            }));
            Console.ReadLine();
        }
    }
}
