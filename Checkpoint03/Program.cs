using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inheritance
{
    //Declare the parent class
    class Device
    {
        public string Type { get; set; }
        public string Brand { get; set; }
        public string ModelName { get; set; }
        public string Country { get; set; }


    }
    //Declare the sub class with parameters and constructors
    class Detail : Device
    {
        public Detail(string type, string brand, string modelname, string country)
        {
            Type = type;
            Brand = brand;
            ModelName = modelname;
            Country = country;

        }

        public Detail(string type, string brand, string modelname, string country, DateTime purchasedate, int cost, string currency, int price)
        {
            Type = type;
            Brand = brand;
            ModelName = modelname;
            Country = country;
            PurchaseDate = purchasedate;
            Cost = cost;
            Price = price;
            Currency = currency;

        }

        public DateTime PurchaseDate { get; set; }
        public int Price { get; set; }
        public string Currency { get; set; }
        public int Cost { get; set; }


    }
    class Program
    {
        static void Main(string[] args)
        {
            string Pcurrency = "usd";
            int Pprice = 1;
            Console.WriteLine("---------Asset Tracking------------");
            List<Detail> content = new List<Detail>();
            int count = 1;
            // Receive the input details type, brand, modelname,country, Date of purchase, price
            while (true)
            {
                Console.WriteLine("------Adding " + count + " value----------");
                Console.Write("Enter the type:");
                string Ptype = Console.ReadLine();
                if (Ptype.ToLower().Trim() == "q")
                {
                    break;
                }
                Console.Write("Enter the brand:");
                string Pbrand = Console.ReadLine();
                if (Pbrand.ToLower().Trim() == "q")
                {
                    break;
                }
                Console.Write("Enter the model:");
                string Pmodel = Console.ReadLine();
                if (Pmodel.ToLower().Trim() == "q")
                {
                    break;
                }
                Console.Write("Enter the Country:");
                string Pcountry = Console.ReadLine();
                if (Pmodel.ToLower().Trim() == "q")
                {
                    break;
                }

                Console.Write("Enter the Date of purchase(YYYY-MM-DD):");
                var dt = Console.ReadLine();
                DateTime DOP = Convert.ToDateTime(dt);
                if (dt.ToLower().Trim() == "q")
                {
                    break;
                }
                Console.Write("Enter the Price:");
                int Pcost = Convert.ToInt32(Console.ReadLine());
                var money = Pcost.ToString();
                if (money == "q")
                {
                    break;
                }
                else if (Pcountry == "USA")
                {
                    Pprice = Pcost;
                    Pcurrency = "USD";
                }
                else if (Pcountry == "Sweden")
                {
                    Pprice = Pcost * 10;
                    Pcurrency = "Sek";
                }
                else if (Pcountry == "India")
                {
                    Pprice = Pcost * 79;
                    Pcurrency = "INR";
                }
                //Add the details to the List
                Detail paper = new Detail(Ptype, Pbrand, Pmodel, Pcountry, DOP, Pcost, Pcurrency, Pprice);
                content.Add(paper);
                count++;
            }
            //Sort the list based on Country
            List<Detail> SortedList = content.OrderBy(paper => paper.Country).ToList();
            Console.WriteLine("The sorted List based on Country");
            Console.WriteLine("Type".PadRight(10) + "Brand".PadRight(10) + "Modelname".PadRight(10) + "DateOfPurchase".PadRight(20) + "Country".PadRight(10) + "Price in USD".PadRight(20) + "Currency".PadRight(10) + "Price in Local Currency");
            foreach (Detail paper in SortedList)
            {

                Console.WriteLine(paper.Type.PadRight(10) + paper.Brand.PadRight(10) + paper.ModelName.PadRight(10) + (paper.PurchaseDate.ToShortDateString()).PadRight(10) + paper.Country.PadRight(10).PadLeft(20) + paper.Cost + paper.Currency.PadRight(10).PadLeft(30) + paper.Price);
            }

            //Sort the list based on Purchase Date
            List<Detail> SortedDate = content.OrderBy(paper => paper.PurchaseDate).ToList();
            Console.WriteLine("The Sorted list based of Purchase Date.");
            Console.WriteLine("Type".PadRight(10) + "Brand".PadRight(10) + "Modelname".PadRight(10) + "DateOfPurchase".PadRight(20) + "Country".PadRight(10) + "Price in USD".PadRight(10) + "Currency".PadRight(10) + "Price in Local Currency");
            foreach (Detail paper in SortedDate)
            {

                Console.WriteLine(paper.Type.PadRight(10) + paper.Brand.PadRight(10) + paper.ModelName.PadRight(10) + (paper.PurchaseDate.ToShortDateString()).PadRight(10) + paper.Country.PadRight(10).PadLeft(20) + paper.Cost + paper.Currency.PadRight(10).PadLeft(30) + paper.Price);
            }

            //Highlight the details with red for 3 months to due and with yellow for 6 months to due.
            Console.WriteLine("Highlighted with Red which has 3 months for 3 years and with Yellow for 6 months for 3 Years.");
            Console.WriteLine("Type".PadRight(10) + "Brand".PadRight(10) + "Modelname".PadRight(10) + "DateOfPurchase".PadRight(20) + "Country".PadRight(10) + "Price in USD".PadRight(20) + "Currency".PadRight(10) + "Price in Local Currency");
            foreach (Detail paper in SortedDate)
            {
                if (DateTime.Now.AddMonths(-33) >= paper.PurchaseDate)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (DateTime.Now.AddMonths(-30) >= paper.PurchaseDate)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine(paper.Type.PadRight(10) + paper.Brand.PadRight(10) + paper.ModelName.PadRight(10) + (paper.PurchaseDate.ToShortDateString()).PadRight(10) + paper.Country.PadRight(10).PadLeft(20) + paper.Cost + paper.Currency.PadRight(10).PadLeft(30) + paper.Price);
                Console.ResetColor();
            }
        }
    }
}

