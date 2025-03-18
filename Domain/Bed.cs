namespace HealthOS.Domain
{
    public class Bed
    {
        public int Id { get; }
        public string BedNumber { get; }

        public Bed(int id, string bedNumber)
        {
            Id = id;
            BedNumber = bedNumber;
        }

        public override string ToString()
        {
            return $"Bed{{ id={Id}, name={BedNumber} }}";
        }
    }
}
