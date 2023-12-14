using Microsoft.AspNetCore.Mvc;
using PersonsApp.Core.Services;
using PersonsApp.Core.Models;
using PersonsApp.Models;

namespace PersonsApp.Controllers
{
    public class PersonController : Controller
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IEntityService<Person> _personService;

        public PersonController(ILogger<PersonController> logger, IEntityService<Person> personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PersonAddViewModel person)
        {
            var newPerson = new Person
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                BirthDate = person.BirthDate,
                PhoneNumbers = person.PhoneNumbers.Select(phone => new PhoneNumber { Number = phone }).ToList(),
                Addresses = person.Addresses.Select((address, index) => new Address
                {
                    AddressText = address,
                    IsPrimary = index == person.PrimaryAddressIndex
                }).ToList()
            };

            _personService.Create(newPerson);
            return RedirectToAction("Index", "Home");
        }
    }
}