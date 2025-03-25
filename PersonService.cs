
namespace otodikWebAPI
{
    public class PersonService : IPersonService
    {
        private readonly List<Person> _people;
        public PersonService() {
            _people = new List<Person>();
        }
        public void Add(Person person)
        {
            _people.Add(person);
        }

        public void Delete(string id)
        {
            _people.RemoveAll(x => x.Id == id);
        }

        public List<Person> Get()
        {
            return _people;
        }

        public Person Get(string id)
        {
            return _people.Find(x => x.Id == id);
        }

        public void Update(Person person)
        {
            var oldPerson = Get(person.Id);
            oldPerson.Name = person.Name;
            oldPerson.Email = person.Email;
            oldPerson.BirthDate = person.BirthDate;
        }
    }
}
