namespace DependecyWithServiceCollection.Classes
{
    public interface ISingletonService { Guid Id { get; } }
    public interface IScopedService { Guid Id { get; } }
    public interface ITransientService { Guid Id { get; } }
    public class ClassA : ISingletonService, IScopedService, ITransientService
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}
