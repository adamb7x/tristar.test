using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace TRISTAR.Assessment.People
{
    /// <summary>
    /// This is the client-side repository for people. 
    /// It makes http requests to the person API endpoints.
    /// </summary>
    public class PersonClientRepository : IPersonRepository
    {
        private readonly HttpClient _httpClient;

        public PersonClientRepository(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public Task<Person> CreatePerson(EditPersonParameters parameters)
        {
            // Implementation goes here!
            throw new NotImplementedException();
        }

        public Task DeletePerson(Guid id)
        {
            // Implementation goes here!
            throw new NotImplementedException();
        }

        public Task<Person> EditPerson(Guid id, EditPersonParameters parameters)
        {
            // Implementation goes here!
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Person>> GetPeople(QueryPersonParameters parameters)
        {
            // Implementation goes here!
            throw new NotImplementedException();
        }

        public Task<Person> GetPerson(Guid id)
        {
            // Implementation goes here!
            throw new NotImplementedException();
        }
    }
}