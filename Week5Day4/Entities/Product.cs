using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5Day4.Entities
{
    class Product
    {
        public string Brand { get; set; }
        public string Model { get; set; }

        public int Quantity { get; set; }

        public int? Id { get; set; }
        public Product()
        {

        }

        public Product(string Brand, string Model, int Quantity, int? Id)
        {
            this.Brand = Brand;
            this.Model = Model;
            this.Quantity = Quantity;
            this.Id = Id;
        }

        public virtual string Print()
        {
            return $"{Brand}, {Model}, {Quantity}";
        }
    }
}
