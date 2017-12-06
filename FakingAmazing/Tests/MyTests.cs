using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using FakeItEasy;
using FakeItEasy.Core;
using FakingAmazing.Code;
using Moq;
using NUnit.Framework;

namespace FakingAmazing.Tests
{
    [TestFixture]
    public class MyTests
    {
        private Mock<IDependency> mock;

        [SetUp]
        public void Creating_the_mock()
        {
             mock = new Mock<IDependency>(MockBehavior.Default);
        }

        [Test]
        public void Verify_A_MethodCall()
        {
            mock.Verify(m => m.AMethod(), Times.Never);

            mock.Object.AMethod();
            mock.Verify(m => m.AMethod(), Times.Once);
        }

        [Test]
        public void Specify_a_return_value()
        {
            mock.Setup(m => m.AMethodWithAReturnValue())
                .Returns(5);

            Assert.That(mock.Object.AMethodWithAReturnValue(), Is.EqualTo(5));
        }

        [Test]
        public void Capturing_arguments()
        {
            int number = 0;

            mock.Setup(m => m.AMethodWhichTakesArguments(It.IsAny<int>(), It.IsAny<string>()))
                .Callback<int, string>((i, s) =>
                {
                    number = i;
                });

            mock.Object.AMethodWhichTakesArguments(5, "hello");

            mock.Verify(m => m.AMethodWhichTakesArguments(It.IsAny<int>(), It.IsRegex("hello")));
            Assert.That(number, Is.EqualTo(5));
        }

        [Test]
        public void Property_setters()
        {
            mock.SetupSet(m => m.AutoProperty = 5).Verifiable();
            mock.Object.AutoProperty = 5;
            mock.Verify();

            mock.Object.AutoProperty = 10;
            mock.VerifySet(m => m.AutoProperty = 10);

        }

        [Test]
        public void Raising_events()
        {
            bool raised = false;
            mock.Object.AnEvent += (sender, args) => raised = true;
            mock.Raise(m => m.AnEvent += null, mock.Object, new MyEventArgs());
            Assert.That(raised, Is.True);

            raised = false;
            mock.Object.CustomEvent += (num) => raised = true;
            mock.Raise(m => m.CustomEvent += null, 5);
            Assert.That(raised, Is.True);
        }

        [Test]
        public async Task Async_methods()
        {
            mock.Setup(m => m.SomeAsyncInt())
                //.Returns(Task.FromResult(5));
                .ReturnsAsync(5);

            var result = await mock.Object.SomeAsyncInt();

            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public async Task Invoking_extra_code()
        {
            AutoResetEvent reset = new AutoResetEvent(false);

            mock.Setup(m => m.AMethodWhichTakesArguments(It.IsAny<int>(), It.IsAny<string>()))
                .Callback<int, string>((i, s) =>
                {
                    Console.WriteLine("");
                    reset.Set();
                });

            // Some long running code
            // sut.DoSomeStuffNeedingSynchronisation();

            //reset.WaitOne();
        }

        [Test]
        public void Sequences()
        {
            IEnumerable<int> seq = new[] {1, 2, 3, 4, 5};

            mock.SetupSequence(m => m.ASequence)
                .Returns(seq);

            foreach (var i in mock.Object.ASequence)
            {
                Console.WriteLine(i);
            }
        }

        [Test]
        public void Out_and_ref_params()
        {
            
        }
    }
}
