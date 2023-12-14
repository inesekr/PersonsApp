using System.Diagnostics;
using PersonsApp.Core.Services;
using PersonsApp.Core.Models;
using PersonsApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace PersonsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEntityService<Person> _personService;

        public HomeController(ILogger<HomeController> logger, IEntityService<Person>personService)
        {
            _logger = logger;
            _personService = personService;
        }

        public IActionResult Index()
        {
            var persons = _personService.Get();
            var personsList = new PersonListViewModel();
            personsList.PersonItems = persons.Select(person => new PersonItemViewModel
            {
                FullName = $"{person.FirstName} {person.LastName}",
                Age = CalculateAge(person.BirthDate),
                Id = person.Id,
                MaritalStatus = person.MaritalStatus,
                SpouseFullName = GetSpouseFullName(person.SpouseId)
            }
            ).ToList();
            return View(personsList);
        }

        private int? CalculateAge(DateTime? birthDate)
        {
            if (birthDate.HasValue)
            {
                DateTime today = DateTime.Today;
                int age = today.Year - birthDate.Value.Year;
                if (birthDate.Value.Date > today.AddYears(-age))
                    age--;
                return age;
            }
            return null;
        }

        private string GetSpouseFullName(int? spouseId)
        {
            if (spouseId.HasValue)
            {
                var spouse = _personService.GetById(spouseId.Value);
                return $"{spouse.FirstName} {spouse.LastName}";
            }

            return string.Empty;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}