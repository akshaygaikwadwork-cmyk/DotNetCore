using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolvingDependencyConditionaly
{
    public class MumbaiTaxCalculator : ITaxCalculator
    {
        public int Calculate()
        {
            return 20;
        }
    }
}
