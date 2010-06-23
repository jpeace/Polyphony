namespace Polyphony.IntegrationTests.DomainPersistence
{
    public interface IEntitySpecificationRule<TEntity>
        where TEntity : class
    {
        void Execute(TEntity entity);
    }
}