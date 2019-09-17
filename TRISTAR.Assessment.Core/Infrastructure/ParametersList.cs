using System.Collections.Generic;

namespace TRISTAR.Assessment.Infrastructure
{
    public class ParametersList<T> : List<T>
    {
        public static implicit operator ParametersList<T>(T value)
        {
            return new ParametersList<T>
            {
                value
            };
        }
    }
}
