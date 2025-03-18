using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthOS.Domain;
using HealthOS.Persistence;

namespace HealthOS.Presentation
{
    public class MainApp
    {
        public static void Run()
        {
            Console.WriteLine(
                "------------------------------------------\n" +
                "WELCOME TO HealthOS\n" +
                "Please input your command or type \"help\"\n" +
                "------------------------------------------\n"
            );

            bool running = true;
            IPersistenceHandler persistenceHandler = PersistenceHandler.GetInstance();
            
            while (running)
            {
                Console.Write("> ");
                string command = Console.ReadLine()?.ToLower();

                switch (command)
                {
                    case "getemployees":
                        Console.WriteLine(string.Join("\n", persistenceHandler.GetEmployees()));
                        break;

                    case "getemployee":
                        Console.Write("What is the employee ID? ");
                        if (int.TryParse(Console.ReadLine(), out int empId))
                            Console.WriteLine(persistenceHandler.GetEmployee(empId));
                        else
                            Console.WriteLine("Invalid input. Please enter a number.");
                        break;

                    case "createemployee":
                        CreateEmployee(persistenceHandler);
                        break;

                    case "getpatients":
                        Console.WriteLine(string.Join("\n", persistenceHandler.GetPatients()));
                        break;

                    case "getpatient":
                        Console.Write("What is the patient ID? ");
                        if (int.TryParse(Console.ReadLine(), out int patId))
                            Console.WriteLine(persistenceHandler.GetPatient(patId));
                        else
                            Console.WriteLine("Invalid input. Please enter a number.");
                        break;

                    case "createpatient":
                        CreatePatient(persistenceHandler);
                        break;

                    case "getbeds":
                        Console.WriteLine(string.Join("\n", persistenceHandler.GetBeds()));
                        break;

                    case "getbed":
                        Console.Write("What is the bed ID? ");
                        if (int.TryParse(Console.ReadLine(), out int bedId))
                            Console.WriteLine(persistenceHandler.GetBed(bedId));
                        else
                            Console.WriteLine("Invalid input. Please enter a number.");
                        break;

                    case "createbed":
                        CreateBed(persistenceHandler);
                        break;

                    case "getadmissions":
                        Console.WriteLine(string.Join("\n", persistenceHandler.GetAdmissions()));
                        break;

                    case "getadmission":
                        Console.Write("What is the admission ID? ");
                        if (int.TryParse(Console.ReadLine(), out int admId))
                            Console.WriteLine(persistenceHandler.GetAdmission(admId));
                        else
                            Console.WriteLine("Invalid input. Please enter a number.");
                        break;

                    case "createadmission":
                        CreateAdmission(persistenceHandler);
                        break;

                    case "deleteadmission":
                        Console.Write("What is the admission ID? ");
                        if (int.TryParse(Console.ReadLine(), out int delAdmId))
                            Console.WriteLine(persistenceHandler.DeleteAdmission(delAdmId) ? "Admission deleted." : "Failed to delete admission.");
                        else
                            Console.WriteLine("Invalid input. Please enter a number.");
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
            return "Please write one of the following commands:\n" +
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

            Console.Write("Enter phone number: ");
            if (!int.TryParse(Console.ReadLine(), out int phone))
            {
                Console.WriteLine("Invalid phone number.");
                return;
            }

            Console.Write("Enter position ID: ");
            if (!int.TryParse(Console.ReadLine(), out int positionId))
            {
                Console.WriteLine("Invalid position ID.");
                return;
            }

            Console.Write("Enter department ID: ");
            if (!int.TryParse(Console.ReadLine(), out int departmentId))
            {
                Console.WriteLine("Invalid department ID.");
                return;
            }

            Console.Write("Enter room ID: ");
            if (!int.TryParse(Console.ReadLine(), out int roomId))
            {
                Console.WriteLine("Invalid room ID.");
                return;
            }

            var employee = new Employee(new Random().Next(), name, phone, positionId, departmentId, roomId);
            persistenceHandler.CreateEmployee(employee);
            Console.WriteLine("Employee created successfully.");
        }

        private static void CreatePatient(IPersistenceHandler persistenceHandler)
        {
            Console.Write("Enter patient name: ");
            string name = Console.ReadLine();

            Console.Write("Enter phone number: ");
            string phone = Console.ReadLine();

            Console.Write("Enter CPR number: ");
            if (!int.TryParse(Console.ReadLine(), out int cprNumber))
            {
                Console.WriteLine("Invalid CPR number.");
                return;
            }

            var patient = new Patient(new Random().Next(), name, phone, cprNumber);
            persistenceHandler.CreatePatient(patient);
            Console.WriteLine("Patient created successfully.");
        }

        private static void CreateBed(IPersistenceHandler persistenceHandler)
        {
            Console.Write("Enter bed number: ");
            string bedNumber = Console.ReadLine();

            var bed = new Bed(new Random().Next(), bedNumber);
            persistenceHandler.CreateBed(bed);
            Console.WriteLine("Bed created successfully.");
        }

        private static void CreateAdmission(IPersistenceHandler persistenceHandler)
        {
            Console.Write("Enter patient ID: ");
            if (!int.TryParse(Console.ReadLine(), out int patientId))
            {
                Console.WriteLine("Invalid patient ID.");
                return;
            }

            Console.Write("Enter room ID: ");
            if (!int.TryParse(Console.ReadLine(), out int roomId))
            {
                Console.WriteLine("Invalid room ID.");
                return;
            }

            Console.Write("Enter bed ID: ");
            if (!int.TryParse(Console.ReadLine(), out int bedId))
            {
                Console.WriteLine("Invalid bed ID.");
                return;
            }

            Console.Write("Enter assigned employee ID: ");
            if (!int.TryParse(Console.ReadLine(), out int assignedEmployeeId))
            {
                Console.WriteLine("Invalid employee ID.");
                return;
            }

            var admission = new Admission(new Random().Next(), patientId, roomId, bedId, assignedEmployeeId);
            persistenceHandler.CreateAdmission(admission);
            Console.WriteLine("Admission created successfully.");
        }
    }
}
