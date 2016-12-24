using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcApplicationEvents.Models;

namespace _4EventsTestPoject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPost()
        {
            CurrentAccount.ID = 1;
            Message M = new Message("C", "C");
            Contribution C = new Contribution(DateTime.Now, "Mededeling", 0, 0, 0, M, 1);
            Event Event = new Event(1, "Hoeden", "twaalf");
            //Event.CreateContribution(C);

            Assert.AreEqual(Event.CreateContribution(C), true);
        }
    }
}
