/**
 *
 * @author Oliver Aleksander Larsen | ollar22
 */
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Patient
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string id { get; set; }

    public string name { get; set; }
    public int phone { get; set; }
    public int cprNumber { get; set; }
}

