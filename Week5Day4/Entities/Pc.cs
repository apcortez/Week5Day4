using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5Day4.Entities
{
    class Pc: Product
    {
        public _OS OS { get; set; }
        public bool IsTouchScreen { get; set; }

        public Pc() { }

        public Pc(string Brand, string Model, int Quantity,  _OS OS, bool IsTouchScreen, int? Id)
            : base(Brand, Model, Quantity, Id)
        {
            this.OS = OS;
            this.IsTouchScreen = IsTouchScreen;
        }

        public override string Print()
        {
            return $"{base.Print()}, {OS}, {IsTouchScreen}";
        }
    }
    enum _OS
    {
        Windows,
        Mac,
        Linux
    }
}