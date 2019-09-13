using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;
using TRISTAR.Test.Infrastructure;
using TRISTAR.Test.Mocks;
using TRISTAR.Test.People;

namespace TRISTAR.Test
{
    [TestClass]
    public class PersonIntegrationTests
    {
        [TestMethod]
        public async Task CanCreatePerson()
        {
            var factory = new TestWebApplicationFactory();
            var client = factory.CreateClient();
            var httpRepo = new PersonHttpRepository(client);

            var person = await httpRepo.CreatePerson(new EditPersonParameters
            {
                FirstName = TestWebApplicationFactory.JohnDoe.FirstName,
                LastName = TestWebApplicationFactory.JohnDoe.LastName
            }).ConfigureAwait(false);

            Assert.IsNotNull(person);
            Assert.AreEqual(TestWebApplicationFactory.JohnDoe.FirstName, person.FirstName);
            Assert.AreEqual(TestWebApplicationFactory.JohnDoe.LastName, person.LastName);
        }

        [TestMethod]
        public async Task CanEditPerson()
        {
            var factory = new TestWebApplicationFactory();
            var client = factory.CreateClient();
            factory.AddSampleData();
            var httpRepo = new PersonHttpRepository(client);

            var person = await httpRepo.EditPerson(TestWebApplicationFactory.JaneSmith.Id,
                new EditPersonParameters
            {
                LastName = TestWebApplicationFactory.JohnDoe.LastName
            }).ConfigureAwait(false);

            Assert.IsNotNull(person);
            Assert.AreEqual(TestWebApplicationFactory.JohnDoe.LastName, person.LastName);
        }

        [TestMethod]
        public async Task CanDeletePerson()
        {
            var factory = new TestWebApplicationFactory();
            var client = factory.CreateClient();
            factory.AddSampleData();
            var httpRepo = new PersonHttpRepository(client);

            await httpRepo.DeletePerson(TestWebApplicationFactory.JohnDoe.Id)
                .ConfigureAwait(false);

            var people = await httpRepo.GetPeople(new QueryPersonParameters())
                .ConfigureAwait(false);
            var peopleArray = people?.ToArray();

            Assert.IsNotNull(peopleArray);
            Assert.AreEqual(TestWebApplicationFactory.SamplePeople.Length - 1, peopleArray.Length);
            Assert.AreEqual(TestWebApplicationFactory.JaneSmith.Id, peopleArray[0].Id);
        }

        [TestMethod]
        public async Task CanGetPerson()
        {
            var factory = new TestWebApplicationFactory();
            var client = factory.CreateClient();
            factory.AddSampleData();
            var httpRepo = new PersonHttpRepository(client);

            var person = await httpRepo.GetPerson(TestWebApplicationFactory.JohnDoe.Id)
                .ConfigureAwait(false);

            Assert.IsNotNull(person);
            Assert.AreEqual(TestWebApplicationFactory.JohnDoe.Id, person.Id);
        }

        [TestMethod]
        public async Task CanGetPeople()
        {
            var factory = new TestWebApplicationFactory();
            var client = factory.CreateClient();
            factory.AddSampleData();
            var httpRepo = new PersonHttpRepository(client);

            var people = await httpRepo.GetPeople(new QueryPersonParameters())
                .ConfigureAwait(false);
            var peopleArray = people?.ToArray();

            Assert.IsNotNull(peopleArray);
            Assert.AreEqual(TestWebApplicationFactory.SamplePeople.Length, peopleArray.Length);
        }

        [TestMethod]
        public async Task CanGetPeopleByLastName()
        {
            var factory = new TestWebApplicationFactory();
            var client = factory.CreateClient();
            factory.AddSampleData();
            var httpRepo = new PersonHttpRepository(client);

            var people = await httpRepo.GetPeople(new QueryPersonParameters
            {
                LastName = TestWebApplicationFactory.JohnDoe.LastName
            }).ConfigureAwait(false);
            var peopleArray = people?.ToArray();

            Assert.IsNotNull(peopleArray);
            Assert.AreEqual(1, peopleArray.Length);
            Assert.AreEqual(TestWebApplicationFactory.JohnDoe.Id, peopleArray[0].Id);
        }

        [TestMethod]
        public async Task CanGetPeopleById()
        {
            var factory = new TestWebApplicationFactory();
            var client = factory.CreateClient();
            factory.AddSampleData();
            var httpRepo = new PersonHttpRepository(client);

            var people = await httpRepo.GetPeople(new QueryPersonParameters
            {
                Id = new ParametersList<Guid>
                {
                    TestWebApplicationFactory.JohnDoe.Id,
                    TestWebApplicationFactory.JaneSmith.Id
                }
            }).ConfigureAwait(false);
            var peopleArray = people?.ToArray();

            Assert.IsNotNull(peopleArray);
            Assert.AreEqual(2, peopleArray.Length);
        }
    }
}
