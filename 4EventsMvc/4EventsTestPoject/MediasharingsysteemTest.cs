using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcApplicationEvents.Models;

namespace _4EventsTestPoject
{
    [TestClass]
    public class MediasharingsysteemTest
    {
        [TestMethod]
        public void TestPost()
        {
            CurrentAccount.ID = 1;
            Message M = new Message("C", "C");
            Contribution C = new Contribution(DateTime.Now, "Mededeling", 0, 0, 0, M, 1);
            Event Event = new Event(1, "Hoeden", "twaalf");

            Assert.AreEqual(Event.CreateContribution(C), true);
        }

        [TestMethod]
        public void TestLike()
        {
            CurrentAccount.ID = 11;
            Message M = new Message("C", "C");
            Contribution C = new Contribution(50);
            Assert.AreEqual(C.likePost(), false);
        }

        [TestMethod]
        public void TestReport()
        {
            CurrentAccount.ID = 11;
            Message M = new Message("C", "C");
            Contribution C = new Contribution(50);
            Assert.AreEqual(C.ReportPost(), false);
        }
    }
}
