namespace PersonsApp.Models
{
    public class PersonListViewModel
    {
        public PersonListViewModel() 
        {
            PersonItems = new List<PersonItemViewModel>();  
        } 
        public List<PersonItemViewModel> PersonItems { get; set; }
    }
}
