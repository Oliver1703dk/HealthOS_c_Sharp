
/**
 *
 * @author Oliver Aleksander Larsen | ollar22
 */

namespace HealthOS.Domain
{
    public class Employee
    {
        public int Id { get; }
        public string Name { get; }
        public int Phone { get; }
        public int PositionId { get; }
        public int DepartmentId { get; }
        public int RoomId { get; }

        public Employee(int id, string name, int phone, int positionId, int departmentId, int roomId)
        {
            Id = id;
            Name = name;
            Phone = phone;
            PositionId = positionId;
            DepartmentId = departmentId;
            RoomId = roomId;
        }

        public override string ToString()
        {
            return $"Employee{{ id={Id}, name={Name}, phone={Phone}, position_id={PositionId}, department_id={DepartmentId}, room_id={RoomId} }}";
        }
    }
}
