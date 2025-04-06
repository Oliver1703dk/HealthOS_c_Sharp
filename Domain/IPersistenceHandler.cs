
/**
 *
 * @author Oliver Aleksander Larsen | ollar22
 */
using System.Collections.Generic;

public interface IPersistenceHandler
{
    List<Employee> GetEmployees();
    Employee GetEmployee(string id);
    bool CreateEmployee(Employee employee);

    List<Patient> GetPatients();
    Patient GetPatient(string id);
    bool CreatePatient(Patient patient);

    List<Bed> GetBeds();
    Bed GetBed(string id);
    bool CreateBed(Bed bed);

    List<Admission> GetAdmissions();
    Admission GetAdmission(string id);
    bool CreateAdmission(Admission admission);
    bool DeleteAdmission(string id);
}

