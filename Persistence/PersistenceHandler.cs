
/**
 *
 * @author Oliver Aleksander Larsen | ollar22
 */
using MongoDB.Driver;
using System.Collections.Generic;

public class PersistenceHandler : IPersistenceHandler
{
    private readonly IMongoDatabase _database;

    public PersistenceHandler()
    {
        var client = new MongoClient("mongodb://localhost:27017");
        _database = client.GetDatabase("dm_09");
    }

    public List<Employee> GetEmployees() =>
        _database.GetCollection<Employee>("employees").Find(_ => true).ToList();

    public Employee GetEmployee(string id) =>
        _database.GetCollection<Employee>("employees").Find(e => e.id == id).FirstOrDefault();

    public bool CreateEmployee(Employee employee)
    {
        _database.GetCollection<Employee>("employees").InsertOne(employee);
        return true;
    }

    public List<Patient> GetPatients() =>
        _database.GetCollection<Patient>("patients").Find(_ => true).ToList();

    public Patient GetPatient(string id) =>
        _database.GetCollection<Patient>("patients").Find(p => p.id == id).FirstOrDefault();

    public bool CreatePatient(Patient patient)
    {
        _database.GetCollection<Patient>("patients").InsertOne(patient);
        return true;
    }

    public List<Bed> GetBeds() =>
        _database.GetCollection<Bed>("beds").Find(_ => true).ToList();

    public Bed GetBed(string id) =>
        _database.GetCollection<Bed>("beds").Find(b => b.id == id).FirstOrDefault();

    public bool CreateBed(Bed bed)
    {
        _database.GetCollection<Bed>("beds").InsertOne(bed);
        return true;
    }

    public List<Admission> GetAdmissions() =>
        _database.GetCollection<Admission>("admissions").Find(_ => true).ToList();

    public Admission GetAdmission(string id) =>
        _database.GetCollection<Admission>("admissions").Find(a => a.id == id).FirstOrDefault();

    public bool CreateAdmission(Admission admission)
    {
        _database.GetCollection<Admission>("admissions").InsertOne(admission);
        return true;
    }

    public bool DeleteAdmission(string id)
    {
        _database.GetCollection<Admission>("admissions").DeleteOne(a => a.id == id);
        return true;
    }
}

