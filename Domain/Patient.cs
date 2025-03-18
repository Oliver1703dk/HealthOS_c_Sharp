/**
 *
 * @author Oliver Aleksander Larsen | ollar22
 */

namespace HealthOS.Domain
{
    public class Patient
    {
        public int Id { get; }
        public int CprNumber { get; }
        public string Name { get; }
        public string Phone { get; }

        public Patient(int id, string name, string phone, int cprNumber)
        {
            Id = id;
            Name = name;
            Phone = phone;
            CprNumber = cprNumber;
        }

        public override string ToString()
        {
            return $"Patient{{ id={Id}, name={Name}, phone={Phone}, cpr_number={CprNumber} }}";
        }
    }
}
