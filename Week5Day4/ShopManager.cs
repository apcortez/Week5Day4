using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5Day4.AdoRepository;
using Week5Day4.Entities;
using Week5Day4.ListRepository;

namespace Week5Day4
{
    class ShopManager
    {
        //public static ProductListRepository productRepository = new ProductListRepository();
        //public static PcListRepository pcRepository = new PcListRepository();
        //public static PhoneListRepository phoneRepository = new PhoneListRepository();
        //public static TvListRepository tvRepository = new TvListRepository();

        public static ProductSqlRepository productRepository = new ProductSqlRepository();
        public static PcSqlRepository pcRepository = new PcSqlRepository();
        public static PhoneSqlRepository phoneRepository = new PhoneSqlRepository();
        public static TvSqlRepository tvRepository = new TvSqlRepository();
        internal static void ShowProducts()
        {
            List<Product> products = productRepository.Fetch();
            foreach(var product in products)
            {
                Console.WriteLine(product.Print());
            }
        }

        internal static void ShowPhones()
        {
            List<Phone> phones = phoneRepository.Fetch();
            foreach(var phone in phones)
            {
                Console.WriteLine(phone.Print());
            }
        }

        internal static void ShowPcs()
        {
            List<Pc> pcs = pcRepository.Fetch();
            foreach(var pc in pcs)
            {
                Console.WriteLine(pc.Print());
            }
        }

        internal static void ShowTvs()
        {
            List<Tv> tvs = tvRepository.Fetch();
            foreach(var tv in tvs)
            {
                Console.WriteLine(tv.Print());
            }
        }

        internal static void InsertProduct()
        {
            int prodottoScelto;
            bool isInt;

            do
            {
                Console.WriteLine("Che prodotto vuoi inserire?");
                Console.WriteLine("Premi 1 per inserire un cellulare ");
                Console.WriteLine("Premi 2 per inserire un pc");
                Console.WriteLine("Premi 3 per inserire una tv ");

                isInt = int.TryParse(Console.ReadLine(), out prodottoScelto);

            } while (!isInt || prodottoScelto <= 0 || prodottoScelto >= 4);

            switch (prodottoScelto)
            {
                case 1:
                    Phone phone = ChiediDatiCellulare();
                    phoneRepository.Insert(phone);
                    break;
                case 2:
                    Pc pc = ChiediDatiPc();
                    pcRepository.Insert(pc);
                    break;
                case 3:
                    Tv tv  = ChiediDatiTv();
                    tvRepository.Insert(tv);
                    break;
            }
        }

        internal static void UpdateProduct()
        {
            int prodottoScelto;
            bool isInt;

            do
            {
                Console.WriteLine("Che prodotto vuoi modificare?");
                Console.WriteLine("Premi 1 per modificare un cellulare ");
                Console.WriteLine("Premi 2 per modificare un pc");
                Console.WriteLine("Premi 3 per modificare una tv ");

                isInt = int.TryParse(Console.ReadLine(), out prodottoScelto);

            } while (!isInt || prodottoScelto <= 0 || prodottoScelto >= 4);

            switch (prodottoScelto)
            {
                case 1:
                    UpdateCellulare();
                    break;
                case 2:
                    UpdatePc();
                    break;
                case 3:
                    UpdateTv();
                    break;
            }
        }

        private static void UpdateTv()
        {
            Tv tv = ScegliTv();
            Tv tvUpdated = ChiediDatiTv();
            tvUpdated.Id = tv.Id;
            tvRepository.Update(tvUpdated);
        }

        private static void UpdatePc()
        {
            Pc pc = ScegliPc();
            Pc pcUpdated = ChiediDatiPc();
            pcUpdated.Id = pc.Id;
            pcRepository.Update(pcUpdated);
        }

        private static void UpdateCellulare()
        {
            Phone phone = ScegliCellulare();
            Phone phoneUpdated = ChiediDatiCellulare();
            phoneUpdated.Id = phone.Id;
            phoneRepository.Update(phoneUpdated);
        }

        private static Tv ChiediDatiTv()
        {
            Product product = ChiediDatiProdotto();
            Tv tv = new Tv();
            tv.Brand = product.Brand;
            tv.Model = product.Model;
            tv.Quantity = product.Quantity;

            int pollici;
            bool isInt;

            do
            {
                Console.WriteLine("Inserisci la dimensione della tv in pollici: ");
                isInt = int.TryParse(Console.ReadLine(), out pollici);
            } while (!isInt);

            tv.Inch = pollici;
            return tv;
        }

        private static Pc ChiediDatiPc()
        {
            Product product = ChiediDatiProdotto();
            Pc pc = new Pc();
            pc.Brand = product.Brand;
            pc.Model = product.Model;
            pc.Quantity = product.Quantity;

            int sistemaoperativo;
            bool isInt, touchscreen;

            do
            {
                Console.WriteLine("Scegli un sistema operativo: ");
                foreach (var os in Enum.GetValues(typeof(_OS)))
                {
                    Console.WriteLine($"Premi {(int)os + 1} per {(_OS)os}");
                }
                isInt = int.TryParse(Console.ReadLine(), out sistemaoperativo);

            } while (!isInt || sistemaoperativo <= 0 || sistemaoperativo >= 4);

            pc.OS = (_OS)(sistemaoperativo- 1);

            
           
            Console.WriteLine("Il pc è touchscreen? Scegli true/false");
            pc.IsTouchScreen = bool.Parse(Console.ReadLine());

            return pc;
        }

