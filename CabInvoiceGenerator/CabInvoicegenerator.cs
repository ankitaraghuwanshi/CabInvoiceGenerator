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

        public Invoicegenerator()
        {
            this.pricePerKiloMeter = 10;
            this.pricePerMinute = 1;
            this.minimumFare = 5;
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
    }
}
