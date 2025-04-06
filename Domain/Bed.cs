
/**
 *
 * @author Oliver Aleksander Larsen | ollar22
 */
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Bed
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string id { get; set; }

    public int number { get; set; }
}
