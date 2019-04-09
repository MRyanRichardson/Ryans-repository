using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Models.Responses
{
    public class Response
    {   //Account lookup
        //Withdraw
        //Deposit
        // All of these will use a couple fields so we need to use inheritance

            public bool Success { get; set; }
            public string Message { get; set; }
      
    }
}
