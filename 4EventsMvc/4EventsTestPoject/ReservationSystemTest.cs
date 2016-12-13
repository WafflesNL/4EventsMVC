using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcApplicationEvents.Models;
using System.Collections.Generic;

namespace _4EventsTestPoject
{
    [TestClass]
    public class ReservationSystemTest
    {
        [TestMethod]
        public void CreateReservationTestMethod()
        {
            Place place = new Place(1, 30, 45, false);
            DateTime Datestart = new DateTime(2017, 3, 3);
            DateTime Dateend = new DateTime(2017, 3, 6);
            Location Location = new Location(1, "pantje", "pandje", "33A", "6609", "Tilburg");
            Event Event = new Event(1,"hoed","hoed");
            Account Account = new Account(1,"test","test");

            Reservation Reservation = new Reservation(Datestart, Dateend, place, Account, Event);
            bool test = Reservation.CreateReservation(Reservation);

            Assert.AreEqual(test, true);



        }
    }
}