using System;
using System.Collections.Generic;

namespace AutoPark
{
    public class Comparator : IComparer<Vehicle>
    {
        public int Compare(Vehicle first, Vehicle second)
        {
            if (first.ModelName[0] > second.ModelName[0])
            {
                return 1;
            }
            
            return 0;
        }
    }
}