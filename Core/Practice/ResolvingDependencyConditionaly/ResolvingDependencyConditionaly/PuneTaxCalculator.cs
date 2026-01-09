using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolvingDependencyConditionaly
{
    public class PuneTaxCalculator : ITaxCalculator
    {
        public int Calculate()
        {
            return 10;
        }
    }
}
