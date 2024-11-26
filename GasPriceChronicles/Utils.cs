using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasPriceChronicles
{
    internal class Utils
    {
        const int ROUND_BY_2 = 2;
        public static decimal RoundAtMid(decimal input)
        {
            return Math.Round(input, ROUND_BY_2, MidpointRounding.AwayFromZero);
        }
    }
}
