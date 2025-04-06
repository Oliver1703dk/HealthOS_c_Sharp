
/**
 *
 * @author Oliver Aleksander Larsen | ollar22
 */
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Employee
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string id { get; set; }

    public string name { get; set; }
    public int phone { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string positionId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string departmentId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string roomId { get; set; }
}


