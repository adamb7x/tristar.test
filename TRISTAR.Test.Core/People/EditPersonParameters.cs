using TRISTAR.Test.Infrastructure;

namespace TRISTAR.Test.People
{
    /// <summary>
    /// Parameters to be sent to the server when modifying a <see cref="Person"/>.
    /// </summary>
    public class EditPersonParameters : PatchParametersBase
    {
        private string _firstName;
        private string _lastName;

        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }
    }
}