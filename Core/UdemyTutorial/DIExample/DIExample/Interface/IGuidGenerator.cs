namespace DIExample.Interface
{
    public interface IGuidGenerator
    {
        Guid GetGuid();
    }
    public class TransientGuidGenerator : IGuidGenerator
    {
        private readonly Guid _guid;

        public TransientGuidGenerator()
        {
            _guid = Guid.NewGuid();
        }

        public Guid GetGuid()
        {
            return _guid;
        }
    }

    public class ScopedGuidGenerator : IGuidGenerator
    {
        private readonly Guid _guid;

        public ScopedGuidGenerator()
        {
            _guid = Guid.NewGuid();
        }

        public Guid GetGuid()
        {
            return _guid;
        }
    }

    public class SingletonGuidGenerator : IGuidGenerator
    {
        private readonly Guid _guid;

        public SingletonGuidGenerator()
        {
            _guid = Guid.NewGuid();
        }

        public Guid GetGuid()
        {
            return _guid;
        }
    }
}
