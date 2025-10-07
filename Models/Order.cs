namespace PetstoreTests.Models
{
    public class Order
    {
        public long Id { get; set; }
        public long PetId { get; set; }
        public long Quantity { get; set; }
        public DateTime ShipDate { get; set; }
        public Status Status { get; set; }
        public bool Complete { get; set; }

    }
    public enum Status
    {
        placed,
        approved,
        delivered
    }
}