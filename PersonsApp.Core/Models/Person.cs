using System.ComponentModel.DataAnnotations;

namespace PersonsApp.Core.Models
{
    public class Person : Entity
    {
        [MaxLength(50)]
        public string? FirstName { get; set; }
        [MaxLength(50)]
        public string? LastName { get; set;}
        [MaxLength(10)]
        public DateTime? BirthDate { get; set; }
        public List<PhoneNumber>? PhoneNumbers { get; set; } = new List<PhoneNumber>();
        public List<Address>? Addresses { get; set; } = new List<Address>();
        public string? MaritalStatus {  get; set; }
        public int? SpouseId { get; set; }
    }
}
