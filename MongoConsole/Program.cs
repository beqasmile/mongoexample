using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            MongoClient dbClient = new MongoClient("mongodb+srv://XXX:XXXXXXXXX@cluster0.oyqyt.mongodb.net/sample_airbnb?retryWrites=true&w=majority");

            var dbList = dbClient.ListDatabases().ToList();

            Console.WriteLine("The list of databases on this server is: ");
            foreach (var db in dbList)
            {
                Console.WriteLine(db);
            }

            Console.ReadKey();
        }
    }
}
