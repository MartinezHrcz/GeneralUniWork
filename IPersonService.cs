using System.Reflection.Metadata;

namespace otodikWebAPI
{
    public interface IPersonService
    {
        void Add(Person person);
        void Delete(string id);
        List<Person> Get();
        Person Get(string id);
        void Update(Person person);
    }
}
