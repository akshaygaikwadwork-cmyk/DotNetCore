namespace DependencyExecerise1.Interface
{
    public interface IAccount
    {
        public bool Login(string username, string password);
    }

    public interface IUser
    {
        public bool CreateUser(string name);
    }
}
