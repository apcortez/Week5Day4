using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5Day4.Entities;
using Week5Day4.Interfaces;

namespace Week5Day4.ListRepository
{
    class TvListRepository : ITvDbManager
    {
        public static List<Tv> tvs = new List<Tv>
        {
            new Tv("Sony", "MaxiSchermo", 100, 50, null),
            new Tv("Samsung", "1010134", 250, 42, null),
            new Tv("Samsung", "MaxiSchermo 100", 523, 100, null),
        };

        public void Delete(Tv tv)
        {
            tvs.Remove(tv);
        }

        public List<Tv> Fetch()
        {
            return tvs;
        }

        public List<Tv> FilterByInch(int inches)
        {
            return tvs.Where(t => t.Inch == inches).ToList();
        }

        public Tv GetById(int? id)
        {
            return tvs.Find(p => p.Id == id);
        }

        public void Insert(Tv tv)
        {
            tvs.Add(tv);
        }

        public void Update(Tv tv)
        {
            Delete(GetById(tv.Id));
            Insert(tv);
        }
    }
}
