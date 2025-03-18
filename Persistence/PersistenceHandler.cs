using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using HealthOS.Domain;

namespace HealthOS.Persistence
{
    public class PersistenceHandler : IPersistenceHandler
    {
        private static PersistenceHandler _instance;
        private readonly string _connectionString;
        private NpgsqlConnection _connection;

        private PersistenceHandler()
        {
            string host = "localhost";
            int port = 5432;
            string database = "postgres";
            string username = "postgres";
            string password = "";

            _connectionString = $"Host={host};Port={port};Database={database};Username={username};Password={password}";

            InitializePostgresqlDatabase();
        }

        public static PersistenceHandler GetInstance()
        {
            return _instance ??= new PersistenceHandler();
        }

        private void InitializePostgresqlDatabase()
        {
            try
            {
                _connection = new NpgsqlConnection(_connectionString);
                _connection.Open();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                Environment.Exit(-1);
            }
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using var cmd = new NpgsqlCommand("SELECT * FROM employees", _connection);
            cmd.Prepare();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                employees.Add(new Employee(
                    reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2),
                    reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5)
                ));
            }
            return employees;
        }

        public Employee GetEmployee(int id)
        {
            using var cmd = new NpgsqlCommand("SELECT * FROM employees WHERE id = @id", _connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            using var reader = cmd.ExecuteReader();
            return reader.Read()
                ? new Employee(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2),
                               reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5))
                : null;
        }

        public bool CreateEmployee(Employee employee)
        {
            using var cmd = new NpgsqlCommand(
                "INSERT INTO employees (name, phone, position_id, department_id, room_id) VALUES (@name, @phone, @position_id, @department_id, @room_id)", _connection);
            cmd.Parameters.AddWithValue("@name", employee.Name);
            cmd.Parameters.AddWithValue("@phone", employee.Phone);
            cmd.Parameters.AddWithValue("@position_id", employee.PositionId);
            cmd.Parameters.AddWithValue("@department_id", employee.DepartmentId);
            cmd.Parameters.AddWithValue("@room_id", employee.RoomId);
            cmd.Prepare();
            return cmd.ExecuteNonQuery() > 0;
        }

        public List<Patient> GetPatients()
        {
            List<Patient> patients = new List<Patient>();
            using var cmd = new NpgsqlCommand("SELECT * FROM patients", _connection);
            cmd.Prepare();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                patients.Add(new Patient(
                    reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3)
                ));
            }
            return patients;
        }

        public Patient GetPatient(int id)
        {
            using var cmd = new NpgsqlCommand("SELECT * FROM patients WHERE id = @id", _connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            using var reader = cmd.ExecuteReader();
            return reader.Read()
                ? new Patient(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3))
                : null;
        }

        public bool CreatePatient(Patient patient)
        {
            using var cmd = new NpgsqlCommand(
                "INSERT INTO patients (name, phone, cpr_number) VALUES (@name, @phone, @cpr_number)", _connection);
            cmd.Parameters.AddWithValue("@name", patient.Name);
            cmd.Parameters.AddWithValue("@phone", patient.Phone);
            cmd.Parameters.AddWithValue("@cpr_number", patient.CprNumber);
            cmd.Prepare();
            return cmd.ExecuteNonQuery() > 0;
        }

        public List<Bed> GetBeds()
        {
            List<Bed> beds = new List<Bed>();
            using var cmd = new NpgsqlCommand("SELECT * FROM beds", _connection);
            cmd.Prepare();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                beds.Add(new Bed(reader.GetInt32(0), reader.GetString(1)));
            }
            return beds;
        }

        public bool CreateBed(Bed bed)
        {
            using var cmd = new NpgsqlCommand(
                "INSERT INTO beds (bed_number) VALUES (@bed_number)", _connection);
            cmd.Parameters.AddWithValue("@bed_number", bed.BedNumber);
            cmd.Prepare();
            return cmd.ExecuteNonQuery() > 0;
        }

        public List<Admission> GetAdmissions()
        {
            List<Admission> admissions = new List<Admission>();
            using var cmd = new NpgsqlCommand("SELECT * FROM admissions", _connection);
            cmd.Prepare();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                admissions.Add(new Admission(
                    reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4)
                ));
            }
            return admissions;
        }

        public bool CreateAdmission(Admission admission)
        {
            using var cmd = new NpgsqlCommand(
                "INSERT INTO admissions (patient_id, room_id, bed_id, assigned_employee_id) VALUES (@patient_id, @room_id, @bed_id, @assigned_employee_id)", _connection);
            cmd.Parameters.AddWithValue("@patient_id", admission.PatientId);
            cmd.Parameters.AddWithValue("@room_id", admission.RoomId);
            cmd.Parameters.AddWithValue("@bed_id", admission.BedId);
            cmd.Parameters.AddWithValue("@assigned_employee_id", admission.AssignedEmployeeId);
            cmd.Prepare();
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool DeleteAdmission(int id)
        {
            using var cmd = new NpgsqlCommand("DELETE FROM admissions WHERE id = @id", _connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            return cmd.ExecuteNonQuery() > 0;
        }
        
        public Bed GetBed(int id)
        {
            using var cmd = new NpgsqlCommand("SELECT * FROM beds WHERE id = @id", _connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            using var reader = cmd.ExecuteReader();
            return reader.Read() 
                ? new Bed(reader.GetInt32(0), reader.GetString(1)) 
                : null;
        }

        public Admission GetAdmission(int id)
        {
            using var cmd = new NpgsqlCommand("SELECT * FROM admissions WHERE id = @id", _connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            using var reader = cmd.ExecuteReader();
            return reader.Read() 
                ? new Admission(
                    reader.GetInt32(0), 
                    reader.GetInt32(1), 
                    reader.GetInt32(2), 
                    reader.GetInt32(3), 
                    reader.GetInt32(4)
                ) 
                : null;
        }

    }
}
