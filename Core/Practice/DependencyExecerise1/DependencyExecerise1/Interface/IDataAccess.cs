namespace DependencyExecerise1.Interface
{
    public interface IDataAccess
    {
        public bool SignIn(string username, string password);
        public bool Register(string name);
    }
}
