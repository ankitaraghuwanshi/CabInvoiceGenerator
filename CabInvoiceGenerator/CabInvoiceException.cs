using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class CabInvoiceException : Exception
    {
        public ExcepionType type;

        public enum ExcepionType
        {
          Invalid_Distance,
          Invalid_Time,
          Invalid_Totalfare,
          Invaild_user_id,
        }
      public CabInvoiceException(ExcepionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
