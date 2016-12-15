using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcApplicationEvents.Models;
using System.Collections.Generic;

namespace _4EventsTestPoject
{
    [TestClass]
    public class BeheerSysteemTest
    {
        [TestMethod]
        public void CreateEventTestMethod()
        {
            DateTime Datestart = new DateTime(2017,3,3);
            DateTime Dateend = new DateTime(2017, 3, 6);
            Location Location = new Location(1, "pantje", "pandje", "33A", "6609", "Tilburg");
            Event Event = new Event("Test", Location, Datestart, Dateend, 50, "doe een hoed op ");

            bool test = Event.CreateEvent(Event);

            Assert.AreEqual(test, true);

        }

        [TestMethod]
        public void GetEventTestMethod()
        {
            List<Event> EventList = new List<Event>();

            DateTime Datestart = new DateTime(2017, 3, 3);
            DateTime Dateend = new DateTime(2017, 3, 6);
            Location Location = new Location(1, "pantje", "pandje", "33A", "6609", "Tilburg");
            Event Event = new Event("Test", Location, Datestart, Dateend, 50, "doe een hoed op ");

            EventList.Add(Event);
            bool test = Event.CreateEvent(Event);

            Assert.AreEqual(CurrentAccount.GetEvents()[0].DateEnd, EventList[0].DateEnd);

        }
    }
}
