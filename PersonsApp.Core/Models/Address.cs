namespace PersonsApp.Core.Models
{
    public class Address : Entity
    {
        public string? AddressText { get; set; }
        public bool IsPrimary { get; set; }
        public int PersonId { get; set; }
        public Person? Person { get; set; }
    }
}