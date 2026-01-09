using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddKeysMethods
{
    public class MumbaiTaxCalculator : ITaxCalculators
    {
        public int Calculate()
        {
            return 20;
        }
    }
}
