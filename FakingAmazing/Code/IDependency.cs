using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FakingAmazing.Code
{
    public interface IDependency
    {
        void AMethod();
        int AMethodWithAReturnValue();
        void AMethodWhichTakesArguments(int number, string text);
        bool TryParse(string text, out int result);

        int AutoProperty { get; set; }

        event EventHandler<MyEventArgs> AnEvent;
        event CustomEventSignature CustomEvent;

        Task SomethingAsync();
        Task<int> SomeAsyncInt();

        IEnumerable<int> ASequence { get; }
    }

    public delegate void CustomEventSignature(int number);

    public class MyEventArgs : EventArgs
    {
    }
}
