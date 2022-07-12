using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
   static class Converter
    {
      public  static double Convert(Coin first, Coin second)
        {
            double result=
           (first.Value / first.Nominal)/ 
            (second.Value / second.Nominal);
            return result;
        }
    }
}
