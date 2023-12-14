using Microsoft.AspNetCore.Mvc;
using PersonsApp.Core.Services;
using PersonsApp.Core.Models;

namespace PersonsApp.Controllers
{
    public class PersonDetailsController : Controller
    {
        private readonly ILogger<PersonDetailsController> _logger;
        private readonly IEntityService<Person> _personService;

        public PersonDetailsController(ILogger<PersonDetailsController> logger, IEntityService<Person> personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult SearchSpouses(string searchInput)
        {
            var matchingPersons = _personService.Query()
           .Where(p =>
               p.FirstName.Contains(searchInput))
           .Select(p => new { p.Id, FullName = $"{p.FirstName} {p.LastName}" })
           .ToList();

            return Json(matchingPersons);
        }
    }
}