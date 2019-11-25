using System;

using EntitySynchronization.Core.Attributes;
using EntitySynchronization.Core.Interfaces;
using EntitySynchronization.Core.Extensions;

namespace EntitySynchronization.Test
{
    public class Test2 : IEntitySyncable
    {
        public Guid Id { get; set; }

        private int foo2;
        private int bar2;

        [EntitySyncIgnore]
        public int Foo2 { get { return foo2; } set { foo2 = value; OnEntityPropertyChanged(foo2); } }
        public int Bar2 { get { return bar2; } set { bar2 = value; OnEntityPropertyChanged(bar2); } }

        public void OnEntityPropertyChanged<T>(T value, [System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            this.UpdateEntityPropertyValue(value, propertyName);
        }
    }

    public class Test : IEntitySyncable
    {
        private int foo;
        private int bar;
        private Test2 test2;

        
        public int Foo { get { return foo; } set { foo = value; OnEntityPropertyChanged(foo); } }

        public int Bar { get { return bar; } set { bar = value; OnEntityPropertyChanged(bar); } }

        public Test2 Test2 { get { return test2; } set { test2 = value; OnEntityPropertyChanged(test2); } }

        public Guid Id { get; set; }

        public Test() => test2 = new Test2();

        public void OnEntityPropertyChanged<T>(T value, [System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            Test2.Foo2 = 42;
            Test2.Bar2 = 37;

            this.UpdateEntityPropertyValue(value, propertyName);
        }
    }

    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Core.EntitySynchronization.Error += OnError;
            await Core.EntitySynchronization.Init();

            var test = new Test
            {
                Bar = 20
            };
            Console.WriteLine(test.ToString());

            Console.ReadKey();
        }

        private static void OnError(string errorMessage, Exception exception)
        {
            Console.WriteLine(errorMessage + " | {0:s}", exception.Message);
        }

    }

}
