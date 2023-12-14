using Microsoft.AspNetCore.Mvc;
using PersonsApp.Core.Services;
using PersonsApp.Core.Models;

namespace PersonsApp.Controllers
{
    public class PersonStatusController : Controller
    {
        private readonly ILogger<PersonStatusController> _logger;
        private readonly IEntityService<Person> _personService;

        public PersonStatusController(ILogger<PersonStatusController> logger, IEntityService<Person> personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpPost]
        public IActionResult SetSingleStatus(int personId)
        {
            var person = _personService.GetById(personId);

            person.MaritalStatus = "Single";

            _personService.Update(person);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult SetMarriedStatus(int personId, int spouseId)
        {
            var person = _personService.GetById(personId);

            person.MaritalStatus = "Married";
            person.SpouseId = spouseId;

            var spouse = _personService.GetById(spouseId);

            spouse.MaritalStatus = "Married";
            spouse.SpouseId = personId;

            _personService.Update(person);
            _personService.Update(spouse);

            return RedirectToAction("Index", "Home");
        }
    }
}