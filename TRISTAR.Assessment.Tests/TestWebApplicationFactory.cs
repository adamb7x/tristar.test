using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using TRISTAR.Assessment.People;
using TRISTAR.Assessment.Server;

namespace TRISTAR.Assessment
{
    internal class TestWebApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            return new WebHostBuilder().UseStartup<Startup>();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseSetting("Environment", "Development");
            base.ConfigureWebHost(builder);
        }

        public void AddSampleData()
        {
            var repo = Server.Host.Services.GetService<PersonServerRepository>();
            repo.People.AddOrUpdate(JohnDoe.Id, JohnDoe, (key, value) => JohnDoe);
            repo.People.AddOrUpdate(JaneSmith.Id, JaneSmith, (key, value) => JaneSmith);
        }

        public static readonly Person JohnDoe = new Person
        {
            FirstName = "John",
            Id = Guid.Parse("cd6b4fbf-69bc-4f88-974f-a5e308d32185"),
            LastName = "Doe"
        };

        public static readonly Person JaneSmith = new Person
        {
            FirstName = "Jane",
            Id = Guid.Parse("b548a703-f2ee-45b5-9ea3-514dcd502cca"),
            LastName = "Smith"
        };

        public static readonly Person[] SamplePeople = new[]
        {
            JohnDoe, JaneSmith
        };
    }
}
