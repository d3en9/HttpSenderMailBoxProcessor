using System;
namespace HttpSenderMailBoxProcessor
{
    public class ExampleMessage
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }

        public ExampleMessage()
        {
            
        }

        public override string ToString() => $"{Guid} {Name}";
    }
}
