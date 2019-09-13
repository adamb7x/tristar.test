using System.Collections.Generic;

namespace TRISTAR.Test.Infrastructure
{
    /// <summary>
    /// Interface for objects that track their changed properties.
    /// </summary>
    public interface ITrackChanges
    {
        /// <summary>
        /// Returns the property names that have been modified on this object.
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetChangedProperties();
    }
}
