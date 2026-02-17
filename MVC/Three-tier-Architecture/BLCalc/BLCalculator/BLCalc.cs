using System.Collections.Generic;
using System.Linq;
using DALCalculator;

namespace BALCalculator
{
    public class BalCalc
    {
        public List<string> ReverseNames()
        {
            DalCalc obj = new DalCalc();

            List<string> names = obj.GetNames();

            List<string> reversed = names.Select(name => new string(name.Reverse().ToArray())).ToList();
            return reversed;
        }
    }
}
