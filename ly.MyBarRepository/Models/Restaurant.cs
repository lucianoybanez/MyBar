using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ly.MyBarRepository.Models
{
    public class Restaurant
    {
        [BsonElement("restaurant_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public Address address { get; set; }
        public string borough { get; set; }
        public string cuisine { get; set; }
        public List<Grade> grades { get; set; }
        public string name { get; set; }
    }

    public class Date
    {
        public object date { get; set; }
    }
}

