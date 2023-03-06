using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyskovrky_more_2
{
    internal class fullfield
    {
        public int x;
        public int y;

        public value val;

        public fullfield(int x, int y, value n) 
        {
            this.x = x;
            this.y = y;
            this.val = n;
        }
    }

    public enum value
    {
        X,
        Y
    }
}
