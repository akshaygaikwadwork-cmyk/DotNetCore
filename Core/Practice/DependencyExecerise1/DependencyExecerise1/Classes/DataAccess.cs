using DependencyExecerise1.Interface;

namespace DependencyExecerise1.Classes
{
    public class DataAccess : IDataAccess
    {
        public bool SignIn(string username, string password)
        {
            return true;
        }

        public bool Register(string name)
        {
            return true;
        }
    }
}
