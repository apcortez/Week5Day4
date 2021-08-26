using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5Day4.Entities;
using Week5Day4.Interfaces;

namespace Week5Day4.AdoRepository
{
    class ProductSqlRepository : IProductDbManager
    {
        public static PcSqlRepository pcRepository = new PcSqlRepository();
        public static PhoneSqlRepository phoneRepository = new PhoneSqlRepository();
        public static TvSqlRepository tvRepository = new TvSqlRepository();

        public void Delete(Product t)
        {
            throw new NotImplementedException();
        }

        public List<Product> Fetch()
        {
            List<Product> products = new List<Product>();

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
