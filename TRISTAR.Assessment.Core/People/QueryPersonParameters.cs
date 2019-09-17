using System;
using TRISTAR.Assessment.Infrastructure;

namespace TRISTAR.Assessment.People
{
    public class QueryPersonParameters
    {
        public ParametersList<string> FirstName { get; set; }
        public ParametersList<string> LastName { get; set; }
        public ParametersList<Guid> Id { get; set; }
    }
}