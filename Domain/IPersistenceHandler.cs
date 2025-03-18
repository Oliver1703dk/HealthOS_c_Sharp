using System.Collections.Generic;

/**
 *
 * @author Oliver Aleksander Larsen | ollar22
 */

namespace HealthOS.Domain
{
    public interface IPersistenceHandler
    {
        List<Employee> GetEmployees();
        Employee GetEmployee(int id);
        bool CreateEmployee(Employee employee);
        List<Patient> GetPatients();
        Patient GetPatient(int id);
        bool CreatePatient(Patient patient);
        List<Bed> GetBeds();
        Bed GetBed(int id);
        bool CreateBed(Bed bed);
        List<Admission> GetAdmissions();
        Admission GetAdmission(int id);
        bool CreateAdmission(Admission admission);
        bool DeleteAdmission(int id);
    }
}
