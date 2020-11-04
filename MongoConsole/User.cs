using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoConsole
{
    public class User
    {
        [BsonElement("Id")]
        public int Id { get; set; }

        [BsonElement("UserName")]
        public string UserName { get; set; }

        [BsonElement("UserFamily")]
        public string UserFamily { get; set; }

        [BsonElement("UserAddress")]
        public string UserAddress { get; set; }

    }
}
