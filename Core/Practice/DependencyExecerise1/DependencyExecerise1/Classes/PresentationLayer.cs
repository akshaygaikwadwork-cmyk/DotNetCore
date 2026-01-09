using DependencyExecerise1.Interface;

namespace DependencyExecerise1.Classes
{
    public class PresentationLayer
    {
        private readonly IAccount _account;
        public PresentationLayer(IAccount account)
        {
            _account = account;
        }
    }
}
