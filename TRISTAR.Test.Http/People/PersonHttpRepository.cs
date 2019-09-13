using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace TRISTAR.Test.People
{
    public class PersonHttpRepository : IPersonRepository
    {
        private readonly HttpClient _httpClient;

        public PersonHttpRepository(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public Task<Person> CreatePerson(EditPersonParameters parameters)
        {
            throw new NotImplementedException();
        }

        public Task DeletePerson(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Person> EditPerson(Guid id, EditPersonParameters parameters)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Person>> GetPeople(QueryPersonParameters parameters)
        {
            throw new NotImplementedException();
        }

        public Task<Person> GetPerson(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}