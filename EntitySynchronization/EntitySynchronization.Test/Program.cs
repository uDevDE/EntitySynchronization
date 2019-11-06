using System;

using EntitySynchronization.Core.Attributes;
using EntitySynchronization.Core.Interfaces;
using EntitySynchronization.Core.Extensions;

namespace EntitySynchronization.Test
{
    public class Test : IEntitySyncable
    {
        [EntitySyncIgnore]
        public int Foo { get; set; }

        public int Bar { get; set; }

        public Guid Identifier { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var test = new Test().CreateIdentifier();
            Console.WriteLine(test.ToString());

            Console.ReadKey();
        }
    }
}
