using System;

namespace Week5Day4
{
    internal class Menu
    {
        internal static void Start()
        {
            bool continuare = true;

            do
            {
                Console.WriteLine("Premi 1 per visualizzare tutti i prodotti");
                Console.WriteLine("Premi 2 per visualizzare tutti i cellulari");
                Console.WriteLine("Premi 3 per visualizzare tutti i pc");
                Console.WriteLine("Premi 4 per visualizzare tutte le tv");
                Console.WriteLine("Premi 5 per inserire un nuovo prodotto");
                Console.WriteLine("Premi 6 per eliminare un prodotto");
                Console.WriteLine("Premi 7 per modificare un prodotto");
                Console.WriteLine("Premi 8 per filtrare i cellulari per memoria");
                Console.WriteLine("Premi 9 per filtrare i pc per sistema operativo");
                Console.WriteLine("Premi 10 per filtrare le tv per dimensione");
                Console.WriteLine("Premi 0 per uscire");
                Console.WriteLine();
                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        ShopManager.ShowProducts();
                        break;
                    case "2":
                        ShopManager.ShowPhones();
                        break;
                    case "3":
                        ShopManager.ShowPcs();
                        break;
                    case "4":
                        ShopManager.ShowTvs();
                        break;
                    case "5":
                        ShopManager.InsertProduct();
                        break;
                    case "6":
                        ShopManager.DeleteProduct();
                        break;
                    case "7":
                        ShopManager.UpdateProduct();
                        break;
                    case "8":
                        ShopManager.FilterPhoneByMemory();
                        break;
                    case "9":
                        ShopManager.FilterPcByOs();
                        break;
                    case "10":
                        ShopManager.FilterTvByInch();
                        break;
                    case "0":
                        Console.WriteLine("Arrivederci! A presto");
                        continuare = false;
                        break;
                    default:
                        Console.WriteLine("Scelta sbagliata riprova");
                        break;
                }
            } while (continuare);
        }
    }
}
