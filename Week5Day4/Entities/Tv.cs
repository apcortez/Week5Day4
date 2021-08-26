using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5Day4.Entities
{
    class Tv : Product
    {
        public int Inch { get; set; }

        public Tv() { }

        public Tv(string Brand, string Model, int Quantity, int Inch, int? Id)
            : base(Brand, Model, Quantity, Id)
        {
            this.Inch = Inch;
        }

        public override string Print()
        {
            return $"{base.Print()}, {Inch}";
        }
    }
}

