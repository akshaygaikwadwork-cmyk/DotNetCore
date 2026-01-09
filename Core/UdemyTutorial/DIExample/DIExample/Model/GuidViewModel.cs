using Services;

namespace DIExample.Model
{
    public class GuidViewModel
    {
        public Guid TransientGuid1 { get; set; }
        public Guid TransientGuid2 { get; set; }
        public bool TransientSame { get; set; }

        public Guid ScopedGuid1 { get; set; }
        public Guid ScopedGuid2 { get; set; }
        public bool ScopedSame { get; set; }

        public Guid SingletonGuid1 { get; set; }
        public Guid SingletonGuid2 { get; set; }
        public bool SingletonSame { get; set; }
    }
}
