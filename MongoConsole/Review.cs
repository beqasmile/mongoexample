using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoConsole
{
    public class Review
    {
        public string _id;
        public string _listing_url;
        public string summary;
        public string space;
        public string description;
    }
}
