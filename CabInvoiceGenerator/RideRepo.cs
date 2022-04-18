using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class RideRepo//uc4
    {
        public Dictionary<string, List<Rides>> rideRepo;

        public RideRepo()
        {
            rideRepo = new Dictionary<string, List<Rides>>();
        }
        public void AddRideRepo(string userid, Rides rides)
        {
            if (rideRepo.ContainsKey(userid))
            {
                rideRepo[userid].Add(rides);
               
            }
            else
            {
                rideRepo.Add(userid, new List<Rides>());
                rideRepo[userid].Add(rides);
            }
        }
        public List<Rides> returnListByUserId(string userid)
        {
            if (rideRepo.ContainsKey(userid))
            {
                return rideRepo[userid];
            }
            else
                throw new CabInvoiceException(CabInvoiceException.ExcepionType.Invaild_user_id, "invaid user id");

        }

    }
}
