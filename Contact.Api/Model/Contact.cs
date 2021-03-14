using MongoDB.Bson.Serialization.Attributes;

namespace Contact.Api.Model
{
    public class Contact
    { 
        [BsonId] 
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string UUID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public ContactInfo ContactInfo { get; set; }
       
    }
}
