namespace Polyphony.IntegrationTests.DomainPersistence
{
    public interface IEntitySpecification<TEntity>
        where TEntity : class
    {
        IEntitySpecification<TEntity> AddRule(IEntitySpecificationRule<TEntity> rule);
        void Verify();
    }
}