        private static Phone ChiediDatiCellulare()
        {
            Product product = ChiediDatiProdotto();
            Phone phone = new Phone();
            phone.Brand = product.Brand;
            phone.Model = product.Model;
            phone.Quantity = product.Quantity;
            
            int memory;
            bool isInt;

            do {
                Console.WriteLine("Inserisci la memoria del cellulare in GB: ");
                isInt = int.TryParse(Console.ReadLine(), out memory);
            } while (!isInt);

            phone.Memory = memory;
            return phone;
        }

        private static Product ChiediDatiProdotto()
        {
           Product product = new Product();
            int quantity;
            bool isInt;

            Console.WriteLine("Inserisci la marca: ");
            product.Brand = Console.ReadLine();

            Console.WriteLine("Inserisci il modello: ");
            product.Model = Console.ReadLine();


            do
            {
                Console.WriteLine("Inserisci la quantità disponibile1: ");
                isInt = int.TryParse(Console.ReadLine(), out quantity);
            } while (!isInt);

            product.Quantity = quantity;

            return product;
        }

        internal static void DeleteProduct()
        {
            int tipoProdotto;
            bool isInt;

            do
            {
                Console.WriteLine("Che prodotto vuoi eliminare?");
                Console.WriteLine("Premi 1 per eliminare un cellulare");
                Console.WriteLine("Premi 2 per eliminare un pc");
                Console.WriteLine("Premi 3 per eliminare una tv");

                isInt = int.TryParse(Console.ReadLine(), out tipoProdotto);

            } while (!isInt || tipoProdotto <= 0 || tipoProdotto >= 4);

            switch (tipoProdotto)
            {
                case 1:
                    Phone phone = ScegliCellulare();
                    phoneRepository.Delete(phone);
                    break;
                case 2:
                    Pc pc = ScegliPc();
                    pcRepository.Delete(pc);
                    break;
                case 3:
                    Tv tv = ScegliTv();
                    tvRepository.Delete(tv);
                    break;
            }
        }

        private static Tv ScegliTv()
        {
            List<Tv> tvs = tvRepository.Fetch();

            int i = 1;

            foreach (var tv in tvs)
            {
                Console.WriteLine($"Premi {i} per scegliere {tv.Print()}");
                i++;
            }

            bool isInt;
            int tvScelto;
            do
            {
                Console.WriteLine("Quale tv vuoi scegliere?");

                isInt = int.TryParse(Console.ReadLine(), out tvScelto);

            } while (!isInt || tvScelto <= 0 || tvScelto > tvs.Count);

            return tvs.ElementAt(tvScelto - 1);
        }

        private static Pc ScegliPc()
        {

            List<Pc> pcs = pcRepository.Fetch();

            int i = 1;

            foreach (var pc in pcs)
            {
                Console.WriteLine($"Premi {i} per scegliere {pc.Print()}");
                i++;
            }

            bool isInt;
            int pcScelto;
            do
            {
                Console.WriteLine("Quale pc vuoi scegliere?");

                isInt = int.TryParse(Console.ReadLine(), out pcScelto);

            } while (!isInt || pcScelto <= 0 || pcScelto > pcs.Count);

            return pcs.ElementAt(pcScelto - 1);
        }

        private static Phone ScegliCellulare()
        {
            List<Phone> phones = phoneRepository.Fetch();

            int i = 1;

            foreach (var phone in phones)
            {
                Console.WriteLine($"Premi {i} per scegliere {phone.Print()}");
                i++;
            }

            bool isInt;
            int cellulareScelto;
            do
            {
                Console.WriteLine("Quale cellulare vuoi scegliere?");

                isInt = int.TryParse(Console.ReadLine(), out cellulareScelto);

            } while (!isInt || cellulareScelto <= 0 || cellulareScelto > phones.Count);

            return phones.ElementAt(cellulareScelto - 1);
        }

        internal static void FilterPhoneByMemory()
        {
            int memory;
            bool isInt;
            do
            {
                Console.WriteLine("Inserisci la memoria da filtrare: ");
                isInt = int.TryParse(Console.ReadLine(), out memory);
            } while (!isInt);

        List<Phone> phones = phoneRepository.FilterByMemory(memory);
            foreach (var phone in phones)
            {
                Console.WriteLine(phone.Print());
            }
        }

        internal static void FilterPcByOs()
        {
            int sistemaoperativo;
            bool isInt;
            do
            {
                Console.WriteLine("Scegli un sistema operativo da filtrare: ");
                foreach (var os in Enum.GetValues(typeof(_OS)))
                {
                    Console.WriteLine($"Premi {(int)os + 1} per {(_OS)os}");
                }
                isInt = int.TryParse(Console.ReadLine(), out sistemaoperativo);

            } while (!isInt || sistemaoperativo <= 0 || sistemaoperativo >= 4);

            List<Pc> pcs = pcRepository.FilterByOS((_OS)(sistemaoperativo - 1));
            foreach (var pc in pcs)
            {
                Console.WriteLine(pc.Print());
            }
        }

        internal static void FilterTvByInch()
        {
            int pollici;
            bool isInt;
            do
            {
                Console.WriteLine("Inserisci la dimensione in pollici da filtrare: ");
                isInt = int.TryParse(Console.ReadLine(), out pollici);
            } while (!isInt);

            List<Tv> tvs = tvRepository.FilterByInch(pollici);
            foreach (var tv in tvs)
            {
                Console.WriteLine(tv.Print());
            }
        }
    }
}
