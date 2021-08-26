using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5Day4.Entities;
using Week5Day4.Interfaces;

namespace Week5Day4.ListRepository
{
    class ProductListRepository : IProductDbManager
    {
        static List<Product> products = new List<Product>();

        public static PcListRepository pcRepository = new PcListRepository();
        public static PhoneListRepository phoneRepository = new PhoneListRepository();
        public static TvListRepository tvRepository = new TvListRepository();

        public void Delete(Product t)
        {
            throw new NotImplementedException();
        }

        public List<Product> Fetch()
        {
            if (products.Count() > 0)
            {
                products.Clear();
            }

            products.AddRange(pcRepository.Fetch());
            products.AddRange(phoneRepository.Fetch());
            products.AddRange(tvRepository.Fetch());

            return products;
        }

        public Product GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Product t)
        {
            throw new NotImplementedException();
        }

        public void Update(Product t)
        {
            throw new NotImplementedException();
        }
    }
}
