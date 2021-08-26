using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5Day4.Entities
{
    class Phone : Product
    {
        public int Memory { get; set; }

        public Phone() { }
        
        public Phone(string Brand, string Model, int Quantity,  int Memory,int? Id)
            :base(Brand, Model, Quantity, Id)
        {
            this.Memory = Memory;
        }

        public override string Print()
        {
            return $"{base.Print()}, {Memory}";
        }
    }
}
