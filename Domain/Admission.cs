
/**
 *
 * @author Oliver Aleksander Larsen | ollar22
 */
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Admission
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string id { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string patientId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string roomId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string bedId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string assignedEmployeeId { get; set; }
}
