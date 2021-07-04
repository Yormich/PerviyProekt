using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerviyProekt
{
    class Currency
    {               
        public int CurrencyCode { get; private set; }
        public string CurrencyCodeL { get; private set; } 
        public int Units { get; private set; }
        public double Amount { get; private set; }

        public Currency(int CurrencyCode, string CurrencyCodeL, int Units, double Amount)
        {                
            this.CurrencyCode = CurrencyCode;
            this.CurrencyCodeL = CurrencyCodeL;
            this.Units = Units;
            this.Amount = Amount;
        }

        public override string ToString()
        {
            return CurrencyCodeL;
        }

    }
}
