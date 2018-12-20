using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diskr_maths
{
    class IndexComparer : IComparer<Hash>
    {
        public int Compare(Hash h1, Hash h2)
        {
            int a = h1.key;
            int b = h2.key;
            if (a > b)
            {
                return 1;
            }
            else if(a < b)
            {
                return -1;
            }
            return 0;
        }
    }
}
