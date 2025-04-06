
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

    public int positionId { get; set; }
    public int departmentId { get; set; }
    public int roomId { get; set; }
}

