using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class Invoicegenerator
    {
        readonly int pricePerKiloMeter;
        readonly int pricePerMinute;
        readonly int minimumFare;
        public double totalFare;

        public int numberOfRides;
        public double averagePerRide;
        readonly int premiumPricePerKm;//uc5
        readonly int premiumPricePerMin;
        readonly int premiumMinimumFare;


        public Invoicegenerator()
        {
            this.pricePerKiloMeter = 10;
            this.pricePerMinute = 1;
            this.minimumFare = 5;
            this.premiumPricePerKm = 15;//uc5
            this.premiumPricePerMin = 2;
            this.premiumMinimumFare = 20;
        }
        public double TotalFareForSingleRide(Rides rides)
        {
            if (rides.distance < 0)
            {
                throw new CabInvoiceException(CabInvoiceException.ExcepionType.Invalid_Distance, "Invaid Distance");
            }
            if (rides.time < 0)
            {
                throw new CabInvoiceException(CabInvoiceException.ExcepionType.Invalid_Time, "Invaid Time");
            }
            return Math.Max(minimumFare, rides.distance * pricePerKiloMeter + rides.time * pricePerMinute);
        }
        public double TotalFareForMltipleRide(List<Rides> multirides)//uc2
        {
            foreach (Rides rides in multirides)
            {
                totalFare += TotalFareForSingleRide(rides);


            }
            return totalFare;
        }
        public double InhancedInvoice(List<Rides> multirides)//uc3
        {
            foreach (Rides rides in multirides)
            {
                totalFare += TotalFareForSingleRide(rides);
                numberOfRides += 1;

            }
            averagePerRide = totalFare / numberOfRides;
            return totalFare;
        }
        public double TotalFareForPremiumSingleRide(Rides rides)
        {
            if (rides.distance < 0)
            {
                throw new CabInvoiceException(CabInvoiceException.ExcepionType.Invalid_Distance, "Invalid Distance");
            }
            if (rides.time < 0)
            {
                throw new CabInvoiceException(CabInvoiceException.ExcepionType.Invalid_Time, "Invaid Time");
            }
            return Math.Max(premiumMinimumFare, rides.distance * premiumPricePerKm + rides.time * premiumPricePerMin);
        }
        public double TotalFareForPremiumMultipleRide(List<Rides> multiride)
        {
            foreach (Rides ride in multiride)
            {
                totalFare += TotalFareForPremiumSingleRide(ride);
                numberOfRides += 1;
            }
            averagePerRide = totalFare / numberOfRides;
            return totalFare;
        }
    }
}
