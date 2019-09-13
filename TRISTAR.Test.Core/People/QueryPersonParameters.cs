using System;
using TRISTAR.Test.Infrastructure;

namespace TRISTAR.Test.People
{
    public class QueryPersonParameters
    {
        public ParametersList<string> FirstName { get; set; }
        public ParametersList<string> LastName { get; set; }
        public ParametersList<Guid> Id { get; set; }
    }
}