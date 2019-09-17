using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRISTAR.Assessment.Infrastructure;

namespace TRISTAR.Assessment.People
{
    public class PersonServerRepository : IPersonRepository
    {
        public readonly ConcurrentDictionary<Guid, Person> People;

        public PersonServerRepository()
        {
            People = new ConcurrentDictionary<Guid, Person>();
        }

        public Task<Person> CreatePerson(EditPersonParameters parameters)
        {
            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));

            var person = new Person
            {
                Id = Guid.NewGuid()
            };

            parameters.Patch(person);
            People.AddOrUpdate(person.Id, person, (key, value) => person);

            return Task.FromResult(person);
        }

        public Task DeletePerson(Guid id)
        {
            if (id == Guid.Empty)
                throw new EmptyGuidException(nameof(id));

            People.TryRemove(id, out Person _);

            return Task.CompletedTask;
        }

        public Task<Person> EditPerson(Guid id, EditPersonParameters parameters)
        {
            if (id == Guid.Empty)
                throw new EmptyGuidException(nameof(id));

            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));

            if (!People.TryGetValue(id, out Person person))
                throw new ArgumentException($"No person found with id {id}!", nameof(id));

            parameters.Patch(person);
            People.AddOrUpdate(id, person, (key, value) => person);
            return Task.FromResult(person);
        }

        public Task<IEnumerable<Person>> GetPeople(QueryPersonParameters parameters)
        {
            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));

            IEnumerable<Person> query = People.Values;

            if (parameters.FirstName?.Any() ?? false)
                query = query.Where(x => parameters.FirstName.Contains(x.FirstName));

            if (parameters.LastName?.Any() ?? false)
                query = query.Where(x => parameters.LastName.Contains(x.LastName));

            if (parameters.Id?.Any() ?? false)
                query = query.Where(x => parameters.Id.Contains(x.Id));

            return Task.FromResult(query);
        }

        public Task<Person> GetPerson(Guid id)
        {
            if (id == Guid.Empty)
                throw new EmptyGuidException(nameof(id));

            People.TryGetValue(id, out Person person);
            return Task.FromResult(person);
        }
    }
}
