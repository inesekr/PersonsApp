using Microsoft.AspNetCore.Mvc;

namespace PersonsApp.Models
{
    public class PersonAddViewModel
    {
        [HiddenInput]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; } 
        public List<string> PhoneNumbers { get; set; } = new List<string>();
        public List<string> Addresses { get; set; } = new List<string>();
        public int? PrimaryAddressIndex { get; set; } 
    }
}
