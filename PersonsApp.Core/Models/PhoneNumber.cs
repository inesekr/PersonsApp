namespace PersonsApp.Core.Models
{
    public class PhoneNumber : Entity
    {
        public string? Number { get; set; }
        public int PersonId { get; set; }
        public Person? Person { get; set; }
    }
}
