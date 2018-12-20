using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diskr_maths
{
    class Hash
    {
        public int key { get; set; }
        public int value { get; set; }
        public Hash(int a, int b)
        {
            this.key = a;
            this.value = b;
        }
    }
}
