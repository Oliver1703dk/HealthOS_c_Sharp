
/**
 *
 * @author Oliver Aleksander Larsen | ollar22
 */
using System;
using MongoDB.Bson;
// using HealthOS.Domain;
// using HealthOS.Persistence;

namespace HealthOS.Presentation
{
    public class MainApp
    {
        public static void Run()
        {
            Console.WriteLine(
                "------------------------------------------\n" +
                "WELCOME TO HealthOS (.NET + MongoDB)\n" +
                "Please input your command or type \"help\"\n" +
                "------------------------------------------\n"
            );

            bool running = true;
            IPersistenceHandler persistenceHandler = new PersistenceHandler();

            while (running)
            {
                Console.Write("> ");
                string command = Console.ReadLine()?.Trim().ToLower();

                switch (command)
                {
                    case "getemployees":
                        persistenceHandler.GetEmployees().ForEach(e => Console.WriteLine(e.ToBsonDocument()));
                        break;

                    case "getemployee":
                        Console.Write("Enter employee ID: ");
                        Console.WriteLine(persistenceHandler.GetEmployee(Console.ReadLine()).ToBsonDocument());
                        break;

                    case "createemployee":
                        CreateEmployee(persistenceHandler);
                        break;

                    case "getpatients":
                        persistenceHandler.GetPatients().ForEach(p => Console.WriteLine(p.ToBsonDocument()));
                        break;

                    case "getpatient":
                        Console.Write("Enter patient ID: ");
                        Console.WriteLine(persistenceHandler.GetPatient(Console.ReadLine()).ToBsonDocument());
                        break;

                    case "createpatient":
                        CreatePatient(persistenceHandler);
                        break;

                    case "getbeds":
                        persistenceHandler.GetBeds().ForEach(b => Console.WriteLine(b.ToBsonDocument()));
                        break;

                    case "getbed":
                        Console.Write("Enter bed ID: ");
                        Console.WriteLine(persistenceHandler.GetBed(Console.ReadLine()).ToBsonDocument());
                        break;

                    case "createbed":
                        CreateBed(persistenceHandler);
                        break;

                    case "getadmissions":
                        persistenceHandler.GetAdmissions().ForEach(a => Console.WriteLine(a.ToBsonDocument()));
                        break;

                    case "getadmission":
                        Console.Write("Enter admission ID: ");
                        Console.WriteLine(persistenceHandler.GetAdmission(Console.ReadLine()).ToBsonDocument());
                        break;

                    case "createadmission":
                        CreateAdmission(persistenceHandler);
                        break;

                    case "deleteadmission":
                        Console.Write("Enter admission ID to delete: ");
                        Console.WriteLine(persistenceHandler.DeleteAdmission(Console.ReadLine())
                            ? "Admission deleted successfully."
                            : "Admission deletion failed.");
                        break;

                    case "exit":
                        running = false;
                        break;

                    case "help":
                    default:
                        Console.WriteLine(GenerateHelpString());
                        break;
                }
            }
        }

        private static string GenerateHelpString()
        {
            return "Available commands:\n" +
                   "- getEmployees\n" +
                   "- getEmployee\n" +
                   "- createEmployee\n" +
                   "- getPatients\n" +
                   "- getPatient\n" +
                   "- createPatient\n" +
                   "- getBeds\n" +
                   "- getBed\n" +
                   "- createBed\n" +
                   "- getAdmissions\n" +
                   "- getAdmission\n" +
                   "- createAdmission\n" +
                   "- deleteAdmission\n" +
                   "- exit\n";
        }

        private static void CreateEmployee(IPersistenceHandler persistenceHandler)
        {
            Console.Write("Enter employee name: ");
            string name = Console.ReadLine();

            int phone = ReadInt("phone number");
            int positionId = ReadInt("position ID");
            int departmentId = ReadInt("department ID");
            int roomId = ReadInt("room ID");

            var employee = new Employee
            {
                name = name,
                phone = phone,
                positionId = positionId,
                departmentId = departmentId,
                roomId = roomId
            };

            persistenceHandler.CreateEmployee(employee);
            Console.WriteLine("Employee created.");
        }

        private static void CreatePatient(IPersistenceHandler persistenceHandler)
        {
            Console.Write("Enter patient name: ");
            string name = Console.ReadLine();

            int phone = ReadInt("phone number");
            int cprNumber = ReadInt("CPR number");

            var patient = new Patient
            {
                name = name,
                phone = phone,
                cprNumber = cprNumber
            };

            persistenceHandler.CreatePatient(patient);
            Console.WriteLine("Patient created.");
        }

        private static void CreateBed(IPersistenceHandler persistenceHandler)
        {
            int bedNumber = ReadInt("bed number");

            var bed = new Bed
            {
                number = bedNumber
            };

            persistenceHandler.CreateBed(bed);
            Console.WriteLine("Bed created.");
        }

        private static void CreateAdmission(IPersistenceHandler persistenceHandler)
        {
            Console.Write("Enter patient ID (ObjectId): ");
            string patientId = Console.ReadLine();

            int roomId = ReadInt("room ID");

            Console.Write("Enter bed ID (ObjectId): ");
            string bedId = Console.ReadLine();

            Console.Write("Enter assigned employee ID (ObjectId): ");
            string assignedEmployeeId = Console.ReadLine();

            var admission = new Admission
            {
                patientId = patientId,
                roomId = roomId,
                bedId = bedId,
                assignedEmployeeId = assignedEmployeeId
            };

            persistenceHandler.CreateAdmission(admission);
            Console.WriteLine("Admission created.");
        }


        private static int ReadInt(string label)
        {
            while (true)
            {
                Console.Write($"Enter {label}: ");
                if (int.TryParse(Console.ReadLine(), out int value))
                    return value;
                Console.WriteLine($"Invalid input for {label}. Please enter a number.");
            }
        }
    }
}
