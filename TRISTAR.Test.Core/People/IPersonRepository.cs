using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TRISTAR.Test.People
{
    public interface IPersonRepository
    {
        Task<Person> GetPerson(Guid id);

        Task<IEnumerable<Person>> GetPeople(QueryPersonParameters parameters);

        Task<Person> CreatePerson(EditPersonParameters parameters);

        Task<Person> EditPerson(Guid id, EditPersonParameters parameters);

        Task DeletePerson(Guid id);
    }
}