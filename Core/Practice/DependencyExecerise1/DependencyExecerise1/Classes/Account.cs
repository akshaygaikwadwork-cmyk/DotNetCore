using DependencyExecerise1.Interface;

namespace DependencyExecerise1.Classes
{
    public class Account : IAccount, IUser
    {
        private readonly IDataAccess _dataAccess;
        public Account(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public bool Login(string username, string password)
        {
            return _dataAccess.SignIn(username, password);
        }

        public bool CreateUser(string name)
        {
            return _dataAccess.Register(name);
        }
    }
}
