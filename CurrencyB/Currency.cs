using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyB
{
    internal class Currency
    {
        public Guid Id { get; set; }
        public string Ccy { get; set; }
        public string Base_ccy { get; set; }
        public double Buy { get; set; }
        public double Sale { get; set; }
    }
}
