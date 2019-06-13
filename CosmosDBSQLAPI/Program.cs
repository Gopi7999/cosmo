using CosmosDBSQLAPI.Helpers;
using CosmosDBSQLAPI.Models;
using System;

namespace CosmosDBSQLAPI
{
    class Program
    {
        public static string documentUri = "https://gopi-cosmo.documents.azure.com:443/";
        public static string documentKey = "zmEAtuxuSMftDfrbzEBIEHM2Fzqrfkahlf1TsvdQYmkdziD8yxpY5yQtjfVyMat26BuYjpL3ugBeC6rxAuByoQ==";
        static void Main(string[] args)
        {
            CosmosDBHelper dbHelper = new CosmosDBHelper(documentUri, documentKey, "ecar", "cars");
            var car = new Cars()
            {
                Name = "Polo",
                Category="Volkswogan",
                Fuel="Diesel",
                Price=1200000
            };

            //var response = dbHelper.InsertDocumentAsync(car).GetAwaiter().GetResult();
            Console.WriteLine("Hello World!");
            var carcoll = dbHelper.GetCars();
            foreach(var c in carcoll)
            {
                Console.WriteLine("{0,-20} {1,-10} {2,-10} {3,-10}", c.Name, c.Price, c.Category, c.Fuel);
            }
            Console.ReadLine();
        }
    }
}
