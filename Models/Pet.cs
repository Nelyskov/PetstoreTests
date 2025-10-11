namespace PetstoreTests.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public List<string> PhotoUrls { get; set; }
        public List<Tag> Tags { get; set; }
        public PetStatus Status { get; set; }
    }

    public enum PetStatus
    {
        available,
        pending,
        sold
    }
}