using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class Rides
    {
        public double distance;
        public double time;

        public Rides(double distnce, double time)
        {
            this.distance = distnce;
            this.time = time;
        }

    }
}