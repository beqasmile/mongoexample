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


            var databaseTest1 = dbClient.GetDatabase("test1");


            List<User> dictUsers = new List<User>();
            for (int i = 2; i < 12; i++)
            {
                var newDocument = new User { Id = i, UserAddress = "Street num " + i, UserFamily = "UserFamily_" + i, UserName = "UserName_" + i };
                dictUsers.Add(newDocument);

            }

            var userCollection = databaseTest1.GetCollection<User>("userCollection");
            userCollection.InsertMany(dictUsers);




            var collectionTest1 = databaseTest1.GetCollection<BsonDocument>("test1collection");
            var documentTest = new BsonDocument { { "user_id", 1 }, { "user_name", "moshe" }, { "user_family", "barnov" },{ "address", "jerusalem st 22" } };
            collectionTest1.InsertOne(documentTest);

            List<BsonDocument> dict = new List<BsonDocument>();

            for (int i=2; i<12; i++)
            {
                var newDocument = new BsonDocument { { "user_id", i }, { "user_name", "user_" + i }, { "user_family", "family_" + i }, { "address", "jerusalem st 22" } };
                dict.Add(newDocument);

            }
            collectionTest1.InsertMany(dict);


          

            Console.WriteLine("The list of databases on this server is: ");

            FieldDefinition<BsonDocument> fieldDefinition = "user_id";
            FilterDefinition<BsonValue> fiterDefinition = new BsonDocument( "$gte", 0 );



            var userBiggerFilter = Builders<BsonDocument>.Filter.Eq("user_id", 3);
                                     //fieldDefinition, fiterDefinition);


            var filteredTempList = collectionTest1.Find(userBiggerFilter).ToList();
            foreach (BsonDocument x in filteredTempList)
            {
                Console.WriteLine(x.ToString());
            }



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

            // printing the first row in the list
            var firstDocument = collection.Find(new BsonDocument()).FirstOrDefault();
            Console.WriteLine(firstDocument.ToString());
            
            
            // select all data (very slow)

            //var allDocumentList = collection.Find(new BsonDocument()).ToList();
            //foreach (BsonDocument x in allDocumentList)
            //{
            //    Console.WriteLine(x.ToString());
            //}


            var highExamScoreFilter = Builders<BsonDocument>.Filter.ElemMatch<BsonValue>(
                                     "scores", new BsonDocument { { "type", "exam" },
                                        { "score", new BsonDocument { { "$gte", 95 } } }
                                     });

            var sort = Builders<BsonDocument>.Sort.Descending("student_id");

            var filteredList = collection.Find(highExamScoreFilter).Sort(sort).ToList();
            foreach (BsonDocument x in filteredList)
            {
                Console.WriteLine(x.ToString());
            }


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
