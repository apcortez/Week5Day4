using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5Day4.Entities;
using Week5Day4.Interfaces;

namespace Week5Day4.ListRepository
{
    class PhoneListRepository : IphoneDbManager
    {
        public static List<Phone> phones = new List<Phone> 
        {
            new Phone("Apple", "Iphone 11 Pro Max", 300, 256, null),
            new Phone("Apple", "Iphone 12 Mini", 500, 128, null),
            new Phone("Apple", "Iphone 12 Pro Max", 150, 512, null),
            new Phone("Samsung", "Flip 1", 350, 256, null),
            new Phone("Samsung", "Note 10", 556, 512, null),
            new Phone("Xiaomi", "Mi 11", 67, 256, null),
            new Phone("Xiaomi", "MI 11 Pro", 113, 512, null)
        };
        public void Delete(Phone phone)
        {
            phones.Remove(phone);
        }

        public List<Phone> Fetch()
        {
            return phones;
        }

        public List<Phone> FilterByMemory(int memory)
        {
            return phones.Where(p => p.Memory > memory).ToList();
        }

        public Phone GetById(int? id)
        {
            return phones.Find(p => p.Id == id);
        }

        public void Insert(Phone phone)
        {
            phones.Add(phone);
        }

        public void Update(Phone phone)
        {
            Delete(GetById(phone.Id));
            Insert(phone);
        }
    }
}
