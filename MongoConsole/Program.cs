using MongoDB.Bson;
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

            MongoClient dbClient = new MongoClient("mongodb+srv://ilya:Ia1234567890@cluster0.oyqyt.mongodb.net/sample_airbnb?retryWrites=true&w=majority");

            var dbList = dbClient.ListDatabases().ToList();

            Console.WriteLine("The list of databases on this server is: ");

            var database = dbClient.GetDatabase("sample_training");
            var collection = database.GetCollection<BsonDocument>("grades");

            var document = new BsonDocument { { "student_id", 10000 }, {
                "scores",
                new BsonArray {
                new BsonDocument { { "type", "examilya" }, { "score", 88.12334193287023 } },
                new BsonDocument { { "type", "quizily" }, { "score", 74.92381029342834 } },
                new BsonDocument { { "type", "homework" }, { "score", 89.97929384290324 } },
                new BsonDocument { { "type", "homework" }, { "score", 82.12931030513218 } }
                }
                }, { "class_id", 480 }
        };

            collection.InsertOne(document);


            var firstDocument = collection.Find(new BsonDocument()).FirstOrDefault();
            Console.WriteLine(firstDocument.ToString());



            //foreach (var db in dbList)
            //{
            //    var dbName =db.GetElement("name");
            //    var database1 = dbClient.GetDatabase(dbName.ToString());

            //    var collection1 = database.GetCollection<Review>("listingsAndReviews");

            //    var filterDef = new FilterDefinitionBuilder<Review>();
            //    var filter = filterDef.In(x => x._id, new[] { "10006546", "10009999" });
            //    //var reviewList = collection.Find(filter).ToList();

            //    var empList = collection1.Find(filter).ToList();

            //   // var firstDocument = collection1.Find(new BsonDocument()).FirstOrDefault();
            //    Console.WriteLine(firstDocument.ToString());

            //    Console.WriteLine(db);
            //}

            Console.ReadKey();
        }
    }
}
