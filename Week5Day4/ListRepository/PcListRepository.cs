using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5Day4.Entities;
using Week5Day4.Interfaces;

namespace Week5Day4.ListRepository
{
    class PcListRepository : IPcDbManager
    {
        public static List<Pc> pcs = new List<Pc>
        {
            new Pc("HP", "Notebook 1", 4, _OS.Windows, true, null),
            new Pc("ACER", "Aspire 4", 10, _OS.Linux, false, null),
            new Pc("Apple", "Macbook 2020", 100, _OS.Mac, false, null),
            new Pc("Dell", "Dell1019", 150, _OS.Linux, true, null)

        };


        public void Delete(Pc pc)
        {
            pcs.Remove(pc);
        }

        public List<Pc> Fetch()
        {
            return pcs;
        }

        public List<Pc> FilterByOS(_OS os)
        {
            return pcs.Where(o => o.OS == os).ToList();
        }

        public Pc GetById(int? id)
        {
            return pcs.Find(p => p.Id == id);
        }

        public void Insert(Pc pc)
        {
            pcs.Add(pc);
        }

        public void Update(Pc pc)
        {
            Delete(GetById(pc.Id));
            Insert(pc);
        }
    }
}
