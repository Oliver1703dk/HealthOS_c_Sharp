namespace HealthOS.Domain
{
    public class Admission
    {
        public int Id { get; }
        public int PatientId { get; }
        public int RoomId { get; }
        public int BedId { get; }
        public int AssignedEmployeeId { get; }

        public Admission(int id, int patientId, int roomId, int bedId, int assignedEmployeeId)
        {
            Id = id;
            PatientId = patientId;
            RoomId = roomId;
            BedId = bedId;
            AssignedEmployeeId = assignedEmployeeId;
        }

        public override string ToString()
        {
            return $"Admission{{ id={Id}, patient_id={PatientId}, room_id={RoomId}, bed_id={BedId}, assigned_employee_id={AssignedEmployeeId} }}";
        }
    }
}
