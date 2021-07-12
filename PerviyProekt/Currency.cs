using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerviyProekt
{
    class Currency
    {     
        public string StartDate { get; set; }
       
        public int CurrencyCode { get;  set; }

        public string CurrencyCodeL { get;  set; } 
        public int Units { get;  set; }
        public double Amount { get;  set; }

        public Currency(string StartDate,int CurrencyCode, string CurrencyCodeL, int Units, double Amount)
        {
            this.StartDate = StartDate;
            this.CurrencyCode = CurrencyCode;
            this.CurrencyCodeL = CurrencyCodeL;
            this.Units = Units;
            this.Amount = Amount;
        }

        public override string ToString()
        {
            return CurrencyCodeL + " " + Convert.ToString(Amount/Units);
        }

    }
}
