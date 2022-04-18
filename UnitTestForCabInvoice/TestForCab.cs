using System;
using System.Text;
using CabInvoiceGenerator;
using NUnit.Framework;
using System.Collections.Generic;



namespace UnitTestForCabInvoice
{
    public class Tests
    {
        Invoicegenerator invoicegeneratorNormalRide;


        [SetUp]
        public void Setup()
        {
            invoicegeneratorNormalRide = new Invoicegenerator();

        }

        [Test]
        [TestCase(9, 7)]

        public void TimeAndDistanceCalculateFare(double distane, double time)
        {
            Rides rides = new Rides(distane, time);
            int expected = 97;
            Assert.AreEqual(expected, invoicegeneratorNormalRide.TotalFareForSingleRide(rides));
        }
        [Test]
        public void ForinvaidDistance()
        {
            Rides rides = new Rides(-3, 6);
            CabInvoiceException cabInvoiceException = Assert.Throws<CabInvoiceException>(() => invoicegeneratorNormalRide.TotalFareForSingleRide(rides));
            Assert.AreEqual(cabInvoiceException.type, CabInvoiceException.ExcepionType.Invalid_Distance);
        }
        [Test]
        public void ForinvaidTime()
        {
            Rides rides = new Rides(3, -6);
            CabInvoiceException cabInvoiceException = Assert.Throws<CabInvoiceException>(() => invoicegeneratorNormalRide.TotalFareForSingleRide(rides));
            Assert.AreEqual(cabInvoiceException.type, CabInvoiceException.ExcepionType.Invalid_Time);
        }

        //UC-2
        [Test]
        public void CalculateFareForMultipleRides()
        {
            Rides rides_1 = new Rides(2, 2);
            Rides rides_2 = new Rides(2, 1);

            List<Rides> rides = new List<Rides>();
            rides.Add(rides_1);
            rides.Add(rides_2);


            Assert.AreEqual(43.0d, invoicegeneratorNormalRide.TotalFareForMltipleRide(rides));

        }
    }
}

    
