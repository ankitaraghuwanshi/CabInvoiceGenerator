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
        RideRepo rideRepo;

        [SetUp]
        public void Setup()
        {
            invoicegeneratorNormalRide = new Invoicegenerator();
            rideRepo = new RideRepo();
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
        [Test]
        public void ListOfRidesCalculateFare()//uc3
        {
            Rides rides_1 = new Rides(2, 2);
            Rides rides_2 = new Rides(2, 1);

            List<Rides> rides = new List<Rides>();
            rides.Add(rides_1);
            rides.Add(rides_2);


            Assert.AreEqual(43.0d, invoicegeneratorNormalRide.InhancedInvoice(rides));
            Assert.AreEqual(21.5d, invoicegeneratorNormalRide.averagePerRide);
            Assert.AreEqual(2, invoicegeneratorNormalRide.numberOfRides);

        }
        [Test]
        public void ValidUserIdInvoice()//uc4
        {
            Rides rides_1 = new Rides(2, 2);
            Rides rides_2 = new Rides(2, 1);

            rideRepo.AddRideRepo("abc", rides_1);
            rideRepo.AddRideRepo("abc", rides_2);

            Assert.AreEqual(43.0d, invoicegeneratorNormalRide.InhancedInvoice(rideRepo.returnListByUserId("abc")));
            Assert.AreEqual(21.5d, invoicegeneratorNormalRide.averagePerRide);
            Assert.AreEqual(2, invoicegeneratorNormalRide.numberOfRides);
        }
        [Test]
        public void InvaidUserIdInvioce()
        {
            Rides rides_1 = new Rides(3, 2);
            Rides rides_2 = new Rides(2, 1);

            rideRepo.AddRideRepo("abc", rides_1);
            rideRepo.AddRideRepo("abc", rides_2);

            var Exception = Assert.Throws<CabInvoiceException>(() => invoicegeneratorNormalRide.TotalFareForMltipleRide(rideRepo.returnListByUserId("xyz")));
            Assert.AreEqual(Exception.type, CabInvoiceException.ExcepionType.Invaild_user_id);

        }
        // UC 5.1 

        [Test]
        [TestCase(6, 5)]
        public void Given_DistanceAndTime_CalculatePremiumFare(double distance, double time)
        {
            Rides rides = new Rides(distance, time);
            int expected = 100;
            Assert.AreEqual(expected, invoicegeneratorNormalRide.TotalFareForPremiumSingleRide(rides));
        }

        // TC 5.2 

        [Test]
        public void Given_InvalidDistance_ThrowsException()
        {
            Rides rides = new Rides(-1, 1);

            CabInvoiceException cabInvoiceException = Assert.Throws<CabInvoiceException>(() => invoicegeneratorNormalRide.TotalFareForSingleRide(rides));
            Assert.AreEqual(cabInvoiceException.type, CabInvoiceException.ExcepionType.Invalid_Distance);

        }

        // TC 5.3 
        [Test]
        public void Given_InvalidTime_ThrowsException()
        {
            Rides rides = new Rides(3, -6);
            CabInvoiceException cabInvoiceException = Assert.Throws<CabInvoiceException>(() => invoicegeneratorNormalRide.TotalFareForSingleRide(rides));
            Assert.AreEqual(cabInvoiceException.type, CabInvoiceException.ExcepionType.Invalid_Time);

        }

        // TC 5.4 

        [Test]
        public void Given_DistanceAndTime_CalculteFareForPremiumMultipleRide()
        {
            Rides rideOne = new Rides(6, 5);
            Rides rideTwo = new Rides(7, 6);
            List<Rides> rides = new List<Rides>();
            rides.Add(rideOne);
            rides.Add(rideTwo);

            Assert.AreEqual(217.0d, invoicegeneratorNormalRide.TotalFareForPremiumMultipleRide(rides));
        }
    }
}

    